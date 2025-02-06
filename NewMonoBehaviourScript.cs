using System.Security;
using UnityEditor.Rendering;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    LayerMask mask2;
    LayerMask mask;
    public float distancia = 1.5f;

    public Texture2D puntero;
    public GameObject TextDetected;
    
    GameObject lastdetect = null;
    

    //objetos
    public Collider objeto1;
    GameObject objeto2;
    GameObject objeto3;
    GameObject objeto4;

    public bool active;
    void Start()
    {
        mask = LayerMask.GetMask("interactive layer");
        TextDetected.SetActive(false);
        mask2 = LayerMask.GetMask("Interactive box");
    }

   
    void Update()
    {

        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, distancia, mask))
        {
            Deselected();
            Selected(hit.transform);
            if(hit.collider.tag == ("Door"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    hit.collider.GetComponent<interacciondeobjeto>().activeDoor();
                    
                }    
            }

            Selected(hit.transform);
            if (hit.collider.tag == ("Door2"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    hit.collider.GetComponent<interacciondepuerta2>().activeDoor2();
                    
                }
            }

            
            if (hit.collider.tag == ("Box"))
            {
                
                if (hit.collider.GetComponent<Rigidbody>().isKinematic == true)
                {
                    Deselected();
                }
                else
                {
                    Selected(hit.transform);
                }
            }
           
        }
        else
        {
            Deselected();
        }

    }

    private void Selected(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        lastdetect = transform.gameObject;
        
    }

  

    private void Deselected()
    {
        if (lastdetect)
        {
            lastdetect.GetComponent<MeshRenderer>().material.color = Color.white;
            lastdetect = null;
        }
        
    }

    private void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);

        if (lastdetect) 
        {
            TextDetected.SetActive(true);

        }
        else
        {
            TextDetected.SetActive(false);
        }

        
    }

    
}
