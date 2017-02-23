using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float speed = 1.5f;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update () {
        Vector3 dir = target.position - transform.position;
        dir.z = 0.0f;
        transform.position += dir * speed * Time.deltaTime;
        Vector3 maxPos = new Vector3(7.8f, 0, -10);
        Vector3 minPos = new Vector3(-0.1f, -4.2f, -10);
        if (transform.position.x >= maxPos.x)
            transform.position = new Vector3(maxPos.x, transform.position.y, transform.position.z);
        if (transform.position.y >= maxPos.y)
            transform.position = new Vector3(transform.position.x, maxPos.y, transform.position.z);
        if (transform.position.x <= minPos.x)
            transform.position = new Vector3(minPos.x, transform.position.y, transform.position.z);
        if(transform.position.y <= minPos.y)
            transform.position = new Vector3(transform.position.x, minPos.y, transform.position.z);
    }
}
