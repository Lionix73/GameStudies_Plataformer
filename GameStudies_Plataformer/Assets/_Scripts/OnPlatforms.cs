using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatforms : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other){
        other.transform.SetParent(gameObject.transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.SetParent(null);
    }
}
