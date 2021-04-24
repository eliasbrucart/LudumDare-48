using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instancePlayerManager;

    public static PlayerManager Instance { get { return instancePlayerManager; } }

    [SerializeField] private float health;
    [SerializeField] private float keys;
    [SerializeField] private float skill1;
    [SerializeField] private float skill2;
    [SerializeField] private float skill3;

    private void Awake()
    {
        if(instancePlayerManager != null && instancePlayerManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instancePlayerManager = this;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetHealth(float playerHealth)
    {
        health = playerHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetKey(float playerKeys)
    {
        keys = playerKeys;
    }

    public float GetKeys()
    {
        return keys;
    }

    public void SetSkill1(float playerSkill1)
    {
        skill1 = playerSkill1;
    }

    public float GetSkill1()
    {
        return skill1;
    }

    public void SetSkill2(float playerSkill2)
    {
        skill2 = playerSkill2;
    }

    public float GetSkill2()
    {
        return skill2;
    }

    public void SetSkill3(float playerSkill3)
    {
        skill3 = playerSkill3;
    }

    public float GetSkill3()
    {
        return skill3;
    }
}
