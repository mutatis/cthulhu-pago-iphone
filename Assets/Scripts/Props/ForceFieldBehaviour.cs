using UnityEngine;
using System.Collections;

public class ForceFieldBehaviour : PowerUpBehaviour
{
    public static float duration = 30;
    private Animator my_Animator;
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
		tempo += PlayerPrefs.GetFloat("ForceField");
	}

	void Update()
	{
		transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
		if(ok == false)
		{
			if (Vector3.Distance(transform.position, IABuyDagon.buyDagon.transform.position) < 60)
			{
				directionToMove = new Vector3 (25f*Time.deltaTime,Mathf.Sin(2*Time.time)*0.4f,0);
				if ((transform.position.y < 0 && directionToMove.y < 0)||(transform.position.y > 30 && directionToMove.y > 0))
				{
					directionToMove = new Vector3 (directionToMove.x,-directionToMove.y,directionToMove.z);
				}
				transform.Translate(directionToMove);
			}
		}
		else
		{
			transform.position = new Vector3(PlayerStatus.playerStatus.transform.position.x, PlayerStatus.playerStatus.transform.position.y, PlayerStatus.playerStatus.transform.position.z);
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
	}

    public override void OnSpawned ()
    {	
        base.OnSpawned ();
        if (!my_Animator)
            my_Animator = transform.FindChild("Invulnerable").GetComponent<Animator>();
        my_Animator.speed = 1;
    }
    public override void ApplyEffect (Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
			ok = true;
			shield.Stop();
			shield.volume = 0;
            iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(0f,3.5f,0f), "islocal", true));
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
				iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(0f,0f,0f), "islocal", true));
			}
			StartCoroutine("Go");
			AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
            StartCoroutine("UsingAForceField", tempo);
        }
    }

	IEnumerator Go()
	{
		yield return new WaitForSeconds(1.7f);
		if(o != (tempo - 3))
			AudioSource.PlayClipAtPoint(clip, transform.position, 1f);


		StartCoroutine("Go");
	}

    /// <summary>
    /// Usings A force field.
    /// </summary>
    /// <returns>The A force field.</returns>
    /// <param name="time">Time.</param>
    public IEnumerator UsingAForceField (float time)
    {
		transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        //collider2D.isTrigger = false;
        PlayerStatus.playerStatus.InvulnerableByXTimes(time, false);
        yield return new WaitForSeconds (time-3);
        my_Animator.speed = 5;
		yield return new WaitForSeconds(1.5f);
		o = tempo - 3;
        yield return new WaitForSeconds (1.5f);
        PoolManager.Pools["props"].Despawn (transform);
    }
}
