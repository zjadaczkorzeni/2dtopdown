using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public bool handgun = true;
    public bool rifle;
    public bool isReloading = false;
    public int hp;
    public int hpMax=10;
    public float speed = 1f;
    public float ammo=10;
    public float clipSize = 10;
    public float fireRate = 1f;
    public float rifleStats = 3;
    public float reloadTime = 2f;
    public GameObject Bullet;
    public GameObject Barrel;
    public float currentTime = 0f;
    private Collider2D rb;
    public AudioSource gunshot;
    public AudioSource gunreload;
    public AudioSource argh;
    public AudioSource death;
    public Camera camera;
    public int score = 0;
    public Image ammoBar;
    public Image healthBar;
    public Text scoreDisp;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Collider2D>();
        hp = hpMax;
    }
    // Update is called once per frame
    void Update()
    {
        if (hp > 0)
        {
            
            handgun = rifle ? false : true;

            anim.SetBool("idle", Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 ? false : true);
            anim.SetBool("isWalking", Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 ? true : false);
            anim.SetBool("rifle", rifle);
            anim.SetBool("isReloading", isReloading);

            if (Input.GetAxis("Horizontal") < 0)
                transform.position += Vector3.left * speed * Time.deltaTime;
            if (Input.GetAxis("Horizontal") > 0)
                transform.position += Vector3.right * speed * Time.deltaTime;
            if (Input.GetAxis("Vertical") > 0)
                transform.position += Vector3.up * speed * Time.deltaTime;
            if (Input.GetAxis("Vertical") < 0)
                transform.position += Vector3.down * speed * Time.deltaTime;

            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousPosInworld = camera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(Input.mousePosition + " -> " + mousPosInworld);
            Debug.DrawLine(transform.position, mousPosInworld, Color.red);
            Vector3 targetDir = mousPosInworld - transform.position;

            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle+3, Vector3.forward);

            
            if (ammo <= 0|| Input.GetButtonDown("Reload")==true)
            {
                gunreload.Play();
                anim.SetTrigger("Reload");
                ammo = clipSize;
                isReloading = true;

            }
            if (isReloading == true)
                Invoke("reload", reloadTime);
            currentTime += Time.deltaTime;

            if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))
                if (isReloading != true && currentTime >= fireRate)
                {
                    gunshot.Play();
                    ammo--;
                    currentTime = currentTime % fireRate;
                    GameObject spawnedBullet = Instantiate(Bullet, Barrel.transform.position, Quaternion.Euler(Barrel.transform.eulerAngles));
                    spawnedBullet.GetComponent<Bullet>().direction = Barrel.transform.right;
                }
        }
        else
        {
            anim.SetBool("isDead", true);
            Destroy(rb);
            if (hp<=0&&hp>-3)
            {
                death.Play();
                scoreDisp.text = "you have killed " + score.ToString() +" zombies";
                hp -= 4;
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
        healthBar.fillAmount = ((float)hp/(float)hpMax);
        ammoBar.fillAmount = ((float)ammo / (float)clipSize);

    }

    public void reload()
    {
        isReloading = false;
        CancelInvoke();     
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Zombie")
        {
            hp--;
            argh.Play();
        }
        if (coll.collider.tag == "Rifle")
        {
            rifle = true;
            clipSize *= rifleStats;
            ammo = clipSize;
            fireRate /= (1.5f* rifleStats);
            Zombie.rifleDrop = false;

        }
    }

}

 


