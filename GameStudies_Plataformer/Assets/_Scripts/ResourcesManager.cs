using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    public static int scrap;

    [SerializeField] private Image[] scraps;
    [SerializeField] private Sprite colorScrap;
    [SerializeField] private Sprite grayScrap;
    [SerializeField] Timer timer;

    void Start(){
        scrap = 0;
    }

    void Update()
    {
        foreach (Image image in scraps){
            image.sprite = grayScrap;
        }

        for (int i = 0; i < scrap; i++)
        {
            scraps[i].sprite = colorScrap;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer.remainingTime = timer.starterTime;
            timer.timerText.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer.timerText.enabled = true;
        }
    }
}
