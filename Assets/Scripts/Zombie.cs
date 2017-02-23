using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int hp;
    public float speed = 1f;
    public float rotationSpeed = 2f;
    public float corpseTime = 5f;
    Animator anim;
    private Vector3 spawnPosition;
    public Transform target;
    bool isDead = false;
    private Collider2D rb;
    public GameObject Rifle;
    public int rifle;
    public bool weapon;
    public GameObject Blood;
    public static Player playerInstance;
    public static bool rifleDrop = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Collider2D>();
        playerInstance = GameObject.Find("Player").GetComponent<Player>();

    }


    // Update is called once per frame
    void Update()
    {

        weapon = playerInstance.rifle;

        if (hp <= 0)
        {
            isDead = true;
            anim.SetBool("isDead", true);
            Destroy(gameObject, corpseTime);
            Destroy(rb);
            Vector3 deadPosition = new Vector3(transform.position.x, transform.position.y, -0.5f);
            transform.position = deadPosition;            
            if (rifle == 0 && weapon==false)
                RifleSpawn();
            
        }
        if (isDead == false)
        {

            Vector3 dir = target.position - transform.position;
            dir.z = 0.0f;
            transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
        }
      

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Bullet")
        {
            hp--;
            Instantiate(Blood, transform.position, transform.rotation);
        }
    }
    
    void RifleSpawn()
    {
        if(!rifleDrop) {
            Instantiate(Rifle, transform.position, transform.rotation);
            rifle = 1;
            rifleDrop = true;
        }
    }
}