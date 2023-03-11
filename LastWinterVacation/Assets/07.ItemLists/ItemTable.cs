using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField]
    private byte Amount;
    public byte amount { get { return Amount; } }

    [SerializeField]
    private byte ItemNumber;
    public byte itemNumber { get { return ItemNumber; } }

    [SerializeField]
    private GameObject Model;
    public GameObject model { get { return Model; } }
    [SerializeField]
    private int ItemValue;
    public int itemValue { get { return ItemValue; } }
}
