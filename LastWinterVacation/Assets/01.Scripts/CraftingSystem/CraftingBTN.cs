using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBTN : MonoBehaviour
{
    public InvenData[] whatSlot = new InvenData[4];
    public byte[] amounts = new byte[4];
    public ItemTable[] itemType = new ItemTable[4];

    public void Crafting()
    {
        for (byte i = 0;whatSlot.Length-1> i; i++)
        {
            itemType[i] = whatSlot[i].inSlotItem;
            amounts[i] = whatSlot[i].Amount;
        }
        CraftOutput();
    }
    private void CraftOutput()
    {
        if(itemType[0].itemNumber == 32 && amounts[0]>0)
        {
            if (whatSlot[3].inSlotItem.itemNumber == 0 || whatSlot[3].inSlotItem.itemNumber ==32/*아이템 번호*/)
            {
                whatSlot[0].Amount -= 1;
                amounts[0] -= 1;
                whatSlot[3].inSlotItem = Resources.Load<ItemTable>("07.ItemLists/Adults/Carrot");//대입할 아이템 테이블 주소(resource폴더 안에 있어야함,확장자 이름은 지워야함
                whatSlot[3].Amount += 1;
            }
        }
    }
}
