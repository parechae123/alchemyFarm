using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlantButton : MonoBehaviour
{
    public ItemTable SeedInput;
    public Interaction TargetFarm;
    private Image BTcolor;
    private bool inDelay = false;
    private void Awake()
    {
        BTcolor = GetComponent<Image>();
    }
    public void PlantButtonClick()
    {
        if (SeedInput.itemType == ItemTable.ItemTypeList.Seed&&!inDelay&&!TargetFarm.plantingActive)
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
/*        if (TargetFarm.plantingActive)
        {
            Debug.Log("Log1");
            BTcolor.color = Color.gray;
        }
        else
        {
            Debug.Log("Log2");
            BTcolor.color = Color.white;
        }*/
        Debug.Log("Log3");
    }
}
