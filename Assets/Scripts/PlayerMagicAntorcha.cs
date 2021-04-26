using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class PlayerMagicAntorcha : MonoBehaviour
{
    public VisualEffect fog;
    // Start is called before the first frame update
    public float SmallTorchRadius = 3;
    PlayerManager manager;
    public float TimeToGoBackToNormalSize;
    [SerializeField] float time;
    bool isActive = false;
    float baseRadius;

    public AudioSource torch;
    public AudioSource noCharge;
    void Start()
    {
        manager = this.GetComponent<PlayerManager>();
        baseRadius = fog.GetFloat("SphereColiderRadius");
        time = TimeToGoBackToNormalSize;
    }
    void Update()
    {
        if (isActive == true)
        {
            time -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {           
            if (manager.smallTorch >= 1)
            {
                isActive = true;
                manager.smallTorch -= 1;
                fog.SetFloat("SphereColiderRadius", SmallTorchRadius);
                torch.Play();
            }
            else
            {
                noCharge.Play();
            }
        }
        if (time <= 0 && isActive == true)
        {
            isActive = false;
            fog.SetFloat("SphereColiderRadius", baseRadius);
            time = TimeToGoBackToNormalSize;
        }
    }
}
