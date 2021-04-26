using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instanceSceneManager;

    public static ScenesManager Instance { get { return instanceSceneManager; } }

    [SerializeField]private string actualScene;

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
        GoToMenu();
    }

    public void GoToMenu()
    {
        if(actualScene == "Credits" || actualScene == "HowToPlay")
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Menu");
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
