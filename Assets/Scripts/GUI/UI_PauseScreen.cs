using UnityEngine;
using System.Collections;

public class UI_PauseScreen : MonoBehaviour
{

	// Use this for initialization
	public void Start ()
	{
        NotificationCenter.DefaultCenter().AddObserver(this, "OnPause");
        gameObject.SetActive(false);
	}

    void OnPause ()
    {
        gameObject.SetActive(true);
    }
}
