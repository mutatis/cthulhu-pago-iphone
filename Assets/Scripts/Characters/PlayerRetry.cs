using UnityEngine;
using System.Collections;

public class PlayerRetry : MonoBehaviour {

	public void Retry()
	{
		transform.position = new Vector2(7.765f, 10);
		GameManager.coins = 0;
		Time.timeScale = 1;
		NotificationCenter.DefaultCenter().PostNotification(this, "OnResume");
		PlayerStatus.playerStatus.lives = 3;
	}
}
