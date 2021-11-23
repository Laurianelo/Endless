using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text diamondText;
    public static int nOfDiamond;
    public static bool gameOver;
    public static bool winGame;
    public GameObject EndPanel;
    public Text WinOrLose;

    private void Start()
    {
        winGame = false; ;
        gameOver = false;
        nOfDiamond = 0;
        Time.timeScale = 1;
    }

    private void Update()
    {
        DisplayDiamond();
        DisplayEndScreen();
    }

    //Display end sceen and stop the game
    private void DisplayEndScreen()
    {
        if(gameOver == true)
        {
            EndPanel.SetActive(true);
            WinOrLose.text = "LOSER";
            Time.timeScale = 0;
        }
        else if(winGame == true)
        {
            EndPanel.SetActive(true);
            Time.timeScale = 0;
            WinOrLose.text = "WINNER\n Score : " + nOfDiamond.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level01");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

    //displays the number of diamonds of the player
    private void DisplayDiamond()
    {
        diamondText.text = nOfDiamond.ToString();
    }
}
