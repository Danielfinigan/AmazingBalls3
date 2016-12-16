using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum LevelState
{
    startMenu,
    arenaSelect,
    howToPlay,
    lore
}
public class LevelSelectManager : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject ArenaSelect;
    public GameObject HowToPlay;
    public GameObject Lore;

    public void StartScreen()
    {
        SetLevelState(LevelState.startMenu);
    }
    public void ArenaScreen()
    {
        SetLevelState(LevelState.arenaSelect);
    }
    public void HowToPlayScreen()
    {
        SetLevelState(LevelState.howToPlay);
    }

    public void LoreScreen()
    {
        SetLevelState(LevelState.lore);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Arena1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Arena2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Arena3");
    }

    public void SetLevelState(LevelState newLevelState)
    {
        if (newLevelState == LevelState.startMenu)
        {
            StartMenu.SetActive(true);
            ArenaSelect.SetActive(false);
            HowToPlay.SetActive(false);
            Lore.SetActive(false);
        }
        if (newLevelState == LevelState.arenaSelect)
        {
            StartMenu.SetActive(false);
            ArenaSelect.SetActive(true);
            HowToPlay.SetActive(false);
            Lore.SetActive(false);
        }
        if (newLevelState == LevelState.howToPlay)
        {
            StartMenu.SetActive(false);
            ArenaSelect.SetActive(false);
            HowToPlay.SetActive(true);
            Lore.SetActive(false);
        }
        if (newLevelState == LevelState.lore)
        {
            StartMenu.SetActive(false);
            ArenaSelect.SetActive(false);
            HowToPlay.SetActive(false);
            Lore.SetActive(true);
        }
    }


}
