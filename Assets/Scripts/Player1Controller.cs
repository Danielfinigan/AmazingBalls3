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
    private SpriteRenderer projectileRenderer;
    private const int _maxAmmo = 5;
    public int _ammo = _maxAmmo;    //is public for testing
   // private float fireIsPressed;
    [SerializeField] private bool _runOnce = true;
    [SerializeField] private bool _canFire = true;
    private IEnumerator _reload;


    void Awake () {
		Instance = this;
        _canFire = true;
        _reload = Reload();
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
        projectileRenderer.sprite = sprites[0];
        color = "blue";
		ToPlayer2Select ();
	}

	public void SpriteToPink () {
		spriteRenderer.sprite = sprites[1];
        projectileRenderer.sprite = sprites[1];
        color = "pink";
		ToPlayer2Select ();
	}

	public void SpriteToRed () {
		spriteRenderer.sprite = sprites[2];
        projectileRenderer.sprite = sprites[2];
        color = "red";
		ToPlayer2Select ();
	}

	public void SpriteToGreen () {
		spriteRenderer.sprite = sprites[3];
        projectileRenderer.sprite = sprites[3];
        color = "green";
		ToPlayer2Select ();
	}

    //Upon Projectile Collision, take down player Health and destroy projectile


	void FixedUpdate () {

            if (Input.GetKey(KeyCode.W))
                rb.AddForce(transform.up * speed);
            if (Input.GetKey(KeyCode.S))
                rb.AddForce(transform.up * -speed);        
    }

    void Fire()
    {        
        //Fires a projectile
        if (_canFire)
        {
            Projectile projectileClone;
            Vector2 spawnPosition = new Vector2(Instance.transform.position.x + 1f, Instance.transform.position.y);
            projectileClone = (Projectile)Instantiate(projectile, spawnPosition, Quaternion.identity);
            projectileClone.Speed = 30f;
            projectileClone.ProjectileSprite = projectileRenderer;
            _ammo--;
        }      
    }

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
        projectileRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        bool fireIsPressed = Input.GetKey(KeyCode.D);   //checks if the fire key is pressed
        bool reloadIsPressed = Input.GetKey(KeyCode.R); //checks if the reload key is pressed

        if (!fireIsPressed && !reloadIsPressed)
            _runOnce = true;
        else if (fireIsPressed && _runOnce)
        {
            if(_ammo > 0)
            {
                Fire();
                _runOnce = false;
            }
        }
        else if (reloadIsPressed && _runOnce)
        {
            _reload = Reload();
            StartCoroutine(_reload);
            _runOnce = false;
        }
	}
    
    //Reloads projectiles when a button is pressed
    public IEnumerator Reload()
    {
        _canFire = false;
        while (_ammo < _maxAmmo)
        {
            yield return new WaitForSeconds(1f);
            _ammo++;
        }
        _canFire = true;
    }
    //Reloads a projectile once a second
   /* public IEnumerator Reload()
    {
        //waits 2 seconds since the last projectile fired before reloading begins
        yield return new WaitForSeconds(2f);
        while(_ammo < _maxAmmo)
        {
            yield return new WaitForSeconds(1f);
            _ammo++;
        }
        _doneReloading = true;
        _canFire = true;
    }*/
}
