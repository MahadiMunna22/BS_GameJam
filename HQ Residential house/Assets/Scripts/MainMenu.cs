using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public void PlayGame(){
        /* SceneManager.LoadScene(1);*/
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
         menu.SetActive(false);
        
}

    public void QuitGame(){
        Application.Quit();
    }
}
