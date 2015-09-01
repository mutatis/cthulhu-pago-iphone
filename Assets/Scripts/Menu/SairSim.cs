using UnityEngine;
using System.Collections;

public class SairSim : MonoBehaviour {

	public void Sim()
	{
		PlayerPrefs.SetInt("timeS", 0);
		PlayerPrefs.SetInt("cuzinho", 0);
		Application.Quit();
	}
}
