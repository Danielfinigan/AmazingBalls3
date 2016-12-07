using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed = 30f;
    // Use this for initialization
    void Awake()
    {
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
    
    public void setSpeed(float s)
    {
        speed = s;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
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
