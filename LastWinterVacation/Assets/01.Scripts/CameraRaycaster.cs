using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;



public class CameraRaycaster : MonoBehaviour
{
    public LayerMask isGround;
    private RaycastHit groundHit;
    public Vector3 rayPos;
    private GameObject cube;
    public BoxCollider targetColl;
    private void Awake()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        targetColl = cube.GetComponent<BoxCollider>();
        targetColl.isTrigger = true;
        GetBlockInfo(cube);
    }
    public void GetBlockInfo(GameObject preview)
    {
        MeshFilter filter = preview.GetComponent<MeshFilter>();
        preview.GetComponent<MeshRenderer>().material = null;
        StartCoroutine(previewer(preview,filter));
    }
    IEnumerator previewer(GameObject preview,MeshFilter filter)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            Ray ray = new Ray(transform.position, transform.forward * 10);
            if (Physics.Raycast(ray, out groundHit, 10, isGround))
            {
                Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
                rayPos = groundHit.point;
                preview.transform.position = rayPos;
                preview.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            }
            else
            {
                rayPos = new Vector3(0, -100, 0);
            }
        }
    }
}