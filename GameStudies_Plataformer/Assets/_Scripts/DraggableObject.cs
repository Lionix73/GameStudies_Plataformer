using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Collider2D handleCollider;
    [SerializeField] public ScriptableStats _stats;

    private Rigidbody2D rb;
    private bool isInRange = false;
    private bool isDragging = false;

    private float initialSpeed;
    private float initialJumpPower;


    private Vector3 offset;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        initialSpeed = 14;
        initialJumpPower = 36;
    }

   void Update(){
        if(Input.GetKeyDown(KeyCode.E) && isInRange && !isDragging){
            isDragging = true;
            _stats.MaxSpeed = 2f;
            _stats.JumpPower = 0f;
            offset = transform.position - player.transform.position;
        }
        else if(Input.GetKeyDown(KeyCode.E) && isInRange && isDragging){
            isDragging = false;
            _stats.MaxSpeed = initialSpeed;
            _stats.JumpPower = initialJumpPower;

        }

        if (isDragging)
        {
            Vector3 newPosition = player.transform.position + offset;
            rb.MovePosition(newPosition);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            isInRange = true;
            UnityEngine.Debug.Log("Player In Range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            isInRange = false;
            UnityEngine.Debug.Log("Player NOT In Range");
        }
    }
}
