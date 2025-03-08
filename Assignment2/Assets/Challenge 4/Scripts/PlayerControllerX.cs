using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 500;
    public float boost = 1;
    public GameObject focalPoint;
    public ParticleSystem dustParticle;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    public bool isPlayer1 = true; 
    private Vector2 movementInput = Vector2.zero;
    private bool boosted = false;
    public RotateCameraX rotateCameraX;
    public PauseMenu pauseMenu;
    public ParticleSystem powerUpIndicator;
    public Camera playerCamera;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate the camera's forward and right vectors (ignoring the y-axis for horizontal movement)
        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;

        // Set the y-components of the forward and right vectors to 0 to ignore vertical movement
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize them so we don't get scaling issues
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction relative to the camera's orientation
        Vector3 move = cameraForward * movementInput.y + cameraRight * movementInput.x;

        // Apply the force to the player in the direction relative to the camera
        playerRb.AddForce(move * speed * Time.deltaTime);
        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

        // on spacebar press gives a boost to the player
        if (boosted){
            BoostOnSpace(boost);
            dustParticle.Play();
        }
        if (hasPowerup){
            powerUpIndicator.transform.position = transform.position;
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerUpIndicator.gameObject.SetActive(true);
            // starts a coroutine to time the deration of the powerUp
            StartCoroutine(PowerupCooldown());
        }
    }

    public void OnMove(InputAction.CallbackContext context){
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnBoost(InputAction.CallbackContext context){
        boosted = context.action.triggered;
    }
    public void Onrotate(InputAction.CallbackContext context){
        rotateCameraX.rotationInput = context.ReadValue<Vector2>();
    }
    public void OnPauseAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            pauseMenu.checkpause = true;
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }

    // Adds ipulse force to the Player (boost)
    private void BoostOnSpace(float boostMod){
        // takes the forward of the focal point and adds an impulse with the boost float
        playerRb.AddForce(focalPoint.transform.forward * boostMod, ForceMode.Impulse);
    }
}