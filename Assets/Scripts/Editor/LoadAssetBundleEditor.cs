using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime;


[CustomEditor(typeof(LoadAssetBundle))]

public class LoadAssetBundleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LoadAssetBundle Lab = (LoadAssetBundle)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            Lab.Generate();
        }
    }
}
