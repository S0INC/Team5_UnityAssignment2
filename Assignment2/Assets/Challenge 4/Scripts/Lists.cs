using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Lists : MonoBehaviour
{
    public List<PlayerInput> players = new List<PlayerInput>();
    public List<Transform> startingPoints;
    public static Lists instance;
    void Awake()
    {
        instance = this;
    }
}
