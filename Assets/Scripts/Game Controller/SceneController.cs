using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController SceneControllerInstance;

    [SerializeField] private float waitTime = 1f;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject menuPanel;

    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(SceneControllerInstance != null && SceneControllerInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            SceneControllerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void LoadNextScene(){ SceneManager.LoadScene(currentSceneIndex + 1); }
    public void ReloadScene() { SceneManager.LoadScene(currentSceneIndex); }

    public void LoadStartScene()
    {
        var GC = GameObject.Find("Game Controller");
        GC.GetComponent<Scoring>().Reset();
        SceneManager.LoadScene(0);
        SwitchPanel(true);
    }
    public void LoadGameScene()
    { 
        SceneManager.LoadScene(1);
        SwitchPanel(false);
    }
    public void LoadGameOver()
    { 
        StartCoroutine(WaitAndLoad(waitTime));
    }
    IEnumerator WaitAndLoad(float time)
    {
        yield return new WaitForSeconds(time);
        
        SceneManager.LoadScene("GameOverScene");
    }
    public void QuitGame() { Application.Quit();}

    private void SwitchPanel(bool isMenu)
    {
        gamePanel.SetActive(!isMenu);
        menuPanel.SetActive(isMenu);
    }
}