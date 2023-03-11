using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string whatIsThisObject;
    enum NPCType
    {
        Farmer,
        Miner, 
        Alchemist,
        GeneralStore
    }
    [SerializeField]
    NPCType npctype;

    public bool isActivated = false;
    public GameObject UI;
    [SerializeField] private bool[] isSlotEmpty;
    [SerializeField] private ItemTable[] npcItems;
    public void UIset()
    {
        Debug.Log("�ڿ�����");
        isSlotEmpty = new bool[UI.transform.childCount];
        npcItems = new ItemTable[UI.transform.childCount];
    }
}
