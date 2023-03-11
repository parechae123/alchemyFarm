using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI goldAmount;
    private int gold = 0;
    public int Gold 
    { 
        get { return gold; } 
        set { gold = value;
            goldAmount.text = gold.ToString();
        } 
    }
}
