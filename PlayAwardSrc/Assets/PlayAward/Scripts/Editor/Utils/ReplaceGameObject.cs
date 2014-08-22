using UnityEngine;
using UnityEditor;
using System.Collections;

public class ReplaceGameObjectWindow : EditorWindow 
{
    public GameObject Prefab;
    public Vector3 TranslationOffset = Vector3.zero;
    public Vector3 RotationOffset = Vector3.zero;
    public Vector3 ScaleOffset = Vector3.one;
    bool sameObjects = false;

    [MenuItem("Utils/Replace GameObject")]
    static void Init()
    {
        ReplaceGameObjectWindow replaceWindow = (ReplaceGameObjectWindow)EditorWindow.GetWindow(typeof(ReplaceGameObjectWindow));
    }

    void OnGUI()
    {

        EditorGUILayout.BeginHorizontal();
        //GUILayout.Label("Don't rplace: ");

        
        if (!(sameObjects = EditorGUILayout.Toggle(sameObjects)))
        {
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Prefab:");
            Prefab = (GameObject)EditorGUILayout.ObjectField(Prefab, typeof(GameObject), true);
            EditorGUILayout.EndHorizontal();
        }
        else EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();                
        
        /*
        TranslationOffset = EditorGUILayout.Vector3Field("Position Offset", TranslationOffset);
        RotationOffset = EditorGUILayout.Vector3Field("Rotation Offset", RotationOffset);
        ScaleOffset = EditorGUILayout.Vector3Field("Scale Offset", ScaleOffset);
        */


        GUILayout.Label("Select GameObject in scene");
        if (GUILayout.Button("Change"))
        {
            GameObject [] selection = Selection.gameObjects;
            foreach(GameObject go in selection)
            {               
                GameObject replacement = ReplaceGameObject(Prefab, go);
            }
        }
    }

    public GameObject ReplaceGameObject(GameObject replacement, GameObject original)
    {
        replacement = (GameObject) PrefabUtility.InstantiatePrefab((Object)replacement);
        
        Transform otransform = original.transform;
        Transform rTransform = replacement.transform;

        rTransform.parent = otransform.transform.parent;
        replacement.name = replacement.name;
        rTransform.localPosition = otransform.localPosition;
        rTransform.localScale = otransform.localScale;
        rTransform.localRotation = otransform.localRotation;
        /*
        rTransform.localPosition += TranslationOffset;
        rTransform.localScale += ScaleOffset;
        rTransform.localRotation = Quaternion.EulerAngles(RotationOffset + rTransform.localRotation.eulerAngles);
        */
        DestroyImmediate(original);
        
        return replacement;        
    }
}
