using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player1Controller : MonoBehaviour {

	public static Player1Controller Instance;
    public List<Sprite> sprites = new List<Sprite>();
    public Rigidbody2D rb = new Rigidbody2D();
    public Projectile projectile;
    public string color;
    [SerializeField] private float speed = 0f;

    public SpriteRenderer spriteRenderer;
    private const int _maxAmmo = 5;
    public int _ammo = _maxAmmo;    //is public for testing
    private bool _runOnce = true;


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
        color = "blue";
		ToPlayer2Select ();
	}

	public void SpriteToPink () {
		spriteRenderer.sprite = sprites[1];
        color = "pink";
		ToPlayer2Select ();
	}

	public void SpriteToRed () {
		spriteRenderer.sprite = sprites[2];
        color = "red";
		ToPlayer2Select ();
	}

	public void SpriteToGreen () {
		spriteRenderer.sprite = sprites[3];
        color = "green";
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
            _runOnce = true;
        if (fireIsPressed == 1 && _runOnce)
        {
            if(_ammo > 0)
            {
                Fire();
                StartCoroutine(FireRate());
                _runOnce = false;
            }
        }

        if (_ammo > 0)
            StartCoroutine(Reload());
	}

    public IEnumerator FireRate()
    {
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator Reload()
    {
        while (_ammo < _maxAmmo)
        {
            yield return new WaitForSeconds(1f);
            _ammo++;
        }
    }
}
