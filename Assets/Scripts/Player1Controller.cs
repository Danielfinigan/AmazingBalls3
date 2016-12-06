using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player1Controller : MonoBehaviour {

	public static Player1Controller Instance;
    public List<Sprite> sprites = new List<Sprite>();

  	public Projectile projectile;
	private SpriteRenderer spriteRenderer;

	[SerializeField] private float speed = 0f;
	public Rigidbody2D rb = new Rigidbody2D ();

    private bool runOnce = false;
    void Awake () {
		Instance = this;
	}

	public void StartGame () {
		if (GameManager.Instance.currentGameState == GameState.inGame)
			speed = 50f;
	}

	public void ToPlayer2Select () {
		GameManager.Instance.Player2Select ();
	}

	public void SpriteToBlue () {
		spriteRenderer.sprite = sprites[0];
		ToPlayer2Select ();
	}

	public void SpriteToPink () {
		spriteRenderer.sprite = sprites[1];
		ToPlayer2Select ();
	}

	public void SpriteToRed () {
		spriteRenderer.sprite = sprites[2];
		ToPlayer2Select ();
	}

	public void SpriteToGreen () {
		spriteRenderer.sprite = sprites[3];
		ToPlayer2Select ();
	}

    //Upon Projectile Collision, take down player Health and destroy projectile
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile")
            Destroy(other.gameObject);
    }
	void FixedUpdate () {

            if (Input.GetKey(KeyCode.W))
                rb.AddForce(transform.up * speed);
            if (Input.GetKey(KeyCode.S))
                rb.AddForce(transform.up * -speed);
        
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
