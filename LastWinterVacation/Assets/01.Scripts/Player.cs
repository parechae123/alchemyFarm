using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    #region


    private Vector2 plrDir;
    private Vector2 mousePos;
    [SerializeField] private Vector2 mouseDragStart;
    [SerializeField] private Vector2 mouseDragEnd;
    [SerializeField] private Vector3 rayLength;

    private bool isUIOpened;
    private bool beforeESC = false;
    public byte loadShop = 1;

    public PlantButton plantBTN;
    private Vector3 cameraAngle;
    [SerializeField] private GameObject cameraRot;
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject TargetUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject dragUI;
    private GameObject installObject;
    private GameObject installBTNPanel;
    public Interaction NPCinterScript;

    [SerializeField] private float moveSpeed;
    [SerializeField] private CinemachineFreeLook cinemachineFreeLook;

    private Transform tr;

    [SerializeField]private Texture2D cursorIMG;

    private RaycastHit npcHit;
    [SerializeField] private LayerMask uiTaget;
    [SerializeField] private LayerMask npcTaget;
    private Animator Anim;
    private void ReturnIngame()
    {
        if (!isUIOpened)
        {
            plrDir = new Vector2(0, 0);
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Anim.SetBool("Walk", false);
            menuUI.SetActive(true);
            isUIOpened = true;
            beforeESC = true;
        }
        else
        {
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = 2;
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = 300;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Inventory.SetActive(false);
            menuUI.SetActive(false);
            isUIOpened = false;
            beforeESC = false;
        }
    }
    private void uiControl()
    {
        if(TargetUI == null)
        {
            
        }
        else
        {
            if (!isUIOpened)
            {
                plrDir = new Vector2(0, 0);
                isUIOpened = true;
                cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
                cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
                Anim.SetBool("Walk", false);
                TargetUI.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                isUIOpened = false;
                cinemachineFreeLook.m_YAxis.m_MaxSpeed = 2;
                cinemachineFreeLook.m_XAxis.m_MaxSpeed = 300;
                TargetUI.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                if (NPCinterScript != null)
                {
                    if (NPCinterScript.npctype == Interaction.NPCType.Farm)
                    {
                        NPCinterScript.saveItems();
                    }
                }
            }
        }

    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        Anim = GetComponent<Animator>();
        Cursor.SetCursor(cursorIMG, mousePos, CursorMode.Auto);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        installBTNPanel = GameObject.Find("InstallPanel");
    }
    private void FixedUpdate()
    {
        transform.Translate(plrDir.x * moveSpeed, 0,plrDir.y * moveSpeed);
        /*Quaternion targetRotation = Quaternion.LookRotation(cameraRot.forward);*/
        cameraAngle = cameraRot.GetComponent<Transform>().eulerAngles;
        tr.eulerAngles = new Vector3(0, cameraAngle.y, 0);
        Debug.DrawRay(this.transform.position + transform.up, transform.forward,Color.red);
        if (Physics.Raycast(transform.position + transform.up, transform.forward, out npcHit, 2f ,npcTaget))
        {
            
            interactionUI = npcHit.collider.gameObject.GetComponent<Interaction>().UI;
            if (isUIOpened == false&&loadShop == 1)
            {
                ++loadShop;
                NPCinterScript = npcHit.collider.gameObject.GetComponent<Interaction>();
                npcHit.collider.GetComponent<Interaction>().UIset();
                if(interactionUI.name == "FarmUI")
                {
                    plantBTN.TargetFarm = NPCinterScript;
                }
            }
        }
        else
        {
            interactionUI = null;
            loadShop = 1;
            NPCinterScript= null;
        }
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if(isUIOpened == false)
        {
            plrDir = ctx.ReadValue<Vector2>().normalized;
            Anim.SetBool("Walk", true);
        }
        if (ctx.canceled)
        {
            Anim.SetBool("Walk", false);
        }

    }
    public void OnMouseLeftClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            mouseDragStart = mousePos;
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, 100, uiTaget);
            if (hit.collider != null)
            {
                dragUI = hit.collider.gameObject;
                if(dragUI.layer == 8)
                {
                    if (dragUI.TryGetComponent<PlantButton>(out PlantButton PBT))
                    {
                        NPCinterScript.saveItems();
                        dragUI.GetComponent<PlantButton>().TargetFarm = NPCinterScript;
                        dragUI.GetComponent<PlantButton>().SeedInput = NPCinterScript.npcItems[0];
                        dragUI.GetComponent<PlantButton>().TargetFarm = NPCinterScript;
                        dragUI.GetComponent<PlantButton>().PlantButtonClick();
                    }
                    if(dragUI.TryGetComponent<CraftingBTN>(out CraftingBTN CBT))
                    {
                        Debug.Log("버튼 인식");
                    }
                    if (dragUI.TryGetComponent<InstallBTN>(out InstallBTN ITN)&& !dragUI.GetComponent<InstallBTN>().isInstalling)
                    {
                        dragUI.GetComponent<InstallBTN>().OnInstallBTN(installObject);
                        layerTemp.GetComponent<InvenData>().Amount -= 1;
                    }
                }
            }
            else if (hit.collider == null)
            {
                dragUI = null;
            }
        }
        if (ctx.canceled)
        {
            if(dragUI == null)
            {
                
            }
            else
            {
                if (dragUI.gameObject.TryGetComponent<InvenData>(out InvenData component))
                {
                    dragUI.GetComponent<InvenData>().IsOut = true;
                    dragUI.transform.position = mousePos;
                }
                if(dragUI.layer == 7 && dragUI.GetComponent<Buy>().SellItem.itemType != ItemTable.ItemTypeList.Empty)
                {
                    dragUI.transform.position = mousePos;
                    dragUI.GetComponent<Buy>().buy();
                }
                if (dragUI.layer == 5)
                {
                    mouseDragEnd = mousePos;
                    dragUI.transform.Translate(mouseDragEnd - mouseDragStart);
                }
            }
        }
    }
    private GameObject layerTemp;
    public void OnMouseRightClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, 100, uiTaget);
            if (hit.collider != null&&hit.collider.gameObject.layer == 3&&hit.collider.gameObject.transform.parent.parent.name == "Inventory"&&hit.collider.GetComponent<InvenData>().inSlotItem.itemType == ItemTable.ItemTypeList.Furniture)
            {
                if(layerTemp != hit.collider.gameObject&& layerTemp != null)
                {
                    installBTNPanel.transform.position = new Vector3(60, -680, 0);
                    layerTemp.layer = 3;
                    Debug.Log("ㅇㅇ");
                }
                hit.collider.gameObject.layer = 3;
                layerTemp = hit.collider.gameObject;
                installObject = layerTemp.GetComponent<InvenData>().inSlotItem.model[0];
                installBTNPanel.transform.position = hit.collider.gameObject.transform.position;
                layerTemp.layer = 0;
            }
            if (hit.collider == null)
            {
                installBTNPanel.transform.position = new Vector3(60,-680,0);
                layerTemp.layer = 3;
            }
        }
    }
    public void OnInteractionKey(InputAction.CallbackContext ctx)
    {
        
        if (ctx.started && !beforeESC)
        {
            if(interactionUI != null)
            {
                if (interactionUI.activeSelf == false)
                {
                    if(TargetUI != Inventory)
                    {
                        Inventory.SetActive(true);
                        TargetUI = interactionUI;
                        if (TargetUI.name == "FarmUI")
                        {
                            plantBTN.colorState();
                        }
                        uiControl();
                        Anim.SetBool("Walk", false);

                    }

                }
                else
                {
                    Inventory.SetActive(false);
                    uiControl();
                    TargetUI = null;
                }
            }
            else if (interactionUI == null)
            {
                cinemachineFreeLook.m_YAxis.m_MaxSpeed = 2;
                cinemachineFreeLook.m_XAxis.m_MaxSpeed = 300;
            }
        }
    }
    public void OnCursorSet(InputAction.CallbackContext ctx)
    {
        
        mousePos = ctx.ReadValue<Vector2>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interaction"))
        {
            interactionUI = other.gameObject.GetComponent<Interaction>().UI;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interaction"))
        {
            interactionUI.SetActive(false);
            interactionUI = null;

        }
    }
    public void OnInventoryKey(InputAction.CallbackContext ctx)
    {
        if (ctx.started && !beforeESC)
        {
            if(Inventory.activeSelf == false)
            {
                if (TargetUI == null)
                {
                    TargetUI = Inventory;
                    uiControl();
                }
            }
            else
            {
                uiControl();
                TargetUI = null;
            }
        }
    }
    public void ESCkey(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ReturnIngame();
            if (TargetUI != null)
            {
                TargetUI.SetActive(false);
            }
            TargetUI = null;
            if (NPCinterScript != null)
            {
                if (NPCinterScript.npctype == Interaction.NPCType.Farm)
                {
                    NPCinterScript.saveItems();
                }
            }
        }
    }
}