using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonScript : MonoBehaviour
{
    Button button;
    public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            whenClicked();
        });
    }

    void whenClicked()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
