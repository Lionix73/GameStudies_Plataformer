using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("Nivel");
    }

    public void Inicio(){
        SceneManager.LoadScene("Inicio");
    }

    public void Instrucciones(){
        SceneManager.LoadScene("Instrucciones");
    }

    public void Quit(){
        Application.Quit();
    }
}
