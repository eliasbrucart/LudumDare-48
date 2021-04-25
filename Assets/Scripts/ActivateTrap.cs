using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        { 
        Debug.Log("llega");
        this.GetComponent<SpriteRenderer>().enabled = true;
        collision.GetComponentInParent<PlayerMovment>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            this.enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
