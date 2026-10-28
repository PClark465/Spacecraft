using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Panels")] // Creates a header for the menu panels
    // Creates variables for the panels
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    
    public void StartGame()
    {
        // Loads the game scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGameScene");
    }

    // Establishes methods to swap between the option and main menu screens
    public void OpenOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        // Quits the game when Quit Game is pressed
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
