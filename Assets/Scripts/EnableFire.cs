using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFire : MonoBehaviour
{
    public PlayerManager pm;
    public Animator torchAnim;

    bool CanBeStarted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CanBeStarted == true)
            {
                Debug.Log("Apreta la e");
                if (pm.smallTorch > 0)
                {
                    Debug.Log("tiene usos");
                    pm.smallTorch--;
                    StartTorch();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanBeStarted = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanBeStarted = false;
        }
    }

    void StartTorch()
    {
        torchAnim.Play("torch");
    }
}
