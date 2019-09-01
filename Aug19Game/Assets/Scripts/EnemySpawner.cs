using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints; //transform is used for objects that you will do something like translate or move 
    public GameObject[] enemyPrefab;

    private float timeToSpawn =2f;
    public float timeBtwnWaves = 5f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn )
        {
            SpawningWaves();
            timeToSpawn = Time.time + timeBtwnWaves;
            timeBtwnWaves -= 0.5f;

            if (timeBtwnWaves <= 1.5f)
            {
                timeBtwnWaves = 1.5f;
            }
            //Debug.Log(timeBtwnWaves);
        }

    }

    void SpawningWaves()
    {
        int randomIndex1 = Random.Range(0, spawnPoints.Length);
        int randomIndex2 = Random.Range(0, enemyPrefab.Length);

        for(int i=0; i < spawnPoints.Length ; i++){

            if (randomIndex1 != i){

                Instantiate(enemyPrefab[randomIndex2], spawnPoints[i].position, Quaternion.identity);
            }
            randomIndex2 = Random.Range(0, enemyPrefab.Length);
        }
    }
}
