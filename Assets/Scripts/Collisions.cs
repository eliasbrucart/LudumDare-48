using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public string itemColliding;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("El player colisiono con: " + collision.gameObject.tag);

        itemColliding = collision.gameObject.tag;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        itemColliding = "";
        if (collision.gameObject.tag == "trap")
        {
            collision.enabled = false;
            collision.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
