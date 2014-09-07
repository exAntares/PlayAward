using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

using Actions;

namespace Core.ContextualActions.Actions
{
    [CustomPropertyDrawer(typeof(CAction), true)]
    public class CActionDrawer : PropertyDrawer
    {
        static Dictionary<int, SerializedObject> s_cachedObjects = new Dictionary<int, SerializedObject>();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.objectReferenceValue == null)
                return;  //Warning

            //Get the object--------------------
            SerializedObject serializeObject;
            Object unityObject = property.objectReferenceValue;
            if (!s_cachedObjects.TryGetValue(unityObject.GetInstanceID(), out serializeObject))
            {
                //Si la instancia del objeto no existe creamos una instancia serialziada nueva
                serializeObject = new SerializedObject(unityObject);
            }
            serializeObject.Update();
            //----------------------------------

            //Get the properties----------------
            System.Type propertyType = unityObject.GetType();
            //SerializedProperty propertyName = serializeObject.FindProperty("Name");

            //string headerLabel = propertyName.stringValue + " (" + GUIResources.SpaceCamelCaseWords(propertyType.ToString()) + ")";
            string headerLabel = GUIResources.SpaceCamelCaseWords(propertyType.ToString());
            SerializedProperty iterator = serializeObject.GetIterator();
            if (property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, headerLabel, true))
            {
                while (iterator.NextVisible(true))
                {
                    if (iterator.name != "m_Script")
                        EditorGUILayout.PropertyField(iterator, true);
                }
            }
            //----------------------------------

            //ApplyChanges ---------------------
            serializeObject.ApplyModifiedProperties();
            return;
            //----------------------------------
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}
