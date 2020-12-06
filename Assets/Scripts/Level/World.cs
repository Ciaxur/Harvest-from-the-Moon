using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class World : MonoBehaviour {
    // External Settings
    public bool isLastLevel = false;
    public int totalEnemies = 1;        // Total Enemies until Next Level
  
    // References & Internal
    SceneTransitions sceneTran;
    bool isGameOver = false;


    // Game Over
    public void GameOver() {
      sceneTran.GoToScene("MainMenu");
    }

    public void NextLevel() {
      if (isLastLevel) {
        GameOver();
      }
      else {
        sceneTran.GoToScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
    }


    void Start() {
      sceneTran = GetComponent<SceneTransitions>();

      if (!sceneTran) {
        Debug.LogError("World: No Scene Transition Component!");
        Debug.DebugBreak();
      }
    }

    void Update() {
      if (!isGameOver && totalEnemies <= 0) {
        isGameOver = true;
        NextLevel();
      }
    }

}
