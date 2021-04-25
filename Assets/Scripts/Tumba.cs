using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumba : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("agarra input");
            if (collision.gameObject.tag == "Player")
            {
              //  if (this.gameObject.tag == "grave key")
                    Debug.Log("llega");
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
