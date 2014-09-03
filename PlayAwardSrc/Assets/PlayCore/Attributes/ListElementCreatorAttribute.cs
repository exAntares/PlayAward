using UnityEngine;
using System.Collections;
using System;

public class ListElementCreatorAttribute : Attribute
{
    public Type BaseType { get; private set; }

    public ListElementCreatorAttribute(Type baseType)
    {
        BaseType = baseType;
    }
}
