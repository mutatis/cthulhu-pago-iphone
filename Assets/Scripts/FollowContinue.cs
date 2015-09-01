using UnityEngine;
using System.Collections;

public class FollowContinue : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(PlayerStatus.playerStatus.transform.position.x - 0.2f, PlayerStatus.playerStatus.transform.position.y + 5, PlayerStatus.playerStatus.transform.position.z);
		if(GameManager.gameManager.hasContinue == false)
		{
			Destroy(gameObject);
		}
	}
}
