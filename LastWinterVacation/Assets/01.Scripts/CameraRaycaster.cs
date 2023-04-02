using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;



public class CameraRaycaster : MonoBehaviour
{
    public LayerMask isGround;
    public LayerMask objectInstallable;
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
        Vector3 targetSize = targetColl.bounds.size/ 2f;
        float TargetDistance = Vector3.Distance(targetSize, -targetSize );
        Debug.Log("ªÁ¿Ã¡Ó" + targetColl.bounds.size);
        Debug.Log("∏∆Ω∫" + targetColl.bounds.max);
        Debug.Log("πŒ" + targetColl.bounds.min);
        Debug.Log("ºæ≈Õ" + targetColl.bounds.center);
        Debug.Log("¿Õ≈Ÿ∆Æ" + targetColl.bounds.extents);
        bool isCollided = false;
        Debug.Log(TargetDistance);
        while (true)
        {
            yield return new WaitForEndOfFrame();
            Ray ray = new Ray(transform.position, transform.forward * 10);
            if (Physics.Raycast(ray, out groundHit, 10, isGround))
            {
                Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
                rayPos = new Vector3(groundHit.point.x, groundHit.point.y+targetSize.y, groundHit.point.z);
                previewTarget.transform.position = rayPos;
                previewTarget.transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                if (Physics.BoxCast(previewTarget.transform.position, targetSize, previewTarget.transform.position, previewTarget.transform.rotation, targetSize.x * 1.2f, objectInstallable, QueryTriggerInteraction.UseGlobal))
                {
                    if (isCollided)
                    {
                        isCollided = false;
                        previewMaterial.color = Color.red;
                    }
                }
                else
                {
                    if (!isCollided)
                    {
                        isCollided = true;
                        previewMaterial.color = Color.green;
                    }
                }
            }
                else
                {
                    rayPos = new Vector3(0, -100, 0);
                }
        }
    }
}