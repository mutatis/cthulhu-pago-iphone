using UnityEngine;
using System.Collections;

public class Repele : PowerUpBehaviour
{

	bool segue;
	int coins = 795;

	void Start()
	{
		transform.position = new Vector3(ola.oi.transform.position.x, transform.position.y + 25, transform.position.z);
		if(PlayerPrefs.GetInt("BuyGame") == 1)
		{
			gameObject.SetActive(false);
		}
	}

	void Update()
	{
		transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			Destroy(gameObject);
		}

		transform.position = new Vector3(PlayerStatus.playerStatus.transform.position.x, PlayerStatus.playerStatus.transform.position.y + 0.5f, PlayerStatus.playerStatus.transform.position.z);

		if(transform.position.y <= ola.oi.transform.position.y + 2)
		{
			IABuyDagon.buyDagon.aah = true;
		}
	}

	public override void ApplyEffect (Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			GetComponent<CircleCollider2D>().radius = 40;
			transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
			StartCoroutine("UsingMagnetic", 99999);
		}
		if (collider.CompareTag("Coin") && isInCharacter)
		{
			Repeleplayer followPlayer = collider.gameObject.AddComponent(typeof(Repeleplayer)) as Repeleplayer;
		}
	}
	
	/// <summary>
	/// Usings the magnetic.
	/// </summary>
	/// <returns>The magnetic.</returns>
	/// <param name="time">Time.</param>
	public IEnumerator UsingMagnetic (float time)
	{
		transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
		yield return new WaitForSeconds(1);
		segue = true;
		yield return new WaitForSeconds (time);
		transform.parent = null;
		PoolManager.Pools["props"].Despawn (transform);
	}
}



/*  public LayerMask MagnetLayer;
    public float FieldRadius;
    public float FieldForce;
    
    void FixedUpdate ()
    {
        
        Collider2D[] colliders;
        Rigidbody2D rigidbody;

        colliders = Physics2D.OverlapCircleAll(transform.position, FieldRadius, MagnetLayer);

        foreach(Collider2D collider in colliders)
        {
            rigidbody = collider.rigidbody2D;
            
            if(rigidbody== null )
            {
                continue;
            }
            print ("UsingMagnetic");
            rigidbody.AddForce((transform.position - collider.transform.position) * FieldForce);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere (transform.position, FieldRadius);
    }*/