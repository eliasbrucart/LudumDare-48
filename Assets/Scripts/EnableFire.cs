using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFire : MonoBehaviour
{
    public PlayerManager pm;
    public Animator torchAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject == pm.gameObject)
            {
                if (pm.smallTorch > 0)
                {
                    pm.smallTorch--;
                    StartTorch();
                }
            }
        }
    }

    void StartTorch()
    {
        torchAnim.Play("torch");
    }
}
