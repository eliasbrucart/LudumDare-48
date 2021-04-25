using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    string actualCollision;
    Collisions interactionCollision;
    void Start()
    {
        interactionCollision = this.GetComponent<Collisions>();        
    }

    // Update is called once per frame
    void Update()
    {
        actualCollision = interactionCollision.itemColliding;

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch(actualCollision)
            {
                case "torch":

                    break;

                case "grave":

                    break;

                case "trap":

                    break;

                default:
                    break;
            }
        }
    }
}
