using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

public static class GUIResources 
{

    public static GUIContent AddIcon;
    public static GUIContent RemoveIcon;
    public static Color SeparatorColor = new Color(0.15f, 0.15f, 0.15f);

    static GUIResources()
    {
        AddIcon = new GUIContent("[ + ]");
        RemoveIcon = new GUIContent("[ - ]");
    }

    public static string SpaceCamelCaseWords(string label)
    {
        List<string> camelCaseWords = new List<string>();
        int index = 0;
        for (int i = 0; i < label.Length - 1; i++)
        {
            if (label[i] >= 'a' && label[i] <= 'z' && label[i + 1] >= 'A' && label[i + 1] <= 'Z')
            {
                camelCaseWords.Add(label.Substring(index, i-index+1));
                index = i+1;
            }
        }

        camelCaseWords.Add(label.Substring(index, label.Length - index));

        label = "";
        bool first = true;
        foreach (string s in camelCaseWords)
        {
            if (!first)
                label += " ";
            label += s;
            first = false;
        }

        return label;
    }
}
