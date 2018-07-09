using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    //A reference to our game control script so we can access it statically.
    public static GameControl instance;
    //A reference to the object that displays the text which appears when the player dies.
    public GameObject gameOverText;
    //Is the game over?
    public bool gameOver = false;
    // The speed of the ground.
    public float ScrollSpeed = -1.5f;
    //The player's score.
    private int score = 0;
    //A reference to the UI text component that displays the player's score.
    public Text scoreText;

    // Use this for initialization
    //Awake is called before Start.
    void Awake () {

        //If we don't currently have a game control...
        if (instance == null)
        {
            //...set this one to be it...
            instance = this;
            //...otherwise...
        } else if (instance != this)
        {
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
        }
	}


    // Update is called once per frame
    void Update () {
        //If the game is over and the player has pressed some input...
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		
	}

    public void BirdScored()
    {
        //The bird can't score if the game is over.
        if (gameOver == true)
        {

            return;
           
        }
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "Score: " + score.ToString();
        Debug.Log(score);
    }

    public void BirdDied()
    {
        //Activate the game over text.
        gameOverText.SetActive(true);
        //Set the game to be over.
        gameOver = true;
        Debug.Log("Dead");
    }
}
