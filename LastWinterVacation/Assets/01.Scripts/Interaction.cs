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

    public FarmManager farmManager;
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
            Debug.Log("플랜팅 시작");
            if (npcItems[1].itemType == ItemTable.ItemTypeList.Empty || npcItems[0] == npcItems[1])
            {
                UI.GetComponent<InventoryManager>().slot[1].inSlotItem = tmpInven;
                for (byte i = 19; i >= ItemAmount[1];)
                {
                    yield return new WaitForSeconds(2);
                    if (ItemAmount[0] == 0 || ItemAmount[1] > 20 || npcItems[0].itemNumber != tmpInven.itemNumber)
                    {
                        Debug.Log("취소");
                        break;
                    }
                    if (ItemAmount[0] >= 1 && npcItems[0].itemNumber == tmpInven.itemNumber)
                    {
                        ItemAmount[0] -= 1;
                        ItemAmount[1] += 1;
                        farmManager.GrowingPlants(ItemAmount[1],tmpInven);
                        Debug.Log("씨앗 증가");
                    }
                    if (Player.GetComponent<Player>().NPCinterScript == this)
                    {
                        /*UI.GetComponent<InventoryManager>().slot[0].Amount -= 1;
                        UI.GetComponent<InventoryManager>().slot[0].Amount += 1;*/
                        npcItems[0] = UI.GetComponent<InventoryManager>().slot[0].inSlotItem;
                        ItemAmount[0] = UI.GetComponent<InventoryManager>().slot[0].Amount;
                        UI.GetComponent<InventoryManager>().slot[0].Amount -= 1;
                        npcItems[1] = UI.GetComponent<InventoryManager>().slot[1].inSlotItem;
                        ItemAmount[1] = UI.GetComponent<InventoryManager>().slot[1].Amount;
                        UI.GetComponent<InventoryManager>().slot[1].Amount += 1;
                        /*UI.transform.GetChild(2).GetChild(0).GetComponent<InvenData>().Amount = ItemAmount[1];
                        UI.transform.GetChild(1).GetChild(0).GetComponent<InvenData>().Amount = ItemAmount[0];*/
                        Debug.Log("정보 저장");
                    }
                }
            }

        }
        Debug.Log("끝");
        plantingActive = false;

    }
}
