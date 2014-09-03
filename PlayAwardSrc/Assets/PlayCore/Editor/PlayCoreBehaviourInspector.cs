using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PlayCoreBehaviour), true)]
public class CoreBehaviourInspector : Editor
{
    private GameObject _targetGO;
    private PlayCoreBehaviour _targetBehaviour;
    private System.Type _targetBehaviourType;

    protected virtual void OnEnable()
    {
        _targetBehaviour = (PlayCoreBehaviour)serializedObject.targetObject;
        _targetGO = _targetBehaviour.gameObject;
        _targetBehaviourType = _targetBehaviour.GetType();
    }

    public override void  OnInspectorGUI()
    {
 	    serializedObject.Update();
        SerializedProperty iterator = serializedObject.GetIterator();
        iterator.NextVisible(true);

        do
        {
            if(iterator.isArray && iterator.propertyType != SerializedPropertyType.String)
            {
                
                EnhancedListDrawer.DrawList(
			    iterator,
			    GUI.skin.box,
			    GUI.skin.box,
                _targetBehaviourType,
                _targetGO);              
            }
            else EditorGUILayout.PropertyField(iterator, true);

            serializedObject.ApplyModifiedProperties();
        } while (iterator.NextVisible(false));
    } 

    protected GameObject TargetGameObject { get { return _targetGO; } }
	protected PlayCoreBehaviour TargetBehaviour { get { return _targetBehaviour; } }
}
