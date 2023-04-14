using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject[] Slots;
    public ItemTable[] InventoryTable;
    public int gold;
    [SerializeField] private TextMeshProUGUI playerMoney;
    //21번째 = 여분

    // Start is called before the first frame update
    private void Awake()
    {
        Slots[0] = this.transform.GetChild(1).gameObject;
        for (byte i = 0; i < 20; i++)
        {
            Slots[i] = this.transform.GetChild(i).gameObject;
            InventoryTable[i] = Slots[i].transform.GetChild(0).gameObject.GetComponent<InvenData>().inSlotItem;
        }
    }
/*    public void GetItem()
    {
        for (byte i = 0; i < 20; i++)
        {
            Slots[i].GetComponent<InvenData>().ItemUpdate();
            InventoryTable[i] = Slots[i].transform.GetChild(0).GetComponent<InvenData>().inSlotItem;
            playerMoney.text = gold.ToString();
        }
    }*/
}
