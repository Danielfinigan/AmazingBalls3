using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GameState {
	start,
	player1select,
	player2select,
	inGame,
	youWin
}

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public GameState currentGameState = GameState.start;

	public GameObject StartScreen;
	public GameObject SelectScreen1;
	public GameObject SelectScreen2;
	public GameObject InGameScreen;
	public GameObject YouWinScreen;

    public string playerWon = "";

	public void Awake () {
		Instance = this;
	}

	public void StartGame () {
		SetGameState (GameState.inGame);
		Player1Controller.Instance.StartGame ();
	}

	public void Player1Select() {
		SetGameState (GameState.player1select);
	}

	public void Player2Select() {
		SetGameState (GameState.player2select);
	}

	public void YouWin () {
		SetGameState (GameState.youWin);
	}

    public void RestartGame ()
	{
		SceneManager.LoadScene("LevelSelect");
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void QuitGame () {
		Application.Quit ();
	}

	void SetGameState (GameState newGameState) {
        if (newGameState == GameState.start)
        {
            StartScreen.SetActive(true);
            SelectScreen1.SetActive(false);
            SelectScreen2.SetActive(false);
            InGameScreen.SetActive(false);
            YouWinScreen.SetActive(false);
        }

        else if (newGameState == GameState.player1select)
        {
            StartScreen.SetActive(false);
            SelectScreen1.SetActive(true);
            SelectScreen2.SetActive(false);
            InGameScreen.SetActive(false);
            YouWinScreen.SetActive(false);
        }
        else if (newGameState == GameState.player2select)
        {
            StartScreen.SetActive(false);
            SelectScreen1.SetActive(false);
            SelectScreen2.SetActive(true);
            InGameScreen.SetActive(false);
            YouWinScreen.SetActive(false);
        }
        else if (newGameState == GameState.inGame)
        {
            StartScreen.SetActive(false);
            SelectScreen1.SetActive(false);
            SelectScreen2.SetActive(false);
            InGameScreen.SetActive(true);
            YouWinScreen.SetActive(false);
        }
        else if (newGameState == GameState.youWin)
        {
            StartScreen.SetActive(false);
            SelectScreen1.SetActive(false);
            SelectScreen2.SetActive(false);
            InGameScreen.SetActive(false);
            YouWinScreen.SetActive(true);
        }
		currentGameState = newGameState;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Start () {
	}
}
