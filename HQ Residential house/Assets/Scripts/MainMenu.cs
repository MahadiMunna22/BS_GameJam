using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public void PlayGame(){
<<<<<<< Updated upstream
        /* SceneManager.LoadScene(1);*/
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
         menu.SetActive(false);
        
}
=======
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
>>>>>>> Stashed changes

    public void QuitGame(){
        Application.Quit();
    }
}
