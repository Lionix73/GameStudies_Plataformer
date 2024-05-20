using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class GetLife : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(ResourcesManager.life < 5)
            {
                ResourcesManager.life++;

                Destroy(gameObject);
            }         
        }
    }
}
