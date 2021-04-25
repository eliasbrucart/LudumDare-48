using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public string itemColliding;

    public GameObject ActualCollisionObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        itemColliding = collision.gameObject.tag;
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
