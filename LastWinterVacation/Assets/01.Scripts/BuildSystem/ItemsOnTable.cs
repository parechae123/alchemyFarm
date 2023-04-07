using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsOnTable : MonoBehaviour
{
    public InvenData[] onTableObjects = new InvenData[3];//ÃÖ´ë 3°³
    public GameObject[] itemObject = new GameObject[3];
    public void OnTableSetting()
    {
        for(byte i = 0; onTableObjects.Length > i; i++)
        {
           itemObject[i] = onTableObjects[i].inSlotItem.model[0];
        }
    }
}
