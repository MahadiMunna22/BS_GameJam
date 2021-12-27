using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
    }
    //public void PauseGame()
    //{
    //    Time.timeScale = 0.0f;
    //}
    
}
