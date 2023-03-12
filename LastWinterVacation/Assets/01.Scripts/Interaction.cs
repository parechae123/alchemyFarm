using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    enum NPCType
    {
        Farmer,
        Miner, 
        Alchemist,
        GeneralStore,
        Farm
    }
    [SerializeField]
    NPCType npctype;

    public bool isActivated = false;
    public GameObject UI;
    [SerializeField] private bool[] isSlotEmpty;
    [SerializeField] private ItemTable[] npcItems;
    public void UIset()
    {
        if(npctype != NPCType.Farm)
        {
            for(byte i = 0; i < npcItems.Length; i++)
            {
                UI.transform.GetChild(i).GetChild(0).GetComponent<Buy>().SellItem = npcItems[i];
            }
        }
        if(npctype == NPCType.Farm)
        {

        }
    }
}
