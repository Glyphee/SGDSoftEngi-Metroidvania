using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;

    public void OnQuitButtonClick()
    {
        Application.Quit();
        print("Quitting the game");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
