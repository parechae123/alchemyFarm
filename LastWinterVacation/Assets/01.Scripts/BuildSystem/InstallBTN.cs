using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InstallBTN : MonoBehaviour
{
    // Start is called before the first frame update
    public CameraRaycaster cmrRaycaster;
    public bool isInstalling = false;
    public void OnInstallBTN(GameObject itemInfo)
    {
        if (!isInstalling)
        {
            cmrRaycaster.GetBlockInfo(itemInfo);
            isInstalling = true;
        }
    }
}
