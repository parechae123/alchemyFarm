using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsOnTable : MonoBehaviour
{
    private InvenData[] onTableObjects = new InvenData[3];//�ִ� 3��
    public InvenData[] OnTableObjects
    {
        get { return onTableObjects; }
        set 
        { 
            onTableObjects = value;
            OnTableSetting(OnTableObjects);
        }
    }//�ִ� 3��
    public GameObject[] itemObject = new GameObject[3];
    public void OnTableSetting(InvenData[] inven)
    {
        for(byte i = 0; OnTableObjects.Length > i; i++)
        {
           itemObject[i] = OnTableObjects[i].inSlotItem.model[0];
        }
    }
}
