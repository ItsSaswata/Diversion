using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject PauseMenuHolder;
    public GameObject SettingsPanel;
    //public Camera playerCamera;
    public Camera mainCamera;
    public GameObject playerReff;
    [SerializeField]private AudioSource playerAudioSource;
    private bool isPaused = false;

    void Start()
    {
        playerReff = AssetWarmup.Instance.PlayerPrefab;
        playerAudioSource = playerReff.GetComponent<AudioSource>();
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pauseMenu.SetActive(true);
        //playerCamera.enabled = false;
        mainCamera.enabled = true;
        playerReff.SetActive(false);
        playerAudioSource.enabled = false;
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        pauseMenu.SetActive(false);
       // playerCamera.enabled = true;
        mainCamera.enabled = false;

        playerReff.SetActive(true);
        playerAudioSource.enabled = true;

    }
    public void SettingsButton(){
        SettingsPanel.SetActive(true);
        PauseMenuHolder.SetActive(false);
    }
    public void BackButton(){
        SettingsPanel.SetActive(false);
        PauseMenuHolder.SetActive(true);
    }
    public void QuitButton(){
        Application.Quit();
    }
}
