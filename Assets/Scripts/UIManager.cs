using System.Collections;
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
    void Start()
    {
        
    }

    void Update()
    {
        healt.text = "health: " + PlayerManager.instancePlayerManager.health;
        Keys.text = "keys: " + PlayerManager.instancePlayerManager.keys;
        smallTorch.text = "small torch: " + PlayerManager.instancePlayerManager.smallTorch;
        freezeGhost.text = "freeze ghost: " + PlayerManager.instancePlayerManager.freezeGhost;
        rechargeMagic.text = "recharge magic: " + PlayerManager.instancePlayerManager.rechargeMagic;
        bigTorch.text = "big torch: " + PlayerManager.instancePlayerManager.bigTorch;
        digGrave.text = "dig grave: " + PlayerManager.instancePlayerManager.digGrave;
        liberateTrap.text = "liberate trap: " + PlayerManager.instancePlayerManager.liberateTrap;
    }
}
