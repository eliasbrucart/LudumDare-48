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

    public GameObject Fantasma;

    public float porcentajeNada;
    public float porcentajeFantasmaMalo;
    public float porcentajeCargarTodosLosHechizos;
    public float porcentajeCargarAntorchaPequeña;
    public float porcentajeCargarCongelarFantasmas;
    public float porcentajeCargarAntorchaGrande;
    public float CantidadDeRecargasAlRecargarTodasLasMagias;

    public AudioSource torch;
    public AudioSource key;
    public AudioSource trap;
    public AudioSource grave;
    public AudioSource noCharge;
    public AudioSource recharge;

    public GameObject textBox;

    public int ThisTimeRandom = 0;
    void Start()
    {

        interactionCollision = this.GetComponent<Collisions>();
        manager = this.GetComponent<PlayerManager>();
        baseRadius = fog.GetFloat("SphereColiderRadius");
        time = TimeToGoBackToNormalSize;
        ThisTimeRandom = 0;
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
                        torch.Play();
                    }
                    else
                    {
                        noCharge.Play();
                    }
                    break;

                case "grave key":
                    grave.Play();
                    key.PlayDelayed(0.7f);
                        interactionCollision.ActualCollisionObject.SetActive(false);
                        isActive = true;
                        manager.keys++;
                    break;

                case "grave random":
                    Debug.Log("Entró");
                    interactionCollision.ActualCollisionObject.GetComponent<BoxCollider2D>().enabled = false;
                    interactionCollision.ActualCollisionObject.GetComponent<SpriteRenderer>().enabled = false;
                    //SetActive(false);
                    isActive = true;
                   
                    ThisTimeRandom = Random.Range(1, 100);
                    Debug.Log("el random es" + ThisTimeRandom);


                    porcentajeFantasmaMalo += porcentajeNada;
                    porcentajeCargarTodosLosHechizos += porcentajeFantasmaMalo;
                    porcentajeCargarAntorchaPequeña += porcentajeCargarTodosLosHechizos;
                    porcentajeCargarCongelarFantasmas += porcentajeCargarAntorchaPequeña;
                    porcentajeCargarAntorchaGrande += porcentajeCargarCongelarFantasmas;
                   


                    if (ThisTimeRandom < porcentajeNada)
                    {
                        Debug.Log("dio nada");
                    }
                    else if (ThisTimeRandom < porcentajeFantasmaMalo)
                    {
                        Vector3 FantasmaSpawn =  this.transform.position + new Vector3(0,2.0f, 0);
                        Instantiate(Fantasma, FantasmaSpawn, Quaternion.identity);                      
                    }
                    else if (ThisTimeRandom < porcentajeCargarTodosLosHechizos)
                    {
                        Debug.Log("Recargo magia");
                        recharge.Play();
                        manager.smallTorch += CantidadDeRecargasAlRecargarTodasLasMagias;
                        manager.freezeGhost += CantidadDeRecargasAlRecargarTodasLasMagias;
                        manager.bigTorch += CantidadDeRecargasAlRecargarTodasLasMagias;
                    }
                    else if (ThisTimeRandom < porcentajeCargarAntorchaPequeña)
                    {
                        recharge.Play();
                        Debug.Log("Recargo antorchaChica");
                        manager.smallTorch++;
                    }
                    else
                    if (ThisTimeRandom < porcentajeCargarCongelarFantasmas)
                    {
                        recharge.Play();
                        Debug.Log("Recargo freeze");
                        manager.freezeGhost++;
                    }
                    else
                    if (ThisTimeRandom < porcentajeCargarAntorchaGrande)
                    {
                        recharge.Play();
                        Debug.Log("Recargo AntorchaGrande");
                        manager.bigTorch++;
                    }
                    else
                    
                    grave.Play();
                    break;

                case "trap":

                        trap.Play();
                        this.GetComponent<PlayerMovment>().enabled = true;
                    break;

                case "NPC":

                    Debug.Log("hola npc");
                    textBox.SetActive(true);

                    break;

                case "door":

                    Debug.Log("cambio de lvl");

                    break;

                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            textBox.SetActive(false);
        }
    }
}
