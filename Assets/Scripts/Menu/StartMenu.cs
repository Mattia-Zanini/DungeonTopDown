using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    private void Start()
    {
        if (!DataManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }
    public void StartNewGame()
    {
        DisableMenuButtons();
        DataManager.instance.NewGame();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
        DisableMenuButtons();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
