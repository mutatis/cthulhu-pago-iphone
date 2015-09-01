using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIText))]
public class UI_Record : MonoBehaviour
{
	Color originalColor;

    void Awake ()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "OnDead");
    }
	void Start ()
	{
		originalColor = guiText.color;
	}

	void OnDead ()
	{
		originalColor.a = 1f;
		//guiText.text = GameManager.gameManager.playerHighScore.ToString();
        guiText.text = "Current Record is " + PlayerStatus.playerStatus.transform.position.x.ToString("f1");

        guiText.color = originalColor;
	}
}