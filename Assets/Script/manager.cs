using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public void backHome()
    {
        SceneManager.LoadScene("HomeMenu"); //HomeMenu
    }

    public void Quit()
    {
        Application.Quit(); //離開
    }

    public void playRSP()
    {
        SceneManager.LoadScene("RockPaperS"); //猜拳
    }

    public void playBilliard()
    {
        SceneManager.LoadScene("number"); //撞球
    }

    public void playSnake()
    {
        SceneManager.LoadScene("snake"); //貪食蛇
    }
}
