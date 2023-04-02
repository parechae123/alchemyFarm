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
    public GameObject testOBJ;
    [SerializeField]private Material previewMaterial;

    private void Awake()
    {
        GetBlockInfo(testOBJ);
    }
    public void GetBlockInfo(GameObject readyPreview)
    {
        StartCoroutine(previewer(readyPreview));
    }
    IEnumerator previewer(GameObject preview)
    {
        GameObject previewTarget = Instantiate(preview);
        previewTarget.GetComponent<MeshRenderer>().material = previewMaterial;
        BoxCollider targetColl = previewTarget.GetComponent<BoxCollider>();
        targetColl.isTrigger = true;
        float targetYSize = targetColl.bounds.size.y / 2f;
        Debug.Log(targetColl.bounds.size);
        while (true)
        {
            yield return new WaitForEndOfFrame();
            Ray ray = new Ray(transform.position, transform.forward * 10);
            if (Physics.Raycast(ray, out groundHit, 10, isGround))
            {
                Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
                rayPos = new Vector3(groundHit.point.x, groundHit.point.y+targetYSize, groundHit.point.z);
                previewTarget.transform.position = rayPos;
                previewTarget.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            }
            else
            {
                rayPos = new Vector3(0, -100, 0);
            }
        }
    }
}