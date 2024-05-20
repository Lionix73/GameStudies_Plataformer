using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorPresion : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Transform downPos;
    [SerializeField] private Transform upperPos;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    private bool isInRange = false;

    private void FixedUpdate()
    {
        if(isInRange)
        {
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, downPos.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player In Range");


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
