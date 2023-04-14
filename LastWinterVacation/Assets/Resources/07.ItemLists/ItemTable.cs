using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Object/Item Lists", order = int.MaxValue)]
public class ItemTable : ScriptableObject
{
    [SerializeField]
    private Sprite Icon;
    public Sprite icon { get { return Icon; } }

    [SerializeField]
    private string ItemName;
    public string itemName { get { return ItemName; } }
    //Enum 
    public enum ItemTypeList {Empty,Seed,EquipMents,Alchmies, Furniture,HomeBluePrints,TableObjects,Adult }
    [SerializeField]
    private ItemTypeList ItemType;
    public ItemTypeList itemType { get { return ItemType; } }

    [SerializeField]
    private byte Amount;
    public byte amount { get { return Amount; } }

    [SerializeField]
    private byte ItemNumber;
    public byte itemNumber { get { return ItemNumber; } }

    [SerializeField]
    private GameObject[] Model = new GameObject[5];
    public GameObject[] model { get { return Model; } }
    [SerializeField]
    private int ItemValue;
    public int itemValue { get { return ItemValue; } }
    [SerializeField]
    private ItemTable adult;
    public ItemTable Adult { get { return adult; } }
}
