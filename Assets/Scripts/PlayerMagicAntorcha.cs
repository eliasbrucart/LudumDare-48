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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {           
            if (manager.GetSkill1() >= 1)
            {
                isActive = true;
                manager.SetSkill1(manager.GetSkill1() - 1);
                fog.SetFloat("SphereColiderRadius", SmallTorchRadius);
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
