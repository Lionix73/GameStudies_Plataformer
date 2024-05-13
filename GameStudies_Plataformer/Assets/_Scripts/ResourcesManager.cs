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
}
