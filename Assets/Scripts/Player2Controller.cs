using UnityEngine;
using System.Collections;

public class Player2Controller : MonoBehaviour {

	public static Player2Controller Instance;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;

	private SpriteRenderer spriteRenderer;

	[SerializeField] private float speed = 30f;
	public Rigidbody2D rb = new Rigidbody2D ();

	void Awake () {
		Instance = this;
	}

	public void StartGame () {
		if (GameManager.Instance.currentGameState == GameState.inGame)
			speed = 30f;
	}

	public void ToGame () {
		GameManager.Instance.StartGame ();
	}

	public void SpriteTo1 () {
		spriteRenderer.sprite = sprite1;
		ToGame ();
	}

	public void SpriteTo2 () {
		spriteRenderer.sprite = sprite2;
		ToGame ();
	}

	public void SpriteTo3 () {
		spriteRenderer.sprite = sprite3;
		ToGame ();
	}

	public void SpriteTo4 () {
		spriteRenderer.sprite = sprite4;
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
		if (spriteRenderer.sprite == null)
			spriteRenderer.sprite = sprite1;
	}

	// Update is called once per frame
	void Update () {

	}
}
