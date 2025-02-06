using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckSheet : MonoBehaviour
{
    
    public GameObject note;
    public GameObject temp;
    

    private void Start()
    {
        note.SetActive(false);
    }

    
    // Método para mostrar el contenido de la hoja  
    private void OnTriggerStay(Collider jugador)
    {
        if (jugador.tag == ("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                note.SetActive(true);
                temp.GetComponent<temporizador>().seacabo();
            }
            else
            {
                note.SetActive(true);
            }
        }
    }
   
      private void OnTriggerExit(Collider jugador)
    {
        if (jugador.tag != ("player"))
        { 
                note.SetActive(false);
            temp.GetComponent<temporizador>().cronometro();      
        }
    }

}
   

   
