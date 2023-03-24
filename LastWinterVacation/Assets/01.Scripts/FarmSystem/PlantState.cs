using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantState : MonoBehaviour
{
    [SerializeField]private ItemTable seedInfo;
    public ItemTable SeedInfo
    {
        get { return seedInfo; }
        set 
        { 
            seedInfo = value;
            StartCoroutine(Grower());
        }
    }
    private byte plantLV = 0;
    public MeshRenderer plantRenderer;
    public MeshFilter plantMeshFilter;
    private void Start()
    {
        plantRenderer = GetComponent<MeshRenderer>();
        plantMeshFilter = GetComponent<MeshFilter>();
    }
    
    IEnumerator Grower()
    {
        for(plantLV = 0;plantLV < 5; plantLV++)
        {
            if(plantLV <= 3)
            {
                plantRenderer = seedInfo.model[plantLV].GetComponent<MeshRenderer>();
                plantMeshFilter = seedInfo.model[plantLV].GetComponent<MeshFilter>();
            }
            yield return new WaitForSeconds(20);
        }

    }
}
