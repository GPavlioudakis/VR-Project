using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{
    AssetBundle loadedAssetbundle;
    public string assetBundleUrl;
    public string assetName;
    GameObject childObject;
    Object prefab;

    public void Generate()
    {
        Destroy(childObject);

        ImportAssetBundle(assetBundleUrl);
        InstantiateObjFromAssetBundle(assetName);
    }
    
    
    void ImportAssetBundle(string url)
    {
        loadedAssetbundle = AssetBundle.LoadFromFile(url);

        Debug.Log(loadedAssetbundle == null ? "Failed to load assetbundle" : "Assetbundle successfully loaded");
    }

    void InstantiateObjFromAssetBundle(string assetName)
    {
        prefab = loadedAssetbundle.LoadAsset(assetName);
        childObject = Instantiate(prefab) as GameObject;
        loadedAssetbundle.Unload(false);
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * 4f;
        childObject.transform.parent = transform;
        childObject.transform.position = transform.position;//Moves target in front of the camera
    }
}
