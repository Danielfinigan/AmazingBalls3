using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    private float speed;
    private SpriteRenderer projectileSprite;
    public float Speed
        {
           get
            {
            return speed;
            }
            set
            {
            speed = value;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        }
    public SpriteRenderer ProjectileSprite
    {
        get
        {
            return projectileSprite;
        }
        set
        {
            projectileSprite = value;
            GetComponent<SpriteRenderer>().sprite = projectileSprite.sprite;
        }
    }

    // Use this for initialization
    void Awake()
    {
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Start()
    {
        projectileSprite = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update ()
    {

    }
}
