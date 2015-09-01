using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIText))]
public class UI_NewRecord : MonoBehaviour
{
	Color originalColor;
	void Awake ()
	{
		NotificationCenter.DefaultCenter().AddObserver(this, "OnNewRecord");
	}
	
	void Start ()
	{
		originalColor = guiText.color;

	}

	void OnNewRecord ()
	{
		originalColor.a = 1f;
		guiText.color = originalColor;
	}
}

