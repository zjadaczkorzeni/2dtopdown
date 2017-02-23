using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Zombie zombie;
	public float spawnTime = 2f;
    public float currentTime=0;
    public float spawnDeltaTime=0.05f;
    public float minSpawnTime=0.85f;
    public static Player playerInstance;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn",0, spawnTime);
        playerInstance = GameObject.Find("Player").GetComponent<Player>();

    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (playerInstance.rifle)
        {
            if (currentTime > spawnTime)
            {
                Spawn();
                currentTime = 0;
                spawnTime -= spawnDeltaTime;
                if (spawnTime < minSpawnTime)
                    spawnTime = minSpawnTime;
            }
        }
    }

    void Spawn()
	{
        if (playerInstance.hp > 0)
        {
            Vector3 spawnPosition = new Vector3();
            spawnPosition.x = Random.Range(-5, 8);
            spawnPosition.y = Random.Range(-5, 3);
            spawnPosition.z = -1;
            Zombie temp = Instantiate<Zombie>(zombie, spawnPosition, transform.rotation);
            temp.hp = Random.Range(1, 5);
            temp.rifle = Random.Range(0, 7);
        }


    }
}
