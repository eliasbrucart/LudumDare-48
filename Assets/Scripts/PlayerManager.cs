using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instancePlayerManager;

    public static PlayerManager Instance { get { return instancePlayerManager; } }

    public float health;
    public float keys;
    public float smallTorch;
    public float freezeGhost;
    public float rechargeMagic;
    public float bigTorch;
    public float digGrave;
    public float liberateTrap;


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
        
    }

}
