using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCaster : MonoBehaviour
{
    public Material mt;
    public BoxCollider BC;
    public LayerMask whatLayer;

    // Start is called before the first frame update
    void Start()
    {
        mt = GetComponent<MeshRenderer>().material;
        BC = GetComponent<BoxCollider>();
        gameObject.layer = 3;
    }

    void Update()
    {
        if (Physics.BoxCast(new Vector3(transform.position.x, transform.position.y - BC.bounds.size.y, transform.position.z) - Vector3.up, BC.bounds.extents, Vector3.up, transform.rotation, BC.bounds.size.x * 1.3f, whatLayer))
        {
            //대상 오브젝트의 layer는 whatLayer안에 들어오면 안됨
            //설치시 layer를 원래상태로 돌려줘야함
            mt.color = Color.red;
        }
        else
        {
            mt.color = Color.green;
        }
    }
}

