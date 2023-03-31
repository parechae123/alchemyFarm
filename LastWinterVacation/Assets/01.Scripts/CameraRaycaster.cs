using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    }
    void Update()
    {
        
        Ray ray = new Ray(transform.position, transform.forward * 10);
        if (Physics.Raycast(ray, out groundHit, 10, isGround))
        {
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
            rayPos = groundHit.point;
            cube.transform.position = rayPos;
            cube.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            Debug.DrawLine(targetColl.bounds.min, targetColl.bounds.max);
        }
        else
        {
            rayPos = new Vector3(0,0,0);
        }
    }
}
