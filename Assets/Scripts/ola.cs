using UnityEngine;
using System.Collections;

public class ola : MonoBehaviour {

	public static ola oi;

	void Awake()
	{
		oi = this;
	}

	// Use this for initialization
	void Start () {
		GameManager.coins = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(PlayerStatus.playerStatus.transform.position.x, PlayerStatus.playerStatus.transform.position.y, PlayerStatus.playerStatus.transform.position.z);
	}
}
