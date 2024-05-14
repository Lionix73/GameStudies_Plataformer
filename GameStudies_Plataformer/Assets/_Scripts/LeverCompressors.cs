using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverCompressors : MonoBehaviour
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
    [SerializeField] private bool automatic = false;

    private bool isInRange = false;
    private bool leverActivated = false;

    private void Update()
    {
        if (automatic && !leverActivated){
            leverActivated = true;
            StartCoroutine(PerformLeverActions());
        }

        if (Input.GetKeyDown(KeyCode.E) && isInRange && !leverActivated)
        {
            leverActivated = true;
            StartCoroutine(PerformLeverActions());
        }
    }

    private IEnumerator PerformLeverActions()
    {
        while (true)
        {
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

            yield return new WaitForSeconds(timeBetweenActions);
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
