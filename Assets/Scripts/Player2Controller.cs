using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Image=UnityEngine.UI.Image;

public class Player2Controller : MonoBehaviour {

	public static Player2Controller Instance;
    public List<Sprite> sprites = new List<Sprite>();
    public Rigidbody2D rb = new Rigidbody2D();
    public Projectile projectile;
    public string color;
    [SerializeField] private float speed;
    public SpriteRenderer ballRenderer;
    public const int _maxAmmo = 5;

	public int health;
	Image healthbar2;

    public int _ammo = _maxAmmo;    //public for testing
    private SpriteRenderer projectileRenderer;
    [SerializeField]
    private bool _runOnce = true;
    [SerializeField]
    private bool _canFire = true;
    private IEnumerator _reload;

    void Awake () {
		Instance = this;
	}

	public void StartGame () {
		if (GameManager.Instance.currentGameState == GameState.inGame)
			speed = 100f;
	}

	public void ToGame () {
		GameManager.Instance.StartGame ();
	}

	public void SpriteToBlue () {
		ballRenderer.sprite = sprites[0];
        projectileRenderer.sprite = sprites[0];
        projectile.ProjectileSprite = projectileRenderer;
        color = "blue";
        ToGame ();
	}

	public void SpriteToPink () {
		ballRenderer.sprite = sprites[1];
        projectileRenderer.sprite = sprites[1];
        projectile.ProjectileSprite = projectileRenderer;
        color = "pink";
        ToGame ();
	}

	public void SpriteToRed ()
    {
        ballRenderer.sprite = sprites[2];
        projectileRenderer.sprite = sprites[2];
        projectile.ProjectileSprite = projectileRenderer;
        color = "red";
        ToGame ();
	}

	public void SpriteToGreen () {
		ballRenderer.sprite = sprites[3];
        projectileRenderer.sprite = sprites[3];
        projectile.ProjectileSprite = projectileRenderer;
        color = "green";
        ToGame ();
    }

    //Upon Projectile Collision, take down player Health and destroy projectile
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            AudioSource playerHit = GetComponent<AudioSource>();
            playerHit.Play();
            this.health = this.health - 1;
            healthbar2.fillAmount = healthbar2.fillAmount - 0.2f;
        }

        /*if (this.health == 0)
        {
            Destroy(this.gameObject);
			GameManager.Instance.NextLevel();
			Debug.Log ("health reached zero");
        }*/
    }

    void FixedUpdate () {
		if (Input.GetKey (KeyCode.UpArrow))
			rb.AddForce (transform.up * speed);
		if (Input.GetKey (KeyCode.DownArrow))
			rb.AddForce (transform.up * -speed);
	}

    void Fire()
    {
        //Fires a projectile
        if (_canFire)
        {
            Projectile projectileClone;
            Vector2 spawnPosition = new Vector2(Instance.transform.position.x - 1f, Instance.transform.position.y);
            projectileClone = (Projectile)Instantiate(projectile, spawnPosition, Quaternion.identity);
            projectileClone.Speed = -30f;
			CameraShake.Instance.Shake ();
            ViewInGame.instance.Fired(2, _ammo);
            _ammo--;
        }
    }

    // Use this for initialization
    void Start()
    {
        ballRenderer = GetComponent<SpriteRenderer>();
        projectileRenderer = GetComponent<SpriteRenderer>();
		this.health = 5;
		healthbar2 = GameObject.Find ("UI").transform.FindChild ("InGameScreenPanel").FindChild ("Player2Ammo").FindChild("Healthbar2").GetComponent<Image> ();
    }

    // Update is called once per frame
    void Update()
    {
        bool fireIsPressed = Input.GetKey(KeyCode.LeftArrow);       //checks if the fire key is pressed
        bool reloadIsPressed = Input.GetKey(KeyCode.RightControl);   //checks if the reload key is pressed

        if (!fireIsPressed && !reloadIsPressed)
            _runOnce = true;
        else if (fireIsPressed && _runOnce)
        {
            if (_ammo > 0)
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

////////////////////////////////////////////////////////////////////////////
		if (this.health == 0)
		{
			Destroy(this.gameObject);
            GameManager.Instance.playerWon = "Player 1 has won!";
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
            ViewInGame.instance.Reload(2, _ammo);
            _ammo++;
        }
        _canFire = true;
    }
}
