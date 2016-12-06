using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	public static Player1Controller Instance;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;

	[SerializeField] private float speed = 15f;
  	public Projectile projectile;
	private SpriteRenderer spriteRenderer;

	[SerializeField] private float speed = 30f;
	public Rigidbody2D rb = new Rigidbody2D ();

    private bool runOnce = false;
    void Awake () {
		Instance = this;
	}

	public void StartGame () {
		if (GameManager.Instance.currentGameState == GameState.inGame)
			speed = 30f;
	}

	public void ToPlayer2Select () {
		GameManager.Instance.Player2Select ();
	}

	public void SpriteTo1 () {
		spriteRenderer.sprite = sprite1;
		ToPlayer2Select ();
	}

	public void SpriteTo2 () {
		spriteRenderer.sprite = sprite2;
		ToPlayer2Select ();
	}

	public void SpriteTo3 () {
		spriteRenderer.sprite = sprite3;
		ToPlayer2Select ();
	}

	public void SpriteTo4 () {
		spriteRenderer.sprite = sprite4;
		ToPlayer2Select ();
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.W))
			rb.AddForce (transform.up * speed);
		if (Input.GetKey (KeyCode.S))
			rb.AddForce (transform.up * -speed);
	}

    void Fire()
    {
        Projectile ballClone;
        Vector2 spawnPosition = new Vector2(Instance.transform.position.x + 1f, Instance.transform.position.y);
        ballClone = (Projectile) Instantiate(projectile, spawnPosition, Quaternion.identity);
    }

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		if (spriteRenderer.sprite == null)
			spriteRenderer.sprite = sprite1;
	}
	
	// Update is called once per frame
	void Update () {
        float fireIsPressed = Input.GetAxisRaw("Fire1");
        if (fireIsPressed == 0)
            runOnce = false;
        if (fireIsPressed == 1 && !runOnce)
        {
            Fire();
            StartCoroutine(FireRate());
            runOnce = true;
        }
	}

    public IEnumerator FireRate()
    {
        yield return new WaitForSeconds(1f);
    }
}
