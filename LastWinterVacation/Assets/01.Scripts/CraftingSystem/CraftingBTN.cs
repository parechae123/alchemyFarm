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
        if(itemType[0].itemNumber == 32 && amounts[0]>0&& itemType[1].itemNumber == 32 && amounts[1] > 0 && itemType[2].itemNumber == 32 && amounts[2] > 0)
        {
            if (whatSlot[3].inSlotItem.itemNumber == 0 || whatSlot[3].inSlotItem.itemNumber ==40/*������ ��ȣ*/)
            {
                for(byte i =0; i < 3;i++)
                {
                    whatSlot[i].Amount -= 1;
                    amounts[i] -= 1;
                }
                whatSlot[3].inSlotItem = Resources.Load<ItemTable>("07.ItemLists/Juices/CarrotJuice");//������ ������ ���̺� �ּ�(resource���� �ȿ� �־����,Ȯ���� �̸��� ��������
                whatSlot[3].Amount += 1;
            }
        }
        if (itemType[0].itemNumber == 31 && amounts[0] > 0 && itemType[1].itemNumber == 31 && amounts[1] > 0 && itemType[2].itemNumber == 31 && amounts[2] > 0)
        {
            if (whatSlot[3].inSlotItem.itemNumber == 0 || whatSlot[3].inSlotItem.itemNumber == 41/*������ ��ȣ*/)
            {
                for (byte i = 0; i < 3; i++)
                {
                    whatSlot[i].Amount -= 1;
                    amounts[i] -= 1;
                }
                whatSlot[3].inSlotItem = Resources.Load<ItemTable>("07.ItemLists/Juices/PotatoJuice");//������ ������ ���̺� �ּ�(resource���� �ȿ� �־����,Ȯ���� �̸��� ��������
                whatSlot[3].Amount += 1;
            }
        }
    }
}
