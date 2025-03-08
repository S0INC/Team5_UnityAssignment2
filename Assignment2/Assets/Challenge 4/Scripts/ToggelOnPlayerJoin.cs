using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ToggelOnPlayerJoin : MonoBehaviour
{
    private  PlayerInputManager playerInputManager;
    public TMP_Text jointext;
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
        jointext.gameObject.SetActive(false);
    }
}
