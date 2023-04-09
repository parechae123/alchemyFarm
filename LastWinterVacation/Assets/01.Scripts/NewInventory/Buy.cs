using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    private RectTransform rt;
    private RaycastHit2D ray;
    [SerializeField]private LayerMask plrLayer;
    public Image Icon;
    [SerializeField]private ItemTable sellitems;
    public ItemTable SellItem { 
        get 
        {
            return sellitems;
        } 
        set 
        {
            sellitems = value;
            Icon.sprite = SellItem.icon;
        } 
    }
    public InventoryManager IM;
    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }
    public void buy()
    {
        ray = Physics2D.Raycast(rt.position, Vector3.back, plrLayer);
        if (ray.collider != null && ray.collider.GetComponent<InvenData>() && ray.collider.GetComponent<InvenData>().wallet.Gold >= SellItem.itemValue*10)
        {
            if (ray.collider.GetComponent<InvenData>().inSlotItem == SellItem && ray.collider.GetComponent<InvenData>().Amount <= 245)
            {
                ray.collider.GetComponent<InvenData>().Buy(SellItem);
                if(SellItem.itemType== ItemTable.ItemTypeList.Seed)
                {
                    ray.collider.GetComponent<InvenData>().Amount += 10;
                }
                else
                {
                    ray.collider.GetComponent<InvenData>().Amount += 1;
                }
                rt.localPosition = Vector2.zero;
                Debug.Log("구매1");
            }
            else
            {
                if (SellItem.itemType == ItemTable.ItemTypeList.Seed)
                {
                    IM.getItem(SellItem, 10);
                }
                else
                {
                    IM.getItem(SellItem, 1);
                }
                ray.collider.GetComponent<InvenData>().Buy(SellItem);
                rt.localPosition = Vector2.zero;
                Debug.Log("구매");
            }
        }
        else
        {
            rt.localPosition = Vector2.zero;
        }

    }
}
