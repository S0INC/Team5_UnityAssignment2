using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class CameraShake : MonoBehaviour
{
    public ShakeData MyShake;
    public static CameraShake instance;

    void Awake()
    {
        instance = this;
    }

    public void Shake(){
        CameraShakerHandler.Shake(MyShake);
    }
}