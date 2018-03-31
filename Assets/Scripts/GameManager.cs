using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text Wave, Health, Ingredients;
    public static int wave = 1;
    public static int health = 3;
    public static int ingredients = 10;
    public static bool Won = false;

	void Start () {
        Wave.GetComponent<Text>();
        Health.GetComponent<Text>();
        Ingredients.GetComponent<Text>();
	}
	
	void Update () {
        Wave.text = wave.ToString();
        Health.text = health.ToString();
        Ingredients.text = ingredients.ToString();
	}

    public static void LevelManagement()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Level1":
                ingredients += 5;
                SceneManager.LoadScene("Level2");
                break;
            case "Level2":
                if (wave == 1)
                    wave++;
                else
                {
                    ingredients += 5;
                    wave = 1;
                    SceneManager.LoadScene("Level3");
                }
                break;
            case "Level3":
                if (wave < 3)
                    wave++;
                else if (wave == 3 && health > 0)
                {
                    Won = true;
                    GameOver();
                }
                else
                    GameOver();
                break;
        }
    }

    public static void GameOver()
    {
        wave = 1;
        health = 3;
        ingredients = 10;
        SceneManager.LoadScene("GameOver");
    }
}
