using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarCamara : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject areaCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerCam.active)
        {
            areaCam.SetActive(true);
            playerCam.SetActive(false);
        }
        else
        {
            areaCam.SetActive(false);
            playerCam.SetActive(true);
        }
    }
}
