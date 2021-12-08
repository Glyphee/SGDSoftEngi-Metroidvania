//////////////////////////////////////////////
//Assignment/Lab/Project: Metroidvania
//Name: Malcolm Coronado, Noah Posey, Bryan Wolstromer
//Section: 2021FA.SGD.285.
//Instructor: Aurore Wold
//Date: 11/10/2021
/////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject instructionsMenu;
    public GameObject creditsMenu;
    public GameObject controlsMenu;

    // Makes sure the start menu appears when the player starts the game
    void Start()
    {
        startMenu.SetActive(true);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Returns to the start menu
    public void OnGoBackButtonClick()
    {
        startMenu.SetActive(true);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }
    
    // Displays the controls menu
    public void OnControlsButtonClick()
    {
        startMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    // Displays the credits menu
    public void OnCreditsButtonClick()
    {
        startMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    // Displays the instructions menu
    public void OnInstructionsButtonClick()
    {
        startMenu.SetActive(false);
        instructionsMenu.SetActive(true);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void OnExitGameButtonClick()
    {
        Application.Quit();
    }
}
