using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GameState {
	start,
	inGame,
	gameOver,
	levelComplete,
	youWin
}

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public GameState currentGameState = GameState.start;

	public GameObject StartScreen;
	public GameObject InGameScreen;
	public GameObject LevelCompleteScreen;
	public GameObject GameOverScreen;
	public GameObject YouWinScreen;

	public void Awake () {
		Instance = this;
	}

	public void StartGame () {
		SetGameState (GameState.inGame);
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

	public void RestartGame ()
	{
		SceneManager.LoadScene("Arena1");
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
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.inGame) {
			StartScreen.SetActive (false);
			InGameScreen.SetActive(true);
			LevelCompleteScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.levelComplete) {
			StartScreen.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (true);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.gameOver) {
			StartScreen.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			GameOverScreen.SetActive(true);
			YouWinScreen.SetActive (false);
		} else if (newGameState == GameState.youWin) {
			StartScreen.SetActive (false);
			InGameScreen.SetActive(false);
			LevelCompleteScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWinScreen.SetActive (true);
		}
		currentGameState = newGameState;
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
