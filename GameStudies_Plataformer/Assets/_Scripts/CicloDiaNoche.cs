using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CicloDiaNoche : MonoBehaviour
{
    [SerializeField] private Light2D luzGlobal;
    [SerializeField] private CicloDia[] ciclosDia;
    [SerializeField] private float tiempoCiclo;

    float tiempoAcutal = 0;

    float porcentajeCiclo;

    int cicloActual = 0;

    int sigCiclo = 1;

    private void Start()
    {
        luzGlobal.color = ciclosDia[0].colorCiclo;
    }

    private void Update()
    {
        tiempoAcutal += Time.deltaTime;

        porcentajeCiclo = tiempoAcutal / tiempoCiclo;

        if (tiempoAcutal >= tiempoCiclo)
        {
            tiempoAcutal = 0;
            cicloActual = sigCiclo;

            if(sigCiclo + 1 > ciclosDia.Length - 1)
            {
                sigCiclo = 0;
            }
            else
            {
                sigCiclo += 1;  
            }
        }

        CambiarColor(ciclosDia[cicloActual].colorCiclo, ciclosDia[sigCiclo].colorCiclo);
    }

    public void CambiarColor(Color colorActual, Color sigColor)
    {
        luzGlobal.color = Color.Lerp(colorActual, sigColor, porcentajeCiclo);
    }
}
