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
        ActualCollisionObject = collision.gameObject;

        if (collision.gameObject.tag == ("door"))
        {
            if( PlayerManager.instancePlayerManager.keys >= 1)
            {
                Debug.Log("End LVL");
            }
        }

        if (collision.gameObject.tag == ("ghost"))
        {
            this.GetComponent<PlayerManager>().health -= 10;
            
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        itemColliding = "";
    }
}
