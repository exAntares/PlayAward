using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
public class ScreenFadeInOut : MonoBehaviour
{
	public float fadeSpeed = 0.1f;          // Speed that the screen fades to and from black.
	
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		// Make sure the texture is enabled.
		guiTexture.enabled = false;
	}

	[ContextMenu("FadeIn")]
	public void FadeIn()
	{
		StartCoroutine(FadingIn());
	}

	[ContextMenu("FadeInOut")]
	public void FadeInOut()
	{
		StartCoroutine(FadingInOut());
	}

	void FadeOut()
	{
		StartCoroutine(FadingOut());
	}

	void FadeToClear ()
	{
		Color guiTextColor = guiTexture.color;

		guiTextColor.a -= fadeSpeed * Time.deltaTime;

		guiTexture.color = guiTextColor;
	}
	
	
	void FadeToBlack ()
	{
		Color guiTextColor = guiTexture.color;

		guiTextColor.a += fadeSpeed * Time.deltaTime;

		guiTexture.color = guiTextColor;
	}
	
	
	IEnumerator FadingOut ()
	{
		// If the texture is almost clear...
		while(guiTexture.color.a > 0.01f)
		{
			// Fade the texture to clear.
			FadeToClear();

			yield return 0;
		}

		// ... set the colour to clear and disable the GUITexture.
		guiTexture.color = Color.clear;
		guiTexture.enabled = false;

	}
	
	
	IEnumerator FadingIn()
	{
		while(guiTexture.color.a < 0.7f)
		{
			// Make sure the texture is enabled.
			guiTexture.enabled = true;
		
			// Start fading towards black.
			FadeToBlack();

			yield return 0;
		}
	}

	IEnumerator FadingInOut()
	{
		while(guiTexture.color.a < 0.7f)
		{
			// Make sure the texture is enabled.
			guiTexture.enabled = true;
			
			// Start fading towards black.
			FadeToBlack();
			
			yield return 0;
		}
		
		Invoke("FadeOut", 2.0f);
	}
}
