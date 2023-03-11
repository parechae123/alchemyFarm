using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Changer : MonoBehaviour
{
    // Start is called before the first frame update
    public int[] tester;
    public List<GameObject> TesterOBJ = new List<GameObject>();
    void Start()
    {
        tester = new int[20];
        StartCoroutine("testerCo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator testerCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            TesterOBJ.Add(gameObject);
        }
    }
}
