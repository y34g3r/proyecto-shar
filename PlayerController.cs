using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Camera playerCamera;
    public float lookSpeed = 2f;
    public float lookXLimit = 80f;
    public float grabDistance = 3f;  // Distancia para recoger objetos  
    public float pushForce = 5f;      // Fuerza para empujar objetos  
    public Transform holdParent;      // Donde se sostendrá el objeto  
    public GameObject heldSheet; // Hoja actualmente sostenida 
    public float interactionDistance = 3f;

    private CharacterController characterController;
    private Inventory inventory;
    private GameObject heldObject;
    private float rotationX = 0f;
    private Vector3 moveDirection = Vector3.zero;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inventory = GetComponent<Inventory>();
        Cursor.lockState = CursorLockMode.Locked; // Bloquear cursor para la mirada en 1ª persona  
    }

    void Update()
    {
        // Movimiento  
        isGrounded = characterController.isGrounded;

        if (isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        // Aplicar gravedad  
        moveDirection.y -= 9.81f * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        // Mirada en 1ª persona  
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * lookSpeed, 0));

        // Recoger o mover objetos  
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" si necesitas otro botón  
        {
            if (heldObject == null)
            {
                PickUpObject(gameObject);
            }
            else
            {
                ReleaseObject();
            }
        }

        // Mover objeto si está sostenido  
        if (heldObject != null)
        {
            MoveHeldObject();
        }



       

        
    }

    public void PickUpObject(GameObject gameObject)
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, grabDistance))
        {
            if (hit.transform.CompareTag("Pickup")) // Asegúrate de que los objetos a recoger tengan la etiqueta "Pickup"  
            {
                heldObject = hit.transform.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Evitar que la física lo mueva  
                heldObject.transform.SetParent(holdParent);
                
                Debug.Log("Objeto recogido: " + heldObject.name);
            }
            if (hit.transform.CompareTag("Box")) // Asegúrate de que los objetos a recoger tengan la etiqueta "Pickup"  
            {
                heldObject = hit.transform.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Evitar que la física lo mueva  
                heldObject.transform.SetParent(holdParent);

                Debug.Log("Objeto recogido: " + heldObject.name);
            }
        }
    }

    public void ReleaseObject()
    {
        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().isKinematic = false; // Permitir que la física funcione de nuevo  
            heldObject.transform.SetParent(null);
            heldObject = null; // Limpiar la referencia del objeto sostenido  
            Debug.Log("Objeto liberado");
        }
    }

    void MoveHeldObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.position = holdParent.position; // Mueve el objeto a la posición del padre  
        }
    }


 

    
}
