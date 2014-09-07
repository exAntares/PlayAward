using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;

public static class EnhancedListDrawer
{
    private static class Styles
    {
        private static GUIStyle _button;
        public static GUIStyle Button
        {
            get
            {
                if (_button == null)
                {
                    _button = EditorStyles.miniButton;
                    _button.padding = new RectOffset();
                }
                return _button;
            }
        }
    }

    public class CreationData
    {
        public Type type;
        public SerializedProperty property;
        public GameObject targetGameObject;
    }

    public static void DrawList(SerializedProperty listProperty,
        GUIStyle listStyle,
        GUIStyle elementStyle,
        Type declaringType,
        GameObject targetGameObject)
    {
        UnityEngine.Object target = listProperty.serializedObject.targetObject;

        if (listStyle != null)            
            GUILayout.BeginVertical(listStyle);            
        else 
            GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();

        //Foldout
        string propertyLabel =GUIResources.SpaceCamelCaseWords(listProperty.name);
        string propertyHeaderLabel = propertyLabel + " (" + listProperty.arraySize + ")";
            
        Vector2 buttonSize = Styles.Button.CalcSize(GUIResources.AddIcon);
        Rect controlRect = EditorGUILayout.GetControlRect(true, buttonSize.y, GUILayout.ExpandWidth(true));

        Rect header = controlRect;
		header.width -= buttonSize.x;

        //List label
        EditorGUI.BeginProperty(header, new GUIContent(propertyHeaderLabel), listProperty);

        listProperty.isExpanded = EditorGUI.Foldout(header, listProperty.isExpanded, propertyHeaderLabel, true);

        EditorGUI.EndProperty();

        ListElementCreatorAttribute elementCreator = null;
        if (declaringType != null)
        {
            elementCreator = Attribute.GetCustomAttribute(declaringType.GetField(listProperty.name), typeof(ListElementCreatorAttribute)) as ListElementCreatorAttribute;
        }

        Rect buttonRect = controlRect;
        buttonRect.x = header.x + header.width;
        buttonRect.width = buttonSize.x;

        if(GUI.Button(buttonRect, GUIResources.AddIcon, Styles.Button))
        {
            if(elementCreator == null)
            {
                Undo.RecordObject(target, "Add element");
                ++listProperty.arraySize;
            }
            else
            {
                //Get allowerd types to instantiate (Inheritance magic)
                Type [] allowTypes = declaringType.Assembly.GetTypes().Where(
                    type => type.IsSubclassOf(elementCreator.BaseType) && !type.IsAbstract).ToArray();

                GenericMenu menu = new GenericMenu();

                foreach(Type allowedType in allowTypes)
                {
                    GUIContent itemContent = new GUIContent(allowedType.Name);

                    //TODO Revisar
                    menu.AddItem(
                        itemContent,
                        false,
                        (type) => //Magic Callback
                            {
                                CreationData cData = type as CreationData;
                                if( cData.type.IsSubclassOf(typeof(Component)))
                                {
                                    ++cData.property.arraySize;
                                    Component newComponent = Undo.AddComponent(targetGameObject, cData.type);
                                    newComponent.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
                                    cData.property.GetArrayElementAtIndex(cData.property.arraySize - 1).objectReferenceValue = newComponent;
                                }
                                else
                                {
                                    Undo.RecordObject(target, "Add element");
                                    ++cData.property.arraySize;
                                }
                                cData.property.serializedObject.ApplyModifiedProperties();
                            },
                        new CreationData { property = listProperty.Copy(), type = allowedType});                    
                                        
                }
                menu.ShowAsContext();
            }
        }

        if(elementStyle != null) //Hack. Fit better
            elementStyle.margin = new RectOffset();

        GUILayout.EndHorizontal();


        if(listProperty.isExpanded)
        {
            ++EditorGUI.indentLevel;
            SerializedProperty propertyToDelete = null;
            int indexToDelete = -1;
            int currentIndex = 0;
            GUIContent label = new GUIContent();
            foreach (SerializedProperty element in listProperty)
            {
                GUILayout.Space(1f);
                Rect separator = EditorGUILayout.BeginVertical();
                GUILayout.Space(4f);
                EditorGUILayout.BeginHorizontal();
                separator.height = 3f;

                EditorGUI.DrawRect(separator, GUIResources.SeparatorColor);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
                    
                GUILayout.BeginHorizontal();
                label.text = propertyLabel + " " + currentIndex;
                if(elementStyle != null)                   
                    GUILayout.BeginVertical(elementStyle);                    
                else
                    GUILayout.BeginVertical();

                EditorGUILayout.PropertyField(element, label, true, GUILayout.ExpandWidth(true));
                GUILayout.EndVertical();

                float min, max;
				EditorStyles.miniButton.CalcMinMaxWidth(GUIResources.RemoveIcon, out min, out max);
                if(GUILayout.Button(GUIResources.RemoveIcon, Styles.Button, GUILayout.MaxWidth(min)))
                {
                    propertyToDelete = element;
                    indexToDelete = currentIndex;
                }
                GUILayout.EndHorizontal();
                ++currentIndex;
            }

            if(propertyToDelete != null)
            {
                Undo.RecordObject(target, "Delete element");
                if(propertyToDelete.propertyType == SerializedPropertyType.ObjectReference && propertyToDelete.objectReferenceValue != null)
                {
                    if(propertyToDelete.objectReferenceValue is Component)
                        Undo.DestroyObjectImmediate(propertyToDelete.objectReferenceValue);
                    propertyToDelete.DeleteCommand();
                }
                listProperty.DeleteArrayElementAtIndex(indexToDelete);
            }

            --EditorGUI.indentLevel;
        }
        GUILayout.EndVertical();
    }
}


