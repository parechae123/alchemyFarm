using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlantButton : MonoBehaviour
{
    public ItemTable SeedInput;
    public Interaction TargetFarm;
    private bool inDelay = false;
    public void PlantButtonClick()
    {
        if (SeedInput.itemType == ItemTable.ItemTypeList.Seed&&!inDelay)
        {
            inDelay = true;
            StartCoroutine(ButtonDelay());
            Debug.Log("¾¾¾Ñ ÀÎ½Ä");
        }
    }
    IEnumerator ButtonDelay()
    {
        TargetFarm.ToPlantingBT();
        yield return new WaitForSeconds(40);
        inDelay = false;
    }
}
