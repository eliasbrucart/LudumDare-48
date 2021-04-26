using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string texto;
    public bool canListen = false;
    bool CanBeStarted = false;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        if (CanBeStarted == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<PlayerMovment>().enabled = false;
                canListen = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.GetComponent<PlayerMovment>().enabled = true;
                canListen = false;
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
}
