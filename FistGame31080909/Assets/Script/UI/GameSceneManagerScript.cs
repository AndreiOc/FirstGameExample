using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameStartScene;
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
