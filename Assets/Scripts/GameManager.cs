using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;

    // Quits the game
    public void OnQuitButtonClick()
    {
        Application.Quit();
        print("Quitting the game");
    }

    // Restarts the level
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
