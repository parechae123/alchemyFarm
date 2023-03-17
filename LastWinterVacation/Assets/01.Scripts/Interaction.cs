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

    public bool isActivated = false;
    public GameObject UI;
    [SerializeField] private bool[] isSlotEmpty;
    [SerializeField] private byte[] ItemAmount;
    public ItemTable[] npcItems;
    public void UIset()
    {
/*        if(npctype != NPCType.Farm)
        {
            Debug.Log("farmer����");
            for (byte i = 0; i < npcItems.Length; i++)
            {
                UI.transform.GetChild(i).GetChild(0).GetComponent<Buy>().SellItem = npcItems[i];
            }
        }
        if(npctype == NPCType.Farm)
        {
            Debug.Log("farm����");
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
    public void ToPlantingBT()
    {
        StartCoroutine(Planting());
    }
    IEnumerator Planting()
    {
        if (npcItems[0].itemType == ItemTable.ItemTypeList.Seed)
        {
            ItemTable tmpInven = npcItems[0];
            UI.transform.GetChild(2).GetChild(0).GetComponent<InvenData>().inSlotItem = tmpInven;
            for (byte i =20; i>= ItemAmount[1];)
            {
                if(ItemAmount[0] > 1)
                {
                    yield return new WaitForSeconds(2);
                    npcItems[1] = tmpInven;
                    ItemAmount[0] -= 1;
                    ItemAmount[1] += 1;
                    UI.transform.GetChild(2).GetChild(0).GetComponent<InvenData>().Amount = ItemAmount[1];
                    UI.transform.GetChild(1).GetChild(0).GetComponent<InvenData>().Amount = ItemAmount[0];
                }
                
            }
        }

    }
}
