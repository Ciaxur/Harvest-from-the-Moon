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

    // Starts Animation to transition to Scene Name
    public IEnumerator PlayGoToMenu(string sceneName) {
        fadeTransition.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    /**
     * Handles Transitions between Scenes by Scene Index
     * @param sceneName Build Index of Scene
     */
    public void GoToScene(int sceneIndex) {
        StartCoroutine(PlayGoToMenu(sceneIndex));
    }

    // Starts Animation to transition to Build Index
    public IEnumerator PlayGoToMenu(int buildIndex) {
        fadeTransition.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(buildIndex);
    }
}
