﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text healt;
    public Text Keys;
    public Text smallTorch;
    public Text freezeGhost;
    public Text rechargeMagic;
    public Text bigTorch;
    public Text digGrave;
    public Text liberateTrap;

    public Text NPCAdvice;

    public NPC npc;
    void Start()
    {
        
    }

    void Update()
    {
        healt.text = "" + PlayerManager.instancePlayerManager.health;
        Keys.text = "keys: " + PlayerManager.instancePlayerManager.keys;
        smallTorch.text = "" + PlayerManager.instancePlayerManager.smallTorch;
        freezeGhost.text = "" + PlayerManager.instancePlayerManager.freezeGhost;
        bigTorch.text = "" + PlayerManager.instancePlayerManager.bigTorch;
        liberateTrap.text = "liberate trap: " + PlayerManager.instancePlayerManager.liberateTrap;

        if (npc.canListen == true)
        {
            NPCAdvice.text = npc.texto;
        }
        else 
        {
            NPCAdvice.text = "";
        }
    }
}
