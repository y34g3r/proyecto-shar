using TMPro;
using UnityEditor;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class temporizador : MonoBehaviour
{
    
    public Reconocimientoestante reconocer;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private float tiempo;
    [SerializeField] private GameObject tiempoTerminado;
    private string Search;

    bool tiempodetenido;

    private int tiempominutos, tiemposegundos, tiempomilesimas;

    private void Start()
    {
        text.gameObject.SetActive(false);
        tiempoTerminado.gameObject.SetActive(false);
    }

    

    public void cronometro()
    { 
        if (!tiempodetenido)
        {
            text.gameObject.SetActive(true);

            while (tiempo >0)
            {
                tiempo -= Time.deltaTime;
            }
            tiempominutos = Mathf.FloorToInt(tiempo / 60);
            tiemposegundos = Mathf.FloorToInt(tiempo % 60);
            tiempomilesimas = Mathf.FloorToInt((tiempo % 1) * 100);

           
            text.text = string.Format("{0:00}:{1:00}:{2:00}", tiempominutos, tiemposegundos, tiempomilesimas);
        }

           

            
    }

    public void seacabo()
    {
        if (tiempo <= 0)
        {
            tiempo = 0;
            tiempodetenido = true;
            tiempoTerminado.SetActive(false);
        }
    }


}
