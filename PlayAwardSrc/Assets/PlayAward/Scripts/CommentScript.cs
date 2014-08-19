using UnityEngine;
using System.Collections;

public class CommentScript : MonoBehaviour
{

    [Multiline]
    public string Comment;

	// Use this for initialization
	void Start ()
    {
        UpdateText();
	}

    [ContextMenu("UpdateText")]
    void UpdateText()
    {
        TextMesh textMesh = GetComponent<TextMesh>();
        if (textMesh)
        {
            textMesh.text = Comment;
        }

    }
}
