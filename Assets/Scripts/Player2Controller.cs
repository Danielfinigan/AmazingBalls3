using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player2Controller : MonoBehaviour {

	public static Player2Controller Instance;
    public List<Sprite> sprites = new List<Sprite>();

	private SpriteRenderer spriteRenderer;

	[SerializeField] private float speed = 0f;
	public Rigidbody2D rb = new Rigidbody2D ();

	void Awake () {
		Instance = this;
	}

	public void StartGame () {
		if (GameManager.Instance.currentGameState == GameState.inGame)
			speed = 50f;
	}

	public void ToGame () {
		GameManager.Instance.StartGame ();
	}

	public void SpriteTo1 () {
		spriteRenderer.sprite = sprites[0];
		ToGame ();
	}

	public void SpriteTo2 () {
		spriteRenderer.sprite = sprites[1];
		ToGame ();
	}

	public void SpriteTo3 () {
		spriteRenderer.sprite = sprites[2];
		ToGame ();
	}

	public void SpriteTo4 () {
		spriteRenderer.sprite = sprites[3];
		ToGame ();
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.UpArrow))
			rb.AddForce (transform.up * speed);
		if (Input.GetKey (KeyCode.DownArrow))
			rb.AddForce (transform.up * -speed);
	}

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> (); 
	}

	// Update is called once per frame
	void Update () {

	}
}
