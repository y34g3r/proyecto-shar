using UnityEngine;

public class marco2 : MonoBehaviour
{

    public float angleOpen = -80f;
    public float angleClosed = 0f;
    public float smooth = 3.0f;


    public bool abrir = false;

    public void active2()
    {
        abrir = !abrir;


    }

    public void Update()
    {


        if (abrir == true)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angleOpen, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, angleClosed, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
    }
}
