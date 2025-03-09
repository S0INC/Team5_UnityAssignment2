using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using NUnit.Framework;

public class ToggelOnPlayerJoin : MonoBehaviour
{
    private  PlayerInputManager playerInputManager;
    private void Awake()
    {
        playerInputManager = FindFirstObjectByType<PlayerInputManager>();
    }
    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += ToggleThis;
    }
    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= ToggleThis;
    }
    private void ToggleThis(PlayerInput player){
        this.gameObject.SetActive(false);
        PauseMenu.instance.ClearText();
        CounterDownTimer.instance.StartTimer();
        Lists.instance.players.Add(player);
        player.transform.position = Lists.instance.startingPoints[Lists.instance.players.Count - 1].position;
        player.transform.rotation = Lists.instance.startingPoints[Lists.instance.players.Count - 1].transform.rotation;
    }
}
