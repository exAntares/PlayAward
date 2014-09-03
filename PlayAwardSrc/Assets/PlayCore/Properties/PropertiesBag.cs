using UnityEngine;
using System.Collections;


[System.Serializable]
public class PropertiesBag : PlayCoreBehaviour
{
    [ListElementCreator(typeof(CPropertyBase))]
    public CPropertyBase[] Properties;
    
}
