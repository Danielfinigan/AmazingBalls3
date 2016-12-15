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
	gameOver,
	levelComplete,
	nextLevel,
	youWin
}

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public GameState currentGameState = GameState.start;

	public GameObject StartScreen;
	public GameObject SelectScreen1;
	public GameObject SelectScreen2;
	public GameObject InGameScreen;
	public GameObject LevelCompleteScreen;
	public GameObject GameOverScreen;
	public GameObject NextLevelScreen;
	public GameObject YouWinScreen;

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

	public void LvlComplete () {
		SetGameState (GameState.levelComplete);
	}

	public void GameOver () {
		SetGameState (GameState.gameOver);
	}

	public void YouWin () {
		SetGameState (GameState.youWin);
	}

	public void NextLevel () {
		if (Application.loadedLevelName == "Arena2") {
			YouWin ();
		} else {
			SetGameState (GameState.nextLevel);
		}
	}

	public void RestartGame ()
	{
		SceneManager.LoadScene("Arena1");
	}

	public void LoadNextLevel () {
		Debug.Log ("loadnextlevel called");
		if (Application.loadedLevelName == "Arena1") {
			SceneManager.LoadScene ("Arena2");
		} else if (Application.loadedLevelName == "Arena2") {
			SceneManager.LoadScene ("Arena1");
		}
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void QuitGame () {
		Application.Quit ();
	}

	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.start) {
			StartScreen.SetActive(true);
			SelectScreen1.SetActive (false);
			SelectScreen2.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			NextLevelScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.player1select) {
			StartScreen.SetActive (false);
			SelectScreen1.SetActive (true);
			SelectScreen2.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			NextLevelScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.player2select) {
			StartScreen.SetActive (false);
			SelectScreen1.SetActive (false);
			SelectScreen2.SetActive (true);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			NextLevelScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.inGame) {
			StartScreen.SetActive (false);
			SelectScreen1.SetActive (false);
			SelectScreen2.SetActive (false);
			InGameScreen.SetActive(true);
			LevelCompleteScreen.SetActive (false);
			NextLevelScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.levelComplete) {
			StartScreen.SetActive (false);
			SelectScreen1.SetActive (false);
			SelectScreen2.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (true);
			NextLevelScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.nextLevel) {
			StartScreen.SetActive (false);
			SelectScreen1.SetActive (false);
			SelectScreen2.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			NextLevelScreen.SetActive (true);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.gameOver) {
			StartScreen.SetActive (false);
			SelectScreen1.SetActive (false);
			SelectScreen2.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			NextLevelScreen.SetActive (false);
			GameOverScreen.SetActive(true);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.youWin) {
			StartScreen.SetActive (false);
			SelectScreen1.SetActive (false);
			SelectScreen2.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			NextLevelScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (true);
		}
		currentGameState = newGameState;
	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void Start () {
		if (Application.loadedLevelName == "Arena2")
			Player1Select ();
	}
}
