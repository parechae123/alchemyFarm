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
    public MeshRenderer mr;
    public MeshFilter mf;
    public Material[] mt = new Material[2];
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mf = GetComponent<MeshFilter>();
    }
    
    IEnumerator Grower()
    {
        for(plantLV = 0;plantLV < 5; plantLV++)
        {
            if(plantLV <= 2)
            {
                mt[0] = seedInfo.model[plantLV].GetComponent<MeshRenderer>().sharedMaterials[0];
                mt[1] = seedInfo.model[plantLV].GetComponent<MeshRenderer>().sharedMaterials[1];
                GetComponent<MeshRenderer>().materials = mt;
                mf.mesh = seedInfo.model[plantLV].GetComponent<MeshFilter>().sharedMesh;
            }
            yield return new WaitForSeconds(20);
        }

    }
}
