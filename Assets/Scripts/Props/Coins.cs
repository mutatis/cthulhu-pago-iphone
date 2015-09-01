using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour
{
	const float timeToPitchBack = 0.4f;

	static float pitch ;
	static float timeFromLastCoin ;

	public AudioClip pickupClip;

	SpriteRenderer coin;

	private float actualTime;

	void Start()
	{
		coin = GetComponent<SpriteRenderer>();
		if(GameManager.gameManager.doubleCoin)
		{
			coin.color = new Color(1, 0.5f, 0.5f, 1);
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.activeSelf)
            return;
        if (other.tag != "Player")
            return;

        actualTime = Time.time;
		if(GameManager.gameManager.permanentTrippleCoin)
		{
			GameManager.gameManager.AddCoin();
			GameManager.gameManager.AddCoin();
		}
		if(GameManager.gameManager.permanentDoubleCoin)
			GameManager.gameManager.AddCoin();
		else if (GameManager.gameManager.doubleCoin)
			GameManager.gameManager.AddCoin();
		GameManager.gameManager.AddCoin();
		if (timeFromLastCoin + timeToPitchBack > actualTime)
			pitch = 1;
		else
			pitch += 0.4f;

		audio.pitch = pitch;

		// Play the collection sound.
        AudioSource.PlayClipAtPoint(pickupClip, transform.position, 1f);
        timeFromLastCoin = Time.time;
		Destroy(gameObject);

        //PoolManager.Pools["props"].Despawn(transform);
    }
}