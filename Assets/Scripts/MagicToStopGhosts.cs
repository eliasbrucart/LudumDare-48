using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MagicToStopGhosts : MonoBehaviour
{
    public GameObject[] Ghost;

    PlayerManager manager;
    public float TimeToGoBackToMove;
    [SerializeField] float time;
    bool isActive = false;

    public AudioSource freezeGhost;
    public AudioSource noCharge;
    void Start()
    {
        manager = this.GetComponent<PlayerManager>();
        time = TimeToGoBackToMove;
    }
    void Update()
    {
        Ghost = GameObject.FindGameObjectsWithTag("ghost");
        if (isActive == true)
        {
            time -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (manager.freezeGhost >= 1)
            {
                freezeGhost.Play();
                isActive = true;
                manager.freezeGhost -= 1;
                for (int i = 0; i < Ghost.Length; i++)
                {
                    Ghost[i].GetComponent<GhostMovment>().enabled = false;
                }
            }
            else
            {
                noCharge.Play();
            }
        }
        if (time <= 0 && isActive == true)
        {
            freezeGhost.Pause();
            isActive = false;
            time = TimeToGoBackToMove;
            for (int i = 0; i < 10; i++)
            {
                Ghost[i].GetComponent<GhostMovment>().enabled = true;
            }
        }
    }
}
