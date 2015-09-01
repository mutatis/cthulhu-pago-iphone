using UnityEngine;
using System.Collections;

public class UI_PlayerIdols : MonoBehaviour
{

	void OnGUI ()
	{
		GetComponent<TextMesh>().text = GameManager.coins.ToString();
	}
}
