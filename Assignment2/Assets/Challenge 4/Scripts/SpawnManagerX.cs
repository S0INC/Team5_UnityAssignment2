using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int waveCount = 1;
    public GameObject playerGoal;
    public ParticleSystem goalExplosion;
    public ParticleSystem ghostExplosion;

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave();
        }

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 1, zPos);
    }


    void SpawnEnemyWave()
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
            var enemyObject = Instantiate(enemyPrefab, new Vector3(0,0,0), enemyPrefab.transform.rotation);
            // gets the EnemyX script           
            EnemyX enemyX = enemyObject.GetComponent<EnemyX>();
            // refrences the player goal object so we can reference it EnemyX
            enemyX.playerGoal = playerGoal;
            // refernces the script so we can use it in the EnemyX script
            enemyX.spawnManagerX = this;
            // referces so we can get the text element to the enemy Prefab
            enemyX.goalExplosionFX = goalExplosion;
            enemyX.ghostExplosionFX = ghostExplosion;
        waveCount++;
        ResetPlayerPosition(); // put player back at start

    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        for (int i = 0; i < Lists.instance.players.Count; i++){
            Lists.instance.players[i].transform.position = Lists.instance.startingPoints[i].position;
            Lists.instance.players[i].GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            Lists.instance.players[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

}
