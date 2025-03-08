using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCameraX : MonoBehaviour
{
    private float speed = 150;
    public GameObject player;
    public Vector2 rotationInput = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime * rotationInput.x);

        transform.position = player.transform.position; // Move focal point with player

    }
    
}
