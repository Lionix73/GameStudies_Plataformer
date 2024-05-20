using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGates : MonoBehaviour
{
    [System.Serializable]

    public class GateData
    {
        public GameObject gate;

        [Tooltip("Este valor debe ser Negativo")]
        public float openVelocity;

        [Tooltip("Este valor debe ser Positivo")]
        public float closeVelocity;

        [HideInInspector] public bool closed = true;
    }

    [SerializeField] private List<GateData> gates = new List<GateData>();
    [SerializeField] private float timeBetweenActions = 2f;
    [SerializeField] private AudioSource sound;

    private bool isInRange = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            sound.Play();

            LeverAction();
        }
    }

    private void LeverAction(){
        foreach (var gateData in gates)
        {
            Rigidbody2D rb = gateData.gate.GetComponent<Rigidbody2D>();

            if (gateData.closed)
            {
                rb.gravityScale = gateData.openVelocity;
                gateData.closed = false;
            }
            else
            {
                rb.gravityScale = gateData.closeVelocity;
                gateData.closed = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInRange = true;
        UnityEngine.Debug.Log("Player In Range");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
        UnityEngine.Debug.Log("Player Is NOT Range");
    }
}
