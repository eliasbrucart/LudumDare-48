using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public string itemColliding;
    public float GhostDamage = 10;
    public GameObject ActualCollisionObject;

    public string NextLvl;

    void OnTriggerEnter2D(Collider2D collision)
    {
        itemColliding = collision.gameObject.tag;
        ActualCollisionObject = collision.gameObject;


        if (collision.gameObject.tag == ("door"))
        {
            if( PlayerManager.instancePlayerManager.keys >= 1)
            {
                SceneManager.LoadScene(NextLvl);
            }
        }

        if (collision.gameObject.tag == ("ghost"))
        {
            Debug.Log("Choca con fantasma");
            PlayerManager.instancePlayerManager.health -= GhostDamage;
            
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        itemColliding = "";

        if (collision.gameObject.tag == ("grave random"))
        {

            this.GetComponent<Interactions>().ThisTimeRandom = 0;
        }
    }
}
