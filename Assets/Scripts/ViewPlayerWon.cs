using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewPlayerWon : MonoBehaviour {
    public Text playerWon;
	// Use this for initialization
	void Start ()
    {
        playerWon.text = GameManager.Instance.playerWon;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
