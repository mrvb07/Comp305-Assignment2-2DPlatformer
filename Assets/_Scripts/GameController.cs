using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Source File Name: GameController
    Author's Name: Vinay Bhardwaj
    Last Modified By: Vinay Bhardwaj
    Date Last Modified: 5th February 2016
    Program Descreption: COMP305-ASSIGNMENT 1-HELI ATTACK
    Revision History: v16
*/

public class GameController : MonoBehaviour {
    //PRIVATE INSTANCE VARIABLES
    private int _scoreValues;
    private int _livesValues;
    //[SerializeField] //SERIALIZED FIELDS TO BE ACCESSED IN INSPECTOR
    //private AudioSource _gameOverSound;
    //[SerializeField]
    //private AudioSource _skySound; 
   


    //PUBLIC INSTANCE VARIABLES
    
    public Text ScoreLabel;
    public Text LivesLabel;
    public Text GameOverLabel;
    public Text HighScoreLabel;
    public Button StartButton;
    public Button RestartButton;
    public Button QuitButton;
    public HeroController heroController;

    public int ScoreValues
    {
        get
        {
            return this._scoreValues;
        }

        set
        {
            this._scoreValues = value;
            this.ScoreLabel.text = "Score: " + this._scoreValues;
        }
    }

    public int LivesValues
    {
        get
        {
            return this._livesValues;
        }

        set
        {
            this._livesValues = value;
            if (this._livesValues <= 0)
            {
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValues;
            }
            
        }
    }
	// Use this for initialization
	void Start () {
        this._hideAll();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startButton()
    {
        this._init();
    }


    //PRIVATE METHODS
    private void _init()
    {
        this.ScoreValues = 0;
        this.LivesValues = 5;
        this.HighScoreLabel.enabled = false;
        this.GameOverLabel.enabled = false;
        //this._gameOverSound.Stop();
        this.RestartButton.gameObject.SetActive(false);



    }

    //CALLED WHEN LIVES GET TO 0
    private void _endGame()
    {
        //this.HighScoreLabel.text = "HighScore: "+ this._scoreValues;
        this.LivesLabel.enabled = false;
        this.ScoreLabel.enabled = false;
        this.GameOverLabel.enabled = true;
        this.HighScoreLabel.enabled = true;
       
        //this._gameOverSound.Play();
        //this._skySound.Stop();
        this.RestartButton.gameObject.SetActive(true);
    }


    //FUNCTIONALITY OF RESTART BUTTON
    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void _hideAll()
    {

    }
}
