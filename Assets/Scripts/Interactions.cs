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

    public struct TumbaRandomPossibilities
    {
        public float porcentajeNada;
        public float porcentajeFantasmaMalo;
        public float porcentajeCargarHechizos;
        public float porcentajeCargarAntorchaPequeña;
        public float porcentajeCargarCongelarFantasmas;
    }
    public TumbaRandomPossibilities TumbaRandom;
    
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
                        manager.bigTorch -= 1;
                        fog.SetFloat("SphereColiderRadius", TorchRadius);
                    }
                    break;

                case "grave key":

                    if (manager.digGrave >= 1)
                    {                       
                        interactionCollision.ActualCollisionObject.SetActive(false);
                        isActive = true;
                        manager.digGrave -= 1;
                        manager.keys++;
                    }
                    break;

                case "grave random":
                    Debug.Log("Entró");
                    if (manager.digGrave >= 1)
                    {
                        interactionCollision.ActualCollisionObject.SetActive(false);
                        isActive = true;
                        manager.digGrave -= 1;
                        int queSale = Random.Range(0, 99);

                        Debug.Log("el random es" + queSale);


                        TumbaRandom.porcentajeFantasmaMalo += TumbaRandom.porcentajeNada;
                        TumbaRandom.porcentajeCargarHechizos += TumbaRandom.porcentajeFantasmaMalo;
                        TumbaRandom.porcentajeCargarAntorchaPequeña += TumbaRandom.porcentajeCargarHechizos;
                        TumbaRandom.porcentajeCargarCongelarFantasmas += TumbaRandom.porcentajeCargarAntorchaPequeña;                       
                        
                        
                        if (queSale < TumbaRandom.porcentajeCargarCongelarFantasmas)
                        {
                            Debug.Log("Recargo freeze");
                            manager.freezeGhost++;
                        }
                        else if (queSale < TumbaRandom.porcentajeCargarAntorchaPequeña)
                        {
                            Debug.Log("Recargo antorcha");
                            manager.smallTorch++;
                        }
                        else if(queSale < TumbaRandom.porcentajeCargarHechizos)
                        {
                            Debug.Log("Recargo magia");
                            manager.rechargeMagic++;
                        }
                        else if (queSale < TumbaRandom.porcentajeFantasmaMalo)
                        {
                            Debug.Log("hay que poner un fantasma y activarlo");
                        }
                        else
                        if (queSale < TumbaRandom.porcentajeNada)
                        {
                            Debug.Log("dio nada");
                        }

                    }
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
