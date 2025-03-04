using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    public GameObject playerGoal;
    public SpawnManagerX spawnManagerX;
    public Renderer rend;
    public ParticleSystem goalExplosionFX;
    public ParticleSystem ghostExplosionFX;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        // Increases the speed based on the wave number from the SpawnManagerX script
        // Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        // enemyRb.AddForce(lookDirection * speed * Time.deltaTime * (spawnManagerX.waveCount * 0.4f));

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            ScoreManager.instance.addPointP1();
            rend.enabled = false;
            CounterDownTimer.instance.PauseTimer();
            DOTween.Restart("move_textIn");
            CameraShake.instance.Shake();
            StartCoroutine(ghostExplosion());
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            ScoreManager.instance.addPointP2();
            rend.enabled = false;
            CounterDownTimer.instance.PauseTimer();
            DOTween.Restart("move_textIn");
            CameraShake.instance.Shake();
            StartCoroutine(goalExplosion());
        }

    }

    IEnumerator goalExplosion(){
        goalExplosionFX.transform.position = new Vector3(gameObject.transform.position.x, 0 , gameObject.transform.position.z);
        goalExplosionFX.Play();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    IEnumerator ghostExplosion(){
        ghostExplosionFX.transform.position = new Vector3(gameObject.transform.position.x, 0 , gameObject.transform.position.z);
        ghostExplosionFX.Play();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
