using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraHistory : MonoBehaviour 
{
	int press;
	int posX = 0;
	public Button setaD;
	public Button setaE;
	public GameObject setaR;
	public GameObject camera;
	public GameObject menu;
	public GameObject esconde;
	public Transform camera1;
	public GameObject canvas;
	public string level;
	int time = 0;

	// Update is called once per frame
	void Update () 
	{
		if(press < 0)
		{
			press = 0;
		}
		if(press == 0)
		{
			setaE.enabled  = false;
			camera1.position = new Vector3(0, 0, -10);
		}
		else if(press == 1)
		{
			setaE.enabled = true;
			camera1.position = new Vector3(20, 0, -10);
		}
		else if(press == 2)
		{
			camera1.position = new Vector3(40, 0, -10);
		}
		else if(press == 3)
		{
			camera1.position = new Vector3(60, 0, -10);
		}
		else if(press == 4)
		{
			camera1.position = new Vector3(80, 0, -10);
		}
		else if(press == 5)
		{
			camera1.position = new Vector3(100, 0, -10);
		}
		else if(press == 6)
		{
			camera1.position = new Vector3(120, 0, -10);
			setaD.enabled = true;
		}
		else if(press >= 7)
		{
			camera1.position = new Vector3(140, 0, -10);
			setaD.enabled = false;
			menu.SetActive(true);
		}
	}

	public void Next()
	{
		press += 1;
	}

	public void Previous()
	{
		press -= 1;
	}
}
