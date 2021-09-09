using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    public KeyCode quitKey;

    public KeyCode Reset;
void Update() {
    if(Input.GetKeyDown(Reset))
    {
        ResetScene();
    }

    if(Input.GetKeyDown(quitKey))
    {
        Application.Quit();
    }
}

void ResetScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

}
