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
        anim.Play("Blood" + shape);
    }

    // Update is called once per frame
    void Update () {
        
    }
}
