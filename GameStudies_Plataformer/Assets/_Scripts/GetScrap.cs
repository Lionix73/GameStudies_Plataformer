using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScrap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            ResourcesManager.scrap++;
            Destroy(gameObject);
        }
    }
}
