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
            globalEvents.RegisterFunctionToEvent(OnChapter1, "Capitulo 1");
            globalEvents.RegisterFunctionToEvent(OnChapter2, "Capitulo 2");
            globalEvents.RegisterFunctionToEvent(OnChapter3, "Capitulo 3");
        }
    }

    [ContextMenu("OnChapter1")]
    virtual public void OnChapter1()
    {
        foreach (Chapter chapterObject in ObjectsPerChapter)
        {
            if (chapterObject.myChapter == Chapter.Chapters.Chapter_1)
            {
                chapterObject.Show();
            }
            else
            {
                chapterObject.Hide();
            }
        }
    }

    [ContextMenu("OnChapter2")]
    virtual public void OnChapter2()
    {
        foreach (Chapter chapterObject in ObjectsPerChapter)
        {
            if (chapterObject.myChapter == Chapter.Chapters.Chapter_2)
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
            if (chapterObject.myChapter == Chapter.Chapters.Chapter_3)
            {
                chapterObject.Show();
            }
            else
            {
                chapterObject.Hide();
            }
        }
    }

    void OnValidate()
    {
        foreach (Chapter chapterObject in ObjectsPerChapter)
        {
            chapterObject.UpdateName();
        }
    }
}

[System.Serializable]
public class Chapter
{
    public enum Chapters
    {
        Chapter_1,
        Chapter_2,
        Chapter_3
    }

    [HideInInspector]
    public string name;
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

    public void UpdateName()
    {
        name = ChapterObject ? ChapterObject.name : "null";
    }
}