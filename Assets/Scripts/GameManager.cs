using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int playerLives = 3;
    private void Awake()
    { 
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    private void TakeLife()
    {
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
