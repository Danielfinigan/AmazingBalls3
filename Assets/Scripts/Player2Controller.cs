using UnityEngine;
using System.Collections;

public class Player2Controller : MonoBehaviour {

	public static Player2Controller Instance;

	[SerializeField] private float speed = 15f;
	public Rigidbody2D rb = new Rigidbody2D ();

	void Awake () {
		Instance = this;
	}

	public void StartGame () {
		if (GameManager.Instance.currentGameState == GameState.inGame)
			speed = 15f;
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.UpArrow))
			rb.AddForce (transform.up * speed);
		if (Input.GetKey (KeyCode.DownArrow))
			rb.AddForce (transform.up * -speed);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
