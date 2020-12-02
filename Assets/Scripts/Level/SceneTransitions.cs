using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitions : MonoBehaviour {
    // External References
    public Animator fadeTransition;
    

    /**
     * Handles Transitions between Scenes
     * @param sceneName String Name of Scene
     */
    public void GoToScene(string sceneName) {
        StartCoroutine(PlayGoToMenu(sceneName));
    }

    // Starts Animation to transition to Main Menu
    public IEnumerator PlayGoToMenu(string sceneName) {
        fadeTransition.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
