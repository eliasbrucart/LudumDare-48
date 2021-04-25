using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public string itemColliding;

    public GameObject ActualCollisionObject;

    void OnTriggerEnter2D(Collider2D collision)
    {

        itemColliding = collision.gameObject.tag;

        /* if (collision.gameObject.tag == "grave key")
         {
             collision.GetComponent<SpriteRenderer>().enabled = false;
             collision.GetComponent<BoxCollider2D>().enabled = false;
         }*/
        ActualCollisionObject = collision.gameObject;

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
