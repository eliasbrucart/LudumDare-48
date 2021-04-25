using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Interactions : MonoBehaviour
{
    string actualCollision;
    Collisions interactionCollision;
    public VisualEffect fog;
    PlayerManager manager;
    public float TimeToGoBackToNormalSize;
    [SerializeField] float time;
    public float TorchRadius;
    bool isActive = false;
    float baseRadius;

    void Start()
    {
        interactionCollision = this.GetComponent<Collisions>();
        manager = this.GetComponent<PlayerManager>();
        baseRadius = fog.GetFloat("SphereColiderRadius");
        time = TimeToGoBackToNormalSize;
    }

    // Update is called once per frame
    void Update()
    {
        actualCollision = interactionCollision.itemColliding;


        if (isActive == true)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0 && isActive == true)
        {
            isActive = false;
            fog.SetFloat("SphereColiderRadius", baseRadius);
            time = TimeToGoBackToNormalSize;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch(actualCollision)
            {
                case "torch":
                    if (manager.bigTorch >= 1)
                    {
                        isActive = true;
                        manager.smallTorch -= 1;
                        fog.SetFloat("SphereColiderRadius", TorchRadius);
                    }
                    break;

                case "grave":

                    break;

                case "trap":
                    if (manager.liberateTrap >= 1)
                    {
                        manager.liberateTrap -= 1;
                        this.GetComponent<PlayerMovment>().enabled = true;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
