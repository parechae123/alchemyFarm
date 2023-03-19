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
    public NPCType npctype;

    public bool plantingActive = false;
    public GameObject UI;
    [SerializeField] private bool[] isSlotEmpty;
    [SerializeField] private byte[] ItemAmount;
    public ItemTable[] npcItems;
    [SerializeField] private GameObject Player;
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
                for (byte i = 0; i < npcItems.Length; i++)
                {
                    UI.transform.GetChild(i + 1).GetChild(0).GetComponent<InvenData>().inSlotItem = npcItems[i];
                    UI.transform.GetChild(i + 1).GetChild(0).GetComponent<InvenData>().Amount = ItemAmount[i];
                }
            break;
        }
    }
    public void saveItems()
    {
        for (byte i = 0; i < npcItems.Length; i++)
        {
            npcItems[i] = UI.transform.GetChild(i + 1).GetChild(0).GetComponent<InvenData>().inSlotItem;
            ItemAmount[i] = UI.transform.GetChild(i + 1).GetChild(0).GetComponent<InvenData>().Amount;
        }
    }
    public void ToPlantingBT(bool alreadyPlanting)
    {
        if (!alreadyPlanting)
        {
            plantingActive = true;
            StartCoroutine(Planting());
        }
    }
    IEnumerator Planting()
    {
        if (npcItems[0].itemType == ItemTable.ItemTypeList.Seed)
        {
            ItemTable tmpInven = npcItems[0];
            UI.transform.GetChild(2).GetChild(0).GetComponent<InvenData>().inSlotItem = tmpInven;
            for (byte i =19; i>= ItemAmount[1];)
            {
                if(ItemAmount[0] > 1)
                {
                    yield return new WaitForSeconds(2);
                    npcItems[1] = tmpInven;
                    ItemAmount[0] -= 1;
                    ItemAmount[1] += 1;
                    if (Player.GetComponent<Player>().NPCinterScript == this)
                    {
                        UI.transform.GetChild(2).GetChild(0).GetComponent<InvenData>().Amount = ItemAmount[1];
                        UI.transform.GetChild(1).GetChild(0).GetComponent<InvenData>().Amount = ItemAmount[0];
                    }
                    if (ItemAmount[0] == 0 || ItemAmount[1] > 20)
                    {
                        break;
                    }
                }
            }
        }
        plantingActive = false;

    }
}
