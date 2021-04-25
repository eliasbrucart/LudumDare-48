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

    public float porcentajeNada;
    public float porcentajeFantasmaMalo;
    public float porcentajeCargarTodosLosHechizos;
    public float porcentajeCargarAntorchaPequeña;
    public float porcentajeCargarCongelarFantasmas;
    public float porcentajeCargarAntorchaGrande;
    public float porcentajeCargarLiberarseDeTrampa;
    public float CantidadDeRecargasAlRecargarTodasLasMagias;
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
                       
                        interactionCollision.ActualCollisionObject.SetActive(false);
                        isActive = true;
                        manager.keys++;
                    break;

                case "grave random":
                    Debug.Log("Entró");
                    interactionCollision.ActualCollisionObject.SetActive(false);
                    isActive = true;
                    int queSale = Random.Range(1, 100);

                    Debug.Log("el random es" + queSale);


                    porcentajeFantasmaMalo += porcentajeNada;
                    porcentajeCargarTodosLosHechizos += porcentajeFantasmaMalo;
                    porcentajeCargarAntorchaPequeña += porcentajeCargarTodosLosHechizos;
                    porcentajeCargarCongelarFantasmas += porcentajeCargarAntorchaPequeña;
                    porcentajeCargarAntorchaGrande += porcentajeCargarCongelarFantasmas;
                    porcentajeCargarLiberarseDeTrampa += porcentajeCargarAntorchaGrande;


                    if (queSale < porcentajeNada)
                    {
                        Debug.Log("dio nada");
                    }
                    else if (queSale < porcentajeFantasmaMalo)
                    {
                        Debug.Log("hay que poner un fantasma y activarlo");                        
                    }
                    else if (queSale < porcentajeCargarTodosLosHechizos)
                    {
                        Debug.Log("Recargo magia");
                        manager.smallTorch += CantidadDeRecargasAlRecargarTodasLasMagias;
                        manager.freezeGhost += CantidadDeRecargasAlRecargarTodasLasMagias;
                        manager.bigTorch += CantidadDeRecargasAlRecargarTodasLasMagias;
                        manager.liberateTrap += CantidadDeRecargasAlRecargarTodasLasMagias;
                    }
                    else if (queSale < porcentajeCargarAntorchaPequeña)
                    {
                        Debug.Log("Recargo antorchaChica");
                        manager.smallTorch++;
                    }
                    else
                    if (queSale < porcentajeCargarCongelarFantasmas)
                    {
                        Debug.Log("Recargo freeze");
                        manager.freezeGhost++;
                    }
                    else
                    if (queSale < porcentajeCargarAntorchaGrande)
                    {
                        Debug.Log("Recargo AntorchaGrande");
                        manager.bigTorch++;
                    }
                    else
                    if (queSale < porcentajeCargarLiberarseDeTrampa)
                    {
                        Debug.Log("Recargo LiberarseDeTrampa");
                        manager.liberateTrap++;
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
