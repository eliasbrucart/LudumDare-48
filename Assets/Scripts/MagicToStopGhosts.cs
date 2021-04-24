using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicToStopGhosts : MonoBehaviour
{
    public GameObject[] Ghost;

    PlayerManager manager;
    public float TimeToGoBackToMove;
    [SerializeField] float time;
    bool isActive = false;
    void Start()
    {
        manager = this.GetComponent<PlayerManager>();
        time = TimeToGoBackToMove;
    }
    void Update()
    {
        if (isActive == true)
        {
            time -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (manager.GetSkill2() >= 1)
            {
                isActive = true;
                manager.SetSkill2(manager.GetSkill2() - 1);
                for (int i = 0; i < 10; i++)
                {
                    Ghost[i].GetComponent<GhostMovment>().enabled = false;
                }
            }
        }
        if (time <= 0 && isActive == true)
        {
            isActive = false;
            time = TimeToGoBackToMove;
            for (int i = 0; i < 10; i++)
            {
                Ghost[i].GetComponent<GhostMovment>().enabled = true;
            }
        }
    }
}
