using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Collections;

public class CounterDownTimer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI TimerText;
    public static CounterDownTimer instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimerOn = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn){
            if (TimeLeft > 0){
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else{
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }
    void UpdateTimer(float currentTime){
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
    
    IEnumerator PauseTimerCoroutine(){
        TimerOn = false;
        yield return new WaitForSeconds(3f);
        TimerOn = true;
    }

    public void PauseTimer()
    {
        StartCoroutine(nameof(PauseTimerCoroutine));
    }
}
