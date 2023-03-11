using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemTest : MonoBehaviour
{

    public ItemTable what;
    public byte dd;
    public InventoryManager IM;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(test());
    }
    IEnumerator test()
    {
        for (byte i = 0; i <10; i++)
        {
            yield return new WaitForSeconds(2f);
            IM.getItem(what, dd);
        }
    }
}
