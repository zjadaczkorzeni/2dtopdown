using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour {

    bool weapon = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        weapon = GameObject.Find("Player").GetComponent<Player>().rifle;
        if (weapon)
            Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    }
