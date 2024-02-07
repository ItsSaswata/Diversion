using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausescript : MonoBehaviour
{
    private GameObject playerPrefab; // Reference to your player prefab
    private GameObject pauseMenu;
    private bool isPaused;
    private string initialSceneName;
    [SerializeField]PlayerController playerController;

    void Start()
    {
        gameObject.SetActive(false);
        //initialSceneName = SceneManager.GetActiveScene().name;
//
       // // Assuming the player prefab is instantiated during Start or elsewhere
      //  playerPrefab = GameObject.FindGameObjectWithTag("Player"); // Adjust tag or find method accordingly
//
       // if (playerPrefab != null)
       // {
       //     // Find the UI Canvas under the player prefab
       //     Transform canvasTransform = playerPrefab.transform.Find("UI Canvas");
//
       //     if (canvasTransform != null)
       //     {
       //         // Find the PauseMenu under the UI Canvas
       //         pauseMenu = canvasTransform.gameObject.transform.Find("PausePanel")?.gameObject;
//
       //         if (pauseMenu != null)
       //         {
       //             pauseMenu.SetActive(false);
       //         }
       //         else
       //         {
       //             Debug.LogError("PauseMenu not found under the UI Canvas!");
       //         }
       //     }
       //     else
       //     {
       //         Debug.LogError("UI Canvas not found under the player prefab!");
       //     }
       // }
       // else
        //{
        //    Debug.LogError("PlayerPrefab reference is not set!");
        //}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // This freezes the game
        playerController.SetGamePaused(!isPaused);

        gameObject.SetActive(true);
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // This resumes the game
        playerController.SetGamePaused(!isPaused);

        gameObject.SetActive(false);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("UI");
        ResumeGame();
    }
}