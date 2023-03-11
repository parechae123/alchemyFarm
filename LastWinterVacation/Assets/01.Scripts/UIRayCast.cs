using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRayCast : MonoBehaviour
{
    private GraphicRaycaster gr;
    public GameObject obj;
    public LayerMask uiTaget;
    // Start is called before the first frame update
    void Start()
    {
        gr = GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(obj.transform.position, Vector3.forward * 100, Color.red);
        if (Physics.Raycast(obj.transform.position, Vector3.forward, 100, uiTaget))
        {
            Debug.Log("UI¥Í¿Ω");
        }
    }
}
