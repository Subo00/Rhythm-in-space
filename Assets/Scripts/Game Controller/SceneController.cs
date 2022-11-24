using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private float waitTime = 1f;

    private int currentSceneIndex;
    void Start(){ currentSceneIndex = SceneManager.GetActiveScene().buildIndex;  }
    public void LoadNextScene(){ SceneManager.LoadScene(currentSceneIndex + 1); }
    public void ReloadScene() { SceneManager.LoadScene(currentSceneIndex); }
    public void LoadStartScene(){ SceneManager.LoadScene(0); }
    public void LoadGameScene()
    { 
        SceneManager.LoadScene(1);
        //FindObjectOfType<Score>().ResetScore();
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
}