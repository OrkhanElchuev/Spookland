using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeTransition : MonoBehaviour
{
    // Private
    private Animator transitionAnimation;

    private void Start()
    {
        transitionAnimation = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName)
    {
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
