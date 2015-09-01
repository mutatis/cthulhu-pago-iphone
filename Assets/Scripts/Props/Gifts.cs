using UnityEngine;
using System.Collections;

public class Gifts : MonoBehaviour
{
    public PowerUpBehaviour[] powerUps;
	public AudioClip[] au;

	void Update()
	{
		if(transform.position.y < PlayerStatus.playerStatus.sombraBomb.position.y + 2)
		{
			rigidbody2D.fixedAngle = true;
			transform.position = new Vector3(transform.position.x, PlayerStatus.playerStatus.sombraBomb.position.y + 2, transform.position.z);
		}
	}

    void OnTriggerEnter2D (Collider2D collision)
    {
        audio.Play();
        if (collision.transform.tag == "Player")
        {
			if(PlayerPrefs.GetString("Dagon") == "Dagon")
			{
				AudioSource.PlayClipAtPoint(au[0], transform.position, 1f);
			}
			else
			{
				AudioSource.PlayClipAtPoint(au[1], transform.position, 1f);
			}
			PlayerPrefs.SetInt("Presente", 1);
			GameManager.gameManager.Gift();
            NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveAGift");
            PoolManager.Pools["props"].Despawn(transform);
        }
    }
}
