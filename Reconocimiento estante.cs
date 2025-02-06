using System;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Reconocimientoestante : MonoBehaviour
{
    public GameObject script;

    public GameObject[] slots; // Array para los slots que van a recibir las cajas  
    public int[] cajaCount; // Array para llevar la cuenta de cajas en cada slot  
    public const int maxCajasPorSlot = 1; // Cantidad máxima de cajas por slot  
    

    private void Start()
    {
        // Inicializa el array para contar las cajas en cada slot  
        cajaCount = new int[slots.Length];

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box")) // Verifica si el objeto que colisiona es una caja  
        {
            for (int i = 0; i < slots.Length; i++)
            {
                
                if (cajaCount[i] < maxCajasPorSlot)
                {
                    script.GetComponent<PlayerController>().ReleaseObject();
                    almacenarCaja(other.gameObject, slots[i]);
                    cajaCount[i]++;
                    if (cajaCount[i] >= maxCajasPorSlot)
                    {
                        // Desactiva el slot si ha alcanzado su capacidad  
                        slots[i].GetComponent<Collider>().enabled = false;
                        Debug.Log($"El slot {slots[i].name} está lleno.");


                    }
                    return; // Salimos del bucle si hemos almacenado la caja  
                }
                
            }
        }
    }

    private void almacenarCaja(GameObject caja, GameObject targetSlot)
    {
        
            caja.transform.SetParent(targetSlot.transform);
            caja.transform.localPosition = Vector3.zero;
            caja.transform.localRotation = new Quaternion(0f,0f,0f,0f) ;
        // Ajusta la posición según sea necesario  
        caja.GetComponent<Rigidbody>().isKinematic = true;
        
        // Desactivar el Rigidbody de la caja para que no se vea afectada por la física después de almacenarlo
        Debug.Log($"{caja.name} almacenada en {targetSlot.name}.");
    }

   
}
