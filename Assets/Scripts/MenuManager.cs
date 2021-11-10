//////////////////////////////////////////////
//Assignment/Lab/Project: Metroidvania
//Name: Malcolm Coronado, Noah Posey, Bryan Matthew Wolstromer
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

    public void OnGoBackButtonClick()
    {
        startMenu.SetActive(true);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }
    
    public void OnControlsButtonClick()
    {
        startMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void OnCreditsButtonClick()
    {
        startMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

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
