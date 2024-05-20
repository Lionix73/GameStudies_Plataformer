using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Transform downPos;
    [SerializeField] private Transform upperPos;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private AudioSource sound;

    private bool isElevatorDown;
    private bool isInRange = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        StartElevator();
    }

    void StartElevator(){
        if (isInRange && Input.GetKeyDown(KeyCode.E)){
            sound.Play();

            if (Vector2.Distance(platform.transform.position, downPos.transform.position) < 0.5f){
                isElevatorDown = true;
            }

            if (Vector2.Distance(platform.transform.position, upperPos.transform.position) < 0.5f){
                isElevatorDown = false;
            }
        }

        if (isElevatorDown){
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else{
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, downPos.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            isInRange = true;
            Debug.Log("Player In Range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            isInRange = false;
            Debug.Log("Player Is NOT Range");
        }
    }
}
