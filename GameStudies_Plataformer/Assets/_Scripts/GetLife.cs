using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLife : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            ResourcesManager.life++;
            Destroy(gameObject);
        }
    }
}
