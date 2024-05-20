using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPanel;
    private bool gameIsPaused;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
       {
            Resume();
       }
       else if (Input.GetKeyDown(KeyCode.Escape) != gameIsPaused) 
       {
            Pausa();
       }
    }

    public void Pausa()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void QuitGame()
    {
        Debug.Log("saquese");
        Application.Quit();
    }
}
