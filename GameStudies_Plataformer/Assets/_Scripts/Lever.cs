using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    [SerializeField] private float openVelocity;
    [SerializeField] private float closeVelocity;


    private Rigidbody2D rb;
    private bool closed;
    private bool isInRange = false;

    void Start(){
        rb = gate.GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.E) && isInRange){

            if (closed){
                rb.gravityScale = openVelocity;
                closed = false;
            }
            else{
                rb.gravityScale = closeVelocity;
                closed = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInRange = true;
        Debug.Log("Player In Range");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
        Debug.Log("Player Is NOT Range");
    }
}
