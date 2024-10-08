using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    [SerializeField] bool moveRight = true;

    private void OnTriggerStay2D(Collider2D other)
    {
        Vector3 movement = (moveRight ? Vector3.right : Vector3.left) * moveSpeed * Time.deltaTime;

        other.transform.Translate(movement);
    }
}
