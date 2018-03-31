using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text gameOver;
	// Use this for initialization
	void Start () {
        gameOver.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Won)
        {
            gameOver.text = "You did it! You have saved our beautiful Nigiri from the evil pizza invaders! You will be forever remembered as a saviour of our people. You have my immense thanks.";
        }
        else if (!GameManager.Won)
            gameOver.text = "Nigiri has fallen to these treacherous pizzas! Our fields are stained with the rice of our fallen. I will forever regret putting you in charge!";
	}
}
