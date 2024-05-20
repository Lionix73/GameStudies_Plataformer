using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class ResourcesManager : MonoBehaviour
{
    public static int scrap;
    public static int life;

    private int dia;

    [Header("Scrap")]
    [SerializeField] private Image[] scraps;
    [SerializeField] private Sprite colorScrap;
    [SerializeField] private Sprite grayScrap;

    [Header("Life")]
    [SerializeField] private Image[] lifes;
    [SerializeField] private Sprite colorLife;
    [SerializeField] private Sprite grayLife;

    [Header("Timer & Days")]
    [SerializeField] Timer timer;
    [SerializeField] private TextMeshProUGUI diasText;
    [SerializeField] private Fades fades;

    void Start(){
        scrap = 0;
        life = 5;
        dia = 1;
        diasText.text = dia.ToString();
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

        foreach (Image image in lifes){
            image.sprite = grayLife;
        }

        for (int i = 0; i < life; i++)
        {
            lifes[i].sprite = colorLife;
        }

        if (scrap == 3){
            fades.final = true;
            fades.FadeToDay();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer.paused = true;

            if (Input.GetKeyDown(KeyCode.E)){

                if (life != 0){
                    //Pasar Dia
                    fades.FadeToDay();

                    dia = dia + 1;
                    diasText.text = dia.ToString();

                    life = life - 1;

                    timer.remainingTime = 500;
                }
                else if (life <= 0){
                    //Morido
                    SceneManager.LoadScene("Inicio");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && timer != null)
        {
            timer.paused = false;
        }
    }
}
