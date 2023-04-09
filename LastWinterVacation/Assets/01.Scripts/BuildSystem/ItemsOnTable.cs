using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsOnTable : MonoBehaviour
{
    public ItemTable[] onTableObjects = new ItemTable[3];//ÃÖ´ë 3°³

    public GameObject[] itemObject = new GameObject[3];
    public void OnTableSetting()
    {
        for(byte i = 0; onTableObjects.Length > i; i++)
        {
            if(onTableObjects[i].itemType == ItemTable.ItemTypeList.TableObjects&& onTableObjects[i].model != null)
            {
                itemObject[i].GetComponent<MeshFilter>().mesh = onTableObjects[i].model[0].GetComponent<MeshFilter>().sharedMesh;
                itemObject[i].GetComponent<MeshRenderer>().materials = onTableObjects[i].model[0].GetComponent<MeshRenderer>().sharedMaterials;
            }
            if (onTableObjects[i].itemType != ItemTable.ItemTypeList.TableObjects)
            {
                itemObject[i].GetComponent<MeshFilter>().mesh = null;
/*                itemObject[i].GetComponent<MeshRenderer>().materials = ;*/
            }
        }
    }
}