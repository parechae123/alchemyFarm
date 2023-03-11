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
    public ItemTable SellItem;
    public InventoryManager IM;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        Icon = GetComponent<Image>();
        Icon.sprite = SellItem.icon;
    }
    public void buy()
    {
        ray = Physics2D.Raycast(rt.position, Vector3.back, plrLayer);
        if (ray.collider != null && ray.collider.GetComponent<InvenData>() && ray.collider.GetComponent<InvenData>().wallet.Gold >= SellItem.itemValue)
        {
            if (ray.collider.GetComponent<InvenData>().inSlotItem == SellItem && ray.collider.GetComponent<InvenData>().Amount <= 245)
            {
                ray.collider.GetComponent<InvenData>().Buy(SellItem);
                ray.collider.GetComponent<InvenData>().Amount += 10;
                rt.localPosition = Vector2.zero;
                Debug.Log("구매");
            }
            else
            {
                IM.getItem(SellItem,10);
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
