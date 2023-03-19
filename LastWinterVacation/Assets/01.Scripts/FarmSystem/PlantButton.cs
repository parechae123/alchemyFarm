using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlantButton : MonoBehaviour
{
    public ItemTable SeedInput;
    public Interaction TargetFarm;
    public Image BTcolor;
    private bool inDelay = false;
    public void PlantButtonClick()
    {
        if (SeedInput.itemType == ItemTable.ItemTypeList.Seed&&!inDelay)
        {
            StartCoroutine(ButtonDelay());
            Debug.Log("¾¾¾Ñ ÀÎ½Ä");
        }
    }
    IEnumerator ButtonDelay()
    {
        //B5B5B5
        TargetFarm.ToPlantingBT(inDelay);
        inDelay = true;
        BTcolor.color = Color.gray;
        yield return new WaitForSeconds(40);
        BTcolor.color = Color.white;
        inDelay = false;
    }
    public void colorState()
    {
        Debug.Log("Log0");
        Debug.Log(TargetFarm.plantingActive);
        if (TargetFarm.plantingActive)
        {
            inDelay = true;
            Debug.Log("Log1");
            BTcolor.color = Color.gray;
        }
        else
        {
            inDelay=false;
            BTcolor.color = Color.white;
            Debug.Log("Log2");

        }
        Debug.Log("Log3");
    }
}
