using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed = 25f;
    
    // Use this for initialization
    void Awake()
    {
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        GetComponent<Rigidbody2D>().velocity = new Vector2(30f, 0);
    }
    
	// Update is called once per frame
	void Update ()
    {
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
    }
}
