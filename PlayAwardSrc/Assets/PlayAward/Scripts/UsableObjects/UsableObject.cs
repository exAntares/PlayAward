using UnityEngine;
using System.Collections;

public class UsableObject : MonoBehaviour
{
    public Renderer myRenderer;
    public Color TargetedColor = new Color(0.55f, 0.61f, 0.76f, 1.0f);
    protected Color OriginalColor = Color.white;

    private GameObject User;

    virtual public void Awake()
    {
        User = null;

        if (myRenderer)
        {
            OriginalColor = myRenderer.material.color;
        }
    }

    virtual public void OnUse(GameObject User)
    {
    }

    virtual public void OnTargeted()
    {
        if (myRenderer)
        {
            foreach (Material mat in myRenderer.materials)
            {
                mat.color = TargetedColor;
            }
        }
    }

    virtual public void OnStopTargeted()
    {
        if (myRenderer)
        {
            foreach (Material mat in myRenderer.materials)
            {
                mat.color = OriginalColor;
            }
        }
    }
}
