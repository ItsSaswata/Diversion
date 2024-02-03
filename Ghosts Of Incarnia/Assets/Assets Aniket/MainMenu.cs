using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject SettingsBox;
    public GameObject MainBox;
    public GameObject QuitBox;
    public GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartButton(){
        SceneManager.LoadScene("temp");
    }
    public void SettingsButton(){
        MainBox.SetActive(false);
        SettingsBox.SetActive(true);
    }
    public void BackButton(){
        MainBox.SetActive(true);
        SettingsBox.SetActive(false);
    }
    public void QuitButton(){
        QuitBox.SetActive(true);
        Image.SetActive(false);
        MainBox.SetActive(false);
    }
    public void CancelQuit(){
        QuitBox.SetActive(false);
        Image.SetActive(true);
        MainBox.SetActive(true);
    }
    public void YesQuit(){
        Application.Quit();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
