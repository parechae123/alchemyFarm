using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] isItemThere;
    public InvenData[] slot;
    void Start()
    {
        for(byte i = 0; i < slot.Length; i++)
        {
            slot[i].invenNumber = i;
        }
    }
    public void getItem(ItemTable item,byte amount)
    {
        byte leftAmount;
        for (byte i = 0; i < isItemThere.Length; i++)
        {
            if (isItemThere[i] == false)
            {

                slot[i].inSlotItem = item;
                slot[i].Amount = amount;
                break;

            }
            if (isItemThere[i] == true&& slot[i].inSlotItem == item && slot[i].Amount !=255)
            {
                leftAmount = (byte)(255 - slot[i].Amount);
                if (slot[i].Amount+amount <=255)
                {
                    slot[i].Amount += amount;
                    break;
                }
                if(slot[i].Amount + amount > 255)
                {
                    slot[i].Amount += (byte)(leftAmount);
                    for (byte E = 0; E < isItemThere.Length; E++)
                    {
                        if (slot[E].emptyItem == slot[E].inSlotItem || slot[E].inSlotItem == item)
                        {
                            if (slot[E].Amount != 255 && amount - leftAmount == 0)
                            {
                                slot[E].inSlotItem = item;
                                slot[E].Amount = (byte)(amount - leftAmount);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
