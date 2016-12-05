using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed = 1.5f;
    
    // Use this for initialization
    void Awake()
    {
        
    }
    
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
}
