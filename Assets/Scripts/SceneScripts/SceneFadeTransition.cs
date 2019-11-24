using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeTransition : MonoBehaviour
{
    private Animator transitionAnimation;

    private void Start()
    {
        transitionAnimation = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        transitionAnimation.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }


    // Quit the application 
    public void Quit()
    {
        Application.Quit();
    }
}
