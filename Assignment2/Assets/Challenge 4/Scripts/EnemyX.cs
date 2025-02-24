using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    public GameObject playerGoal;
    public SpawnManagerX spawnManagerX;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        // Increases the speed based on the wave number from the SpawnManagerX script
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime * (spawnManagerX.waveCount * 0.4f));

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            ScoreManager.instance.addPointP1();
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            ScoreManager.instance.addPointP2();
            Destroy(gameObject);
        }

    }

}
