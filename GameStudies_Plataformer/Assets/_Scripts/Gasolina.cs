using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gasolina : MonoBehaviour
{
    [SerializeField] TextMeshPro gasText;

    [SerializeField] GameObject instructions;

    [SerializeField] Timer timer;

    [SerializeField] private int gasAmount;

    private void Start()
    {
        gasText.text = gasAmount.ToString();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyUp(KeyCode.F) && gasAmount > 0)
        {
                timer.remainingTime += 60;
                gasAmount--;
                gasText.text = gasAmount.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        instructions.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        instructions.SetActive(false);
    }
}
