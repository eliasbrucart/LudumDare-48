using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instanceSceneManager;

    public static ScenesManager Instance { get { return instanceSceneManager; } }

    [SerializeField]private string actualScene;
    private float timeToChangeScene;

    private void Awake()
    {
        if (instanceSceneManager != null && instanceSceneManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanceSceneManager = this;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        timeToChangeScene += Time.deltaTime;
        GoToMenu();
        TransitionToPlay();
    }

    public void GoToMenu()
    {
        if(actualScene == "HowToPlay" || actualScene == "FinalScene" || actualScene == "SoundCredits")
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (actualScene == "Credits")
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("SoundCredits");
            }
        }
    }

    private void TransitionToPlay()
    {
        if (actualScene == "Intro")
        {
            if (timeToChangeScene >= 10.0f)
            {
                timeToChangeScene = 0.0f;
                SceneManager.LoadScene("Level 1");              
            }
        }
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
