using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBTN : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitFunction()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }
}
