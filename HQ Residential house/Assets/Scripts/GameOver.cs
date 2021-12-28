using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void BackToMainMenu()
    {
        Debug.Log("Back to main menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Inventory.Instance.isGameOver = false;
        Inventory.Instance.isPaused = false;
    }
}
