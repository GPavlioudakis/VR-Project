using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetBundleBuilder : Editor
{
    [MenuItem("Assets/ Build AssetBundle")]
    static void BuildAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(@"Assets/Assetbundles", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }


}
