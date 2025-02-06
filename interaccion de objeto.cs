using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEditor.Timeline;
using UnityEngine;

public class interacciondeobjeto : MonoBehaviour
{
    public GameObject marco;
   public void activeDoor()
    {
      marco.GetComponent<marco>().active();
    }
}
