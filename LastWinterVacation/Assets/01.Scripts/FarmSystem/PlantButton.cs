using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlantButton : MonoBehaviour
{
    public InvenData SeedInput;
    public void OnButtonClick()
    {
        if (SeedInput.inSlotItem.itemType == ItemTable.ItemTypeList.Seed)
        {
            Debug.Log("�÷��� ��ư ����");
        }
    }
}
