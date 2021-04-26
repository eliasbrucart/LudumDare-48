using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instancePlayerManager;

    public static PlayerManager Instance { get { return instancePlayerManager; } }

    public float health;
    public float keys;
    public float smallTorch;
    public float freezeGhost;
    public float bigTorch;

    public Image keyImage;
    [SerializeField] private string actualScene;

    private void Awake()
    {
        if(instancePlayerManager != null && instancePlayerManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instancePlayerManager = this;
        }
    }
   

    void Update()
    {
        if (keys >= 1)
            keyImage.gameObject.SetActive(true);
        else
            keyImage.gameObject.SetActive(false);

        if(health <= 0)
        {
            SceneManager.LoadScene(actualScene);
        }
    }

}
