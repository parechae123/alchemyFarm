using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsOnTable : MonoBehaviour
{
    [SerializeField]private ItemTable[] onTableObjects = new ItemTable[3];//�ִ� 3��
    public ItemTable[] OnTableObjects
    {
        get { return onTableObjects; }
        set 
        { 
            onTableObjects = value;
            OnTableSetting(OnTableObjects);
        }
    }//�ִ� 3��
    public GameObject[] itemObject = new GameObject[3];
    public void OnTableSetting(ItemTable[] inven)
    {
        for(byte i = 0; OnTableObjects.Length > i; i++)
        {
           itemObject[i] = OnTableObjects[i].model[0];
        }
    }
}
