using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChaptersScript : MonoBehaviour
{
    public List<Chapter> ObjectsPerChapter;

    void Start()
    {
        GameObject globalEvents = GameObject.FindGameObjectWithTag("GlobalEvents");
        if (globalEvents)
        {
            globalEvents.RegisterFunctionToEvent(OnChapter2, "Capitulo 2");
            globalEvents.RegisterFunctionToEvent(OnChapter2, "Capitulo 3");
        }
    }

    [ContextMenu("OnChapter2")]
    virtual public void OnChapter2()
    {
        foreach (Chapter chapterObject in ObjectsPerChapter)
        {
            if (chapterObject.myChapter == Chapter.Chapters.Chapter2)
            {
                chapterObject.Show();
            }
            else
            {
                chapterObject.Hide();
            }
        }
    }

    [ContextMenu("OnChapter3")]
    virtual public void OnChapter3()
    {
        foreach (Chapter chapterObject in ObjectsPerChapter)
        {
            if (chapterObject.myChapter == Chapter.Chapters.Chapter3)
            {
                chapterObject.Show();
            }
            else
            {
                chapterObject.Hide();
            }
        }
    }
}

[System.Serializable]
public class Chapter
{
    public enum Chapters
    {
        Chapter1,
        Chapter2,
        Chapter3
    }

    public Chapters myChapter;
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