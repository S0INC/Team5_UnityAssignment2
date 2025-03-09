using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public GameObject howtoMenu;
    public GameObject mainmenu;
    public GameObject firstmain;
    public GameObject firsthow;
    MainAudio mainAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mainAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<MainAudio>();
    }
    public void StartNew()
    {
        mainAudio.PlaySFX(mainAudio.ButtonSelect);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        mainAudio.PlaySFX(mainAudio.ButtonSelect);
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }
    public void HowTO(){
        mainAudio.PlaySFX(mainAudio.ButtonSelect);
        howtoMenu.SetActive(true);
        mainmenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firsthow);
    }
    public void HowTOreturn(){
        mainAudio.PlaySFX(mainAudio.ButtonSelect);
        howtoMenu.SetActive(false);
        mainmenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstmain);
    }
}
