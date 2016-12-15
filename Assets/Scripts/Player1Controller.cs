using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Image=UnityEngine.UI.Image;

public class Player1Controller : MonoBehaviour {

	public static Player1Controller Instance;
    public List<Sprite> sprites = new List<Sprite>();
    public Rigidbody2D rb = new Rigidbody2D();
    public Projectile projectile;
    public string color;
    [SerializeField] private float speed = 0f;
    public SpriteRenderer ballRenderer;
    public const int _maxAmmo = 5;

	public int health;
	Image healthbar1;

    public int _ammo = _maxAmmo;    //is public for testing
    private SpriteRenderer projectileRenderer;
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
			speed = 100f;
	}

	public void ToPlayer2Select () {
		GameManager.Instance.Player2Select ();
	}

	public void SpriteToBlue () {
        ballRenderer.sprite = sprites[0];
        projectileRenderer.sprite = sprites[0];
        projectile.ProjectileSprite = projectileRenderer;
        color = "blue";
		ToPlayer2Select ();
	}

	public void SpriteToPink () {
        ballRenderer.sprite = sprites[1];
        projectileRenderer.sprite = sprites[1];
        projectile.ProjectileSprite = projectileRenderer;
        color = "pink";
		ToPlayer2Select ();
	}

	public void SpriteToRed () {
        ballRenderer.sprite = sprites[2];
        projectileRenderer.sprite = sprites[2];
        projectile.ProjectileSprite = projectileRenderer;
        color = "red";
		ToPlayer2Select ();
	}

	public void SpriteToGreen () {
        ballRenderer.sprite = sprites[3];
        projectileRenderer.sprite = sprites[3];
        projectile.ProjectileSprite = projectileRenderer;
        color = "green";
		ToPlayer2Select ();
	}

    //Upon Projectile Collision, take down player Health and destroy projectile
	void OnCollisionEnter2D (Collision2D col)
    {

		if(col.gameObject.tag == "Projectile")
        {
            AudioSource playerHit = GetComponent<AudioSource>();
            playerHit.Play();
			this.health = this.health - 1;
			healthbar1.fillAmount = healthbar1.fillAmount - 0.2f;
		}
    }

	void FixedUpdate () {
		Debug.Log ("Fixupdate is running");
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
			CameraShake.Instance.Shake ();
            ViewInGame.instance.Fired(1, _ammo);
            _ammo--;
        }      
    }

	// Use this for initialization
	void Start () {
        ballRenderer = GetComponent<SpriteRenderer> ();
        projectileRenderer = GetComponent<SpriteRenderer>();
		this.health = 5;
		healthbar1 = GameObject.Find ("UI").transform.FindChild ("InGameScreenPanel").FindChild ("Player1Ammo").FindChild("Healthbar1").GetComponent<Image> ();
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
///////////////////////////////////////////////////////////////////////////////
		if (this.health == 0)
		{
			Destroy(this.gameObject);
            GameManager.Instance.playerWon = "Player 2 has won!";
			GameManager.Instance.NextLevel();
		}
	}
    
    //Reloads projectiles when a button is pressed
    public IEnumerator Reload()
    {
        _canFire = false;
        while (_ammo < _maxAmmo)
        {
            yield return new WaitForSeconds(.5f);
            ViewInGame.instance.Reload(1, _ammo);
            _ammo++;
        }
        _canFire = true;
    }
}
