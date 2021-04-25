using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instancePlayerManager;

    public static PlayerManager Instance { get { return instancePlayerManager; } }

    [SerializeField] public float health { get; set; }
    [SerializeField] public float keys { get; set; }
    [SerializeField] public float smallTorch { get; set; }
    [SerializeField] public float freezeGhost { get; set; }
    [SerializeField] public float rechargeMagic { get; set; }
    [SerializeField] public float bigTorch { get; set; }
    [SerializeField] public float digGrave { get; set; }
    [SerializeField] public float liberateTrap { get; set; }


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
