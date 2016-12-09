using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player2Controller : MonoBehaviour {

	public static Player2Controller Instance;
    public List<Sprite> sprites = new List<Sprite>();
    public Rigidbody2D rb = new Rigidbody2D();
    public Projectile projectile;
    public string color;
    [SerializeField] private float speed;
    public SpriteRenderer ballRenderer;
    public const int _maxAmmo = 5;

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
			speed = 50f;
	}

	public void ToGame () {
		GameManager.Instance.StartGame ();
	}

	public void SpriteToBlue () {
		ballRenderer.sprite = sprites[0];
        projectileRenderer.sprite = sprites[0];
        color = "blue";
        ToGame ();
	}

	public void SpriteToPink () {
		ballRenderer.sprite = sprites[1];
        projectileRenderer.sprite = sprites[1];
        color = "pink";
        ToGame ();
	}

	public void SpriteToRed ()
    {
        projectileRenderer.sprite = sprites[2];
        ballRenderer.sprite = sprites[2];
        color = "red";
        ToGame ();
	}

	public void SpriteToGreen () {
		ballRenderer.sprite = sprites[3];
        projectileRenderer.sprite = sprites[3];
        color = "green";
        ToGame ();
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
            projectileClone.ProjectileSprite = projectileRenderer;
            ViewInGame.instance.Fired(2, _ammo);
            _ammo--;
        }
    }

    // Use this for initialization
    void Start()
    {
        ballRenderer = GetComponent<SpriteRenderer>();
        projectileRenderer = GetComponent<SpriteRenderer>();
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
    }

    //Reloads projectiles when a button is pressed
    public IEnumerator Reload()
    {
        _canFire = false;
        while (_ammo < _maxAmmo)
        {
            yield return new WaitForSeconds(1f);
            ViewInGame.instance.Reload(2, _ammo);
            _ammo++;
        }
        _canFire = true;
    }
}
