using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class InvenData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private InventoryManager inventoryManager;
    public byte invenNumber;

    public ItemTable inSlotItem;
    public ItemTable emptyItem;
    public TextMeshProUGUI amountText;
    private bool isOut;
    public Wallet wallet;
    [SerializeField]private LayerMask layerMask;
    [SerializeField]
    RaycastHit2D RC;
    public bool IsOut
    { get { return isOut; }
        set 
        { 
            isOut = value;
            StartCoroutine(PosResetTimer());
        }
    }
    private byte amount = 0;
    public byte Amount 
    { get { return amount; }
        set
        {
            amount = value;
            if (amount > 0)
            {
                this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = inSlotItem.icon;
                amountText.text = amount.ToString();
                inventoryManager.isItemThere[invenNumber] = true;
            }
            else
            {
                inSlotItem = emptyItem;
                this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = inSlotItem.icon;
                amountText.text = "";
                inventoryManager.isItemThere[invenNumber] = false;
            }
        }
    }
    private RectTransform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    IEnumerator PosResetTimer()
    {
            yield return new WaitForEndOfFrame();
            RC = Physics2D.CircleCast(transform.position, 10, Vector2.zero, 0, layerMask,0,300);
            if (RC.collider != null)
            {
                Debug.Log("아이템 스왑");
                ItemTable swaper = inSlotItem;
                byte amountSwap = Amount;
                if (RC.collider.gameObject.TryGetComponent<InvenData>(out InvenData Component))
                {
                    inSlotItem = RC.collider.gameObject.GetComponent<InvenData>().inSlotItem;
                    RC.collider.gameObject.GetComponent<InvenData>().inSlotItem = swaper;
                    Amount = RC.collider.gameObject.GetComponent<InvenData>().Amount;
                    RC.collider.gameObject.GetComponent<InvenData>().Amount = amountSwap;
                }
                if (RC.collider.gameObject.TryGetComponent<Buy>(out Buy sellCom))
                {
                    Debug.Log("아이템판매");
                    wallet.Gold += inSlotItem.itemValue*Amount;
                    inSlotItem = emptyItem;
                    Amount = 0;
                }
            }
            if (RC.collider == null)
            {
                Debug.Log("아이템 스왑실패");
            }
        //여기다가 레이넣자
        yield return new WaitForSeconds(0.05f);
        rt.anchoredPosition = Vector3.zero;
    }
    public void Buy(ItemTable whatBuy)
    {
        wallet.Gold -= whatBuy.itemValue * 15;
    }
}
