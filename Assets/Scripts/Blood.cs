using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {

    Animator anim;
    public int shape;
    public SpriteRenderer spriteR;
    public Sprite[] sprites;
    void Start () {

        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, -0.1f);
        transform.position = spawnPosition;
        sprites = Resources.LoadAll<Sprite>("blood");
        shape = Random.Range(0, 8);
        spriteR.sprite = sprites[shape];
        /*switch (shape)
        {
            case 0:
                spriteR.sprite = sprites[0];
                break;
            case 1:
                spriteR.sprite = sprites[1];
                break;
            case 2:
                spriteR.sprite = sprites[2];
                break;
            case 3:
                spriteR.sprite = sprites[3];
                break;
        }
        */
        /*
        switch (shape)
        {
            case 0:
                anim.Play("Blood0");
                break;
            case 1:
                anim.Play("Blood1");
                break;
            case 2:
                anim.Play("Blood2");
                break;
            case 3:
                anim.Play("Blood3");
                break;
        }*/
        anim.Play("Blood" + shape);
    }

    // Update is called once per frame
    void Update () {
        
    }
}
