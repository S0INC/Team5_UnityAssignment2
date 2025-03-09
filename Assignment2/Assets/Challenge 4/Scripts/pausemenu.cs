using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject introText;
    public bool checkpause = false;
    public static PauseMenu instance;
    GameAudio gameAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<GameAudio>();
        instance = this;
    }

    void Update()
    {
        if (checkpause)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        gameAudio.PlaySFX(gameAudio.ButtonSelect);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        checkpause = false;
    }
    void Pause()
    {
        gameAudio.PlaySFX(gameAudio.ButtonSelect);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        checkpause = false;
    }
    public void ReturnMain()
    {
        gameAudio.PlaySFX(gameAudio.ButtonSelect);
        SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        gameAudio.PlaySFX(gameAudio.ButtonSelect);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        gameAudio.PlaySFX(gameAudio.ButtonSelect);
        Application.Quit();
    }
    public void ClearText(){
        introText.SetActive(false);
    }
}