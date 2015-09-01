using UnityEngine;
using System.Collections;

public class DesligaGame : MonoBehaviour {

	public GameObject[] obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("BuyGame") == 1)
		{
			for(int i = 0; i < obj.Length; i++)
			{
				obj[i].SetActive(false);
			}
		}
	}
}
