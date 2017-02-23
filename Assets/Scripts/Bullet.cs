using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 1;
    private Rigidbody2D rb;
    public Vector2 direction;
    

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed*Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 1);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
        
    }
}
