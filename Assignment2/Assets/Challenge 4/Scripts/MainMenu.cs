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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartNew()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }
    public void HowTO(){
        howtoMenu.SetActive(true);
        mainmenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firsthow);
    }
    public void HowTOreturn(){
        howtoMenu.SetActive(false);
        mainmenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstmain);
    }
}
