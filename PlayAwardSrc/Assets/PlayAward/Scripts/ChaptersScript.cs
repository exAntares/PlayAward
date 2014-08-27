using UnityEngine;
using System.Collections;

public class ChaptersScript : MonoBehaviour
{
    public Chapter Chapter1 = null;
    public Chapter Chapter2 = null;
    public Chapter Chapter3 = null;

    void Start()
    {
        GameObject globalEvents = GameObject.FindGameObjectWithTag("GlobalEvents");
        if (globalEvents)
        {
            globalEvents.RegisterFunctionToEvent(OnChapter2, "Capitulo 2");
        }
    }

    [ContextMenu("OnChapter2")]
    virtual public void OnChapter2()
    {
        if (Chapter1 != null)
        {
            Chapter1.Hide();
        }

        if (Chapter2 != null)
        {
            Chapter2.Show();
        }
    }

    [ContextMenu("OnChapter3")]
    virtual public void OnChapter3()
    {
        if (Chapter2 != null)
        {
            Chapter2.Hide();
        }

        if (Chapter3 != null)
        {
            Chapter3.Show();
        }
    }
}

[System.Serializable]
public class Chapter
{
    public GameObject ChapterObject;

    public void Show()
    {
        if (ChapterObject)
        {
            ChapterObject.SetActive(true);
        }
    }

    public void Hide()
    {
        if (ChapterObject)
        {
            ChapterObject.SetActive(false);
        }
    }

}