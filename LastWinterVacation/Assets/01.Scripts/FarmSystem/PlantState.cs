using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantState : MonoBehaviour
{
    public ItemTable SeedInfo;
    private byte PlantLV;
    public byte plantLV
    {
        get { return PlantLV; }
        set 
        {
            PlantLV = value;
            Debug.Log(plantLV);
            switch (plantLV)
            {
                case 1:
                    Debug.Log("¿œ");
                    break;
                case 2:
                    Debug.Log("¿Ã");
                    break;
                case 3:
                    Debug.Log("ªÔ");
                    break;
                case 4:
                    Debug.Log("ªÁ");
                    break;
                case 5:
                    Debug.Log("ø¿");
                    break;
            }
        }
    }
    private void Start()
    {
        StartCoroutine(Grower());
    }
    
    IEnumerator Grower()
    {
        for (byte i = 0; i<5; i++)
        {
            yield return new WaitForSeconds(2);
            plantLV++;
        }
    }
}
