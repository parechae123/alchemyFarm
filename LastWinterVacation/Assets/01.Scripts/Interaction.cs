using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public enum NPCType
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
/*        if(npctype != NPCType.Farm)
        {
            Debug.Log("farmer감지");
            for (byte i = 0; i < npcItems.Length; i++)
            {
                UI.transform.GetChild(i).GetChild(0).GetComponent<Buy>().SellItem = npcItems[i];
            }
        }
        if(npctype == NPCType.Farm)
        {
            Debug.Log("farm감지");
            for(byte i = 1; i < npcItems.Length; i++)
            {
                UI.transform.GetChild(i).GetChild(0).GetComponent<InvenData>().inSlotItem = npcItems[i];
            }
        }*/
        switch (npctype)
        {
            case NPCType.Farmer:
                Debug.Log("farmer감지");
                for (byte i = 0; i < npcItems.Length; i++)
                {
                    UI.transform.GetChild(i).GetChild(0).GetComponent<Buy>().SellItem = npcItems[i];
                }
                break;
            case NPCType.Miner:
                break;
            case NPCType.Alchemist:
                break;
            case NPCType.GeneralStore:
                break;
            case NPCType.Farm:
                for (byte i = 1; i < npcItems.Length; i++)
                {
                    UI.transform.GetChild(i).GetChild(0).GetComponent<InvenData>().inSlotItem = npcItems[i];
                }
                break;

        }
    }
}
