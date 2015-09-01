using UnityEngine;
using System.Collections;

public class tesna : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clico()
	{
		GameManager.gameManager.AddCoin(10);	
	}

}
