using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeMagic : MonoBehaviour
{
    PlayerManager manager;

    public int RechargeValue;
    void Start()
    {
        manager = this.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (manager.rechargeMagic >= 1)
            {
                manager.rechargeMagic -= 1;
                manager.liberateTrap += RechargeValue;
                manager.smallTorch += RechargeValue;
                manager.bigTorch += RechargeValue;
                manager.digGrave += RechargeValue;
                manager.freezeGhost += RechargeValue;
            }
        }
    }
}
