using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Menu()
    {
        GameManager.Won = false;
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
