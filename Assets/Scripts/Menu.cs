using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ButtonFB()
    {
        Application.OpenURL("https://www.facebook.com/vt21003");
    }
    public void ButtonIG()
    {
        Application.OpenURL("https://www.instagram.com/vt21003/");

    }
    public void ButtonYTB()
    {
        Application.OpenURL("https://www.youtube.com/@vt21003");
    }

    public void ButtonLevel1_1()
    {
        SceneManager.LoadScene("Level1_1");
        Time.timeScale = 1;
    }
    public void ButtonLevel1_2()
    {
        SceneManager.LoadScene("Level1_2");
        Time.timeScale = 1;
    }
    public void ButtonLevel()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }

}
