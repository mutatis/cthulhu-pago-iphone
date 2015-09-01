using UnityEngine;
using System.Collections;

public class MagneticBehaviour : PowerUpBehaviour
{

	public AudioSource shield;
	public AudioClip[] getD;
	public AudioClip[] getC;
	int random;
	bool ok;
	public AudioClip clip;
	float o;
	float tempo = 5f;

	private Vector3 directionToMove;

	void Start()
	{
		tempo += PlayerPrefs.GetFloat("Whirl");
	}

	void Update()
	{
		if ((Vector3.Distance(transform.position, IABuyDagon.buyDagon.transform.position) < 60) && ok == false)
		{
			directionToMove = new Vector3 (25f*Time.deltaTime,Mathf.Sin(2*Time.time)*0.4f,0);
			if ((transform.position.y < 0 && directionToMove.y < 0)||(transform.position.y > 30 && directionToMove.y > 0))
			{
				directionToMove = new Vector3 (directionToMove.x,-directionToMove.y,directionToMove.z);
			}
			transform.Translate(directionToMove);
		}
		if (Vector3.Distance(transform.position, PlayerStatus.playerStatus.transform.position) < 60)
		{
			if(!shield.isPlaying && ok == false)
			{
				shield.Play();
				shield.volume = 1;
			}
		}
		else
		{
			shield.Stop();
			shield.volume = 0;
		}

		if(ok)
		{
			transform.position = new Vector3(PlayerStatus.playerStatus.transform.position.x, PlayerStatus.playerStatus.transform.position.y, PlayerStatus.playerStatus.transform.position.z);
		}
	}

    public override void ApplyEffect (Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
			ok = true;
			shield.Stop();
			shield.volume = 0;
            GetComponent<CircleCollider2D>().radius = 30;
			if(PlayerPrefs.GetString("Dagon") == "Dagon")
			{
				random = Random.Range(0, getD.Length);
				AudioSource.PlayClipAtPoint(getD[random], transform.position, 1f);
				iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(0f,0f,0f), "islocal", true));
			}
			else
			{
				random = Random.Range(0, getC.Length);
				AudioSource.PlayClipAtPoint(getC[random], transform.position, 1f);
				iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(1f,1f,0f), "islocal", true));
			}
			
			StartCoroutine("Go");
			AudioSource.PlayClipAtPoint(clip, transform.position, 0.5f);
            StartCoroutine("UsingMagnetic", tempo);
        }
        if (collider.CompareTag("Coin") && isInCharacter)
        {
            ChasePlayer followPlayer = collider.gameObject.AddComponent(typeof(ChasePlayer)) as ChasePlayer;
        }
    }

	IEnumerator Go()
	{
		yield return new WaitForSeconds(1.7f);
		if(o != (tempo - 3))
			AudioSource.PlayClipAtPoint(clip, transform.position, 0.5f);
		
		
		StartCoroutine("Go");
	}
	
    /// <summary>
    /// Usings the magnetic.
    /// </summary>
    /// <returns>The magnetic.</returns>
    /// <param name="time">Time.</param>
    public IEnumerator UsingMagnetic (float time)
    {	
		yield return new WaitForSeconds(time - 1.5f);
		o = tempo - 3;
        yield return new WaitForSeconds (1.5f);
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