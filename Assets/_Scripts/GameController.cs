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
    [SerializeField]
    private AudioSource _gameOverSound;
    //[SerializeField]
    //private AudioSource _backSound;


    //PUBLIC INSTANCE VARIABLES

    public Text ScoreLabel;
    public Text LivesLabel;
    public Text GameOverLabel;
    public Button StartButton;
    public Button RestartButton;
    public Button QuitButton;
    public HeroController heroController;
    public Text StartLogo;
    public Text GameBy;
    public Text welldone;
    

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
        this.GameOverLabel.enabled = false;
        //this._gameOverSound.Stop();
        this.RestartButton.gameObject.SetActive(false);
        this.heroController.gameObject.SetActive(true);
        this.LivesLabel.enabled = true;
        this.ScoreLabel.enabled = true;
        this.GameOverLabel.enabled = false;
        this.StartButton.gameObject.SetActive(false);
        this.QuitButton.gameObject.SetActive(false);
        this.StartLogo.enabled = false;
        this.GameBy.enabled = false;
        this.welldone.enabled = false;



    }

    //CALLED WHEN LIVES GET TO 0
    private void _endGame()
    {
        this.LivesLabel.enabled = false;
        this.ScoreLabel.enabled = false;
        this.GameOverLabel.enabled = true;
        this.heroController.gameObject.SetActive(false);
        this._gameOverSound.Play();
        //this._backSound.Stop();
        this.RestartButton.gameObject.SetActive(true);
        this.QuitButton.gameObject.SetActive(true);
    }


    //FUNCTIONALITY OF RESTART BUTTON
    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void _hideAll()
    {
        this.heroController.gameObject.SetActive(false);
        this.StartLogo.enabled = true;
        this.GameBy.enabled = true;
        this.LivesLabel.enabled = false;
        this.ScoreLabel.enabled = false;
        this.GameOverLabel.enabled = false;
        this.StartButton.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(false);
        this.QuitButton.gameObject.SetActive(true);
        this.welldone.enabled = false;
    }

    public void levelClear()
    {
        this.welldone.enabled = true;
        this.LivesLabel.enabled = false;
        this.ScoreLabel.enabled = false;
        this.RestartButton.gameObject.SetActive(true);
        this.QuitButton.gameObject.SetActive(true);
        //this._backSound.Stop();
        
    }


    public void  quit()
    {
        Application.Quit();
    }
}
