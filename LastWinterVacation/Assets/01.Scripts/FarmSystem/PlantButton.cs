using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantButton : MonoBehaviour
{
    public InvenData SeedInput;
    void OnButtonClick()
    {
        if (SeedInput.inSlotItem.itemType == ItemTable.ItemTypeList.Seed)
        {
            
        }
    }
}
