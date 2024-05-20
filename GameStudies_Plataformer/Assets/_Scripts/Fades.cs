using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fades : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool final;

    void Start(){
        final = false;
    }

    public void FadeToDay(){
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeOutComplete(){
        if (final){
            SceneManager.LoadScene("Final");
        }

        animator.SetTrigger("FadeIn");
    }
}
