using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPasued = false;
    public GameObject GameOverGUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPasued)
            {
                Time.timeScale = 0.0f;
            }
            else if(!isPasued && ! Inventory.Instance.isGameOver)
            {
                Time.timeScale = 1.0f;
            }
            isPasued = !isPasued;
        }
        if (Inventory.Instance.isGameOver)
        {
            Time.timeScale = 0.0f;
            GameOverGUI.SetActive(true);
        }
    }
}
