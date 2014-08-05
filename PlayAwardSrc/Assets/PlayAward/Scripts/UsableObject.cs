using UnityEngine;
using System.Collections;

public class UsableObject : MonoBehaviour
{
    public Renderer myRenderer;
    public Color TargetedColor = new Color(0.55f, 0.61f, 0.76f, 1.0f);
    protected Color OriginalColor = Color.white;

    virtual public void Awake()
    {
        if (myRenderer)
        {
            OriginalColor = myRenderer.material.color;
        }
    }

    virtual public void OnUse()
    {
    }

    virtual public void OnTargeted()
    {
        if (myRenderer && myRenderer.material)
        {
            myRenderer.material.color = TargetedColor;
        }
    }

    virtual public void OnStopTargeted()
    {
        if (myRenderer && myRenderer.material)
        {
            myRenderer.material.color = OriginalColor;
        }
    }
}
