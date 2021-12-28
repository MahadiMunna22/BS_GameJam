using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public void PlayGame(){
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
         menu.SetActive(false);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
