//  ElfBehaviour.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       27-01-2013 

//using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// Elf behaviour.
/// </summary>
public class ElfBehaviour : MonoBehaviour
{
    public ElfStates elfState = ElfStates.Idle;
	public Gift[] gifts;
	public GameObject[] rocket;
    public AudioClip rocketSFX;

	public float rocketProbability;
    private float timer;
	public float minTimeBetweenAttack = 2;
	public float maxTimeBetweenAttack = 6;
	public float minX = -60;
	public float maxX = 30;
	public float minY = 10;
	public float maxY = 50;
	public Animator susto;
	bool stop = true;
	bool ok;
	int ran;
	private float nextBehaviour;
	private Animator bodyAnimator; // Reference to the player's body animator component.
	private Animator headAnimator; // Reference to the player's head animator component.
    private SpriteRenderer elfCap;
    private Transform bombaOh;
	private GameObject nextGift;
	private AnimatorStateInfo infoAnimator;
	int index = 0;
	public Controle link;

    void Awake()
    {
		headAnimator = transform.FindChild("ElfHead").GetComponent<Animator>() as Animator;
        bodyAnimator = transform.FindChild("ElfBody").GetComponent<Animator>() as Animator;
        elfCap = transform.Find("ElfHead/ElfCap").GetComponent<SpriteRenderer>() as SpriteRenderer;
        bombaOh = transform.FindChild("BombaOh").transform as Transform;
		NotificationCenter.DefaultCenter().AddObserver(this, "IncreaseStrength");
		NotificationCenter.DefaultCenter().AddObserver(this, "DecreaseStrength");
        NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveDamage");
        NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveAGift");
		NotificationCenter.DefaultCenter().AddObserver(this, "TooNarrow");
        NotificationCenter.DefaultCenter().AddObserver(this, "OnDead");
        NotificationCenter.DefaultCenter().AddObserver(this, "QuitScene");
		NotificationCenter.DefaultCenter().AddObserver(this, "StartSpawner");
        NotificationCenter.DefaultCenter().AddObserver(this, "StopSpawner");
    }

	void Start ()
	{
		nextBehaviour = minTimeBetweenAttack;
	}


    void Update()
    {
		if(PlayerStatus.playerStatus.lives > 0)
		{
			infoAnimator = bodyAnimator.GetCurrentAnimatorStateInfo(0);

			if(PlayerPrefs.GetInt("dificuldade") == 1 && ok == false)
			{
				index = 1;
				minTimeBetweenAttack *= 2;
				maxTimeBetweenAttack *= 2;
				/*maxY = maxY/2;
				minY = minY/2;
				minX = minX/2;
				maxX = maxX/2;*/
				ok = true;
			}
			if(PlayerPrefs.GetInt("dificuldade") == 2 && ok == false && PlayerPrefs.GetInt("Kill") == 1)
			{
				index = 0;
				minTimeBetweenAttack = 0;
				maxTimeBetweenAttack = 0;
				ok = true;
			}
			if(PlayerPrefs.GetInt("dificuldade") == 0)
			{
				index = 0;
			}

			switch (elfState)
	        {
	            case ElfStates.Idle:
	                Idle();
	                break;
				case ElfStates.Attacking:
					Attacking();
	                break;
	            case ElfStates.Trolling:
	                Trolling ();
	                break;
	            case ElfStates.Surprised:
					Surprised();
	                break;
				case ElfStates.None:
					None();
				break;
	        }
		}
    }

	void None()
	{

	}

	void Idle ()
	{
		if(stop)
		{
			timer += Time.deltaTime;
	        if (infoAnimator.IsName("Idle"))
	        {
				if (headAnimator.renderer.enabled == false)
	            {
			    	headAnimator.renderer.enabled = true;
					elfCap.GetComponent<SpriteRenderer>().enabled = true;
				}
	        }

		    if (timer > nextBehaviour)
			{
				elfState = ElfStates.Attacking;
				nextBehaviour = UnityEngine.Random.Range(minTimeBetweenAttack, maxTimeBetweenAttack);
				timer = 0;
			}
		}
		else
		{
			elfState = ElfStates.None;
		}
	}

	void Attacking()
    {
        if (Time.timeSinceLevelLoad < 6)
            return;
		int giftIndex = 0;

		if (infoAnimator.IsName("Idle") && !(bodyAnimator.GetBool("Preparing") || bodyAnimator.GetBool("Rocket")))
		{
			if (Random.value < rocketProbability/100)
			{
				bodyAnimator.SetTrigger("Rocket");
				headAnimator.renderer.enabled = false;
				elfCap.GetComponent<SpriteRenderer>().enabled = false;

				return;
			}
			else
			{
                headAnimator.SetTrigger("Scream"); //play Scream animation when one gift hit another one.
				bodyAnimator.SetTrigger("Preparing");// Set the Jump animator trigger parameter.
				giftIndex = ChooseItem();
				nextGift = PoolManager.Pools["props"].Spawn(gifts[giftIndex].gift.transform, bombaOh.position, transform.rotation).gameObject;
				nextGift.transform.parent = gameObject.transform;
				if (nextGift.rigidbody2D)
					nextGift.rigidbody2D.isKinematic = true;
				foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
				{
					p.Play();
				}
				return;
			}
		}

		if (infoAnimator.IsName("Attack"))
		{
			if (nextGift == null)
				return;
            headAnimator.renderer.enabled = false;
            elfCap.GetComponent<SpriteRenderer>().enabled = false;
			nextGift.transform.parent = null;
			nextGift.rigidbody2D.isKinematic = false;

			if (nextGift.GetComponent<LaserBehaviour>() != null)
				nextGift.rigidbody2D.AddForce(new Vector2(0,Random.Range(minY, maxY)),ForceMode2D.Impulse);
			else
				nextGift.rigidbody2D.AddForce(new Vector2(Random.Range(minX,maxX),Random.Range(minY, maxY)),ForceMode2D.Impulse);

			nextGift.rigidbody2D.AddTorque(Random.Range(-360,360));
			elfState = ElfStates.Idle;
			return;
		}

		if (infoAnimator.IsName("Rocket"))
		{
			if(PlayerPrefs.GetInt("dificuldade") == 2 && PlayerPrefs.GetInt("Kill") == 5)
			{
				PoolManager.Pools["props"].Spawn (rocket[1].transform, new Vector3(transform.position.x - 10, transform.position.y, transform.position.z) + new Vector3(0f,3f,0f), Quaternion.identity);
			}
			else if(link.link == false)
			{
				PoolManager.Pools["props"].Spawn (rocket[0].transform, new Vector3(transform.position.x - 10, transform.position.y, transform.position.z) + new Vector3(0f,3f,0f), Quaternion.identity);
			}
			else
			{
				PoolManager.Pools["props"].Spawn (rocket[1].transform, new Vector3(transform.position.x - 10, transform.position.y, transform.position.z) + new Vector3(0f,3f,0f), Quaternion.identity);
			}
			ran = Random.Range(0, 4);
			if(ran == 2 && susto != null && PlayerStatus.playerStatus.rigidbody2D.velocity.y >= 0)
			{
				susto.SetTrigger("Susto");
			}
			bodyAnimator.SetBool("Rocket",false);
            audio.PlayOneShot(rocketSFX, 0.5f);

			///Vector3 wantedDirection = (PlayerStatus.playerStatus.transform.position + new Vector3(PlayerStatus.playerStatus.rigidbody2D.velocity.x/2,0,0))- newRocket.position;

            //newRocket.LookAt(wantedDirection);

            ///Vector3 relativeUp = newRocket.TransformDirection (Vector3.up);
            ///newRocket.rotation = Quaternion.LookRotation(wantedDirection,relativeUp);
            //Quaternion rot = Quaternion.LookRotation(wantedDirection, Vector3.up ); //test Vector3.forward
            //newRocket.rotation = rot;
            //newRocket.eulerAngles = new Vector3(0, 0,newRocket.eulerAngles.z); 


			///newRocket.rotation = new Quaternion( 0,0,newRocket.rotation.z, newRocket.rotation.w);
			elfCap.GetComponent<SpriteRenderer>().enabled = false;

			
			elfState = ElfStates.Idle;
			return;
		}
	}
	
    void Trolling ()
    {
		if (headAnimator.renderer.enabled == false)
		{
			headAnimator.renderer.enabled = true;
			elfCap.GetComponent<SpriteRenderer>().enabled = true;
		}

        if (nextGift)
        {
            nextGift.transform.parent = null;
            nextGift.rigidbody2D.isKinematic = false;
        }
	
        headAnimator.SetTrigger("Troll"); //play Troll animation

        elfState = ElfStates.Idle; //So elf returns to Idle state
    }

    void Surprised ()
    {
		if (headAnimator.renderer.enabled == false)
		{
			headAnimator.renderer.enabled = true;
			elfCap.GetComponent<SpriteRenderer>().enabled = true;
		}

		headAnimator.SetTrigger("Surprised"); //play Surprised animation when player receives a gift
        elfState = ElfStates.Idle; //So elf returns to Idle state
    }

	int ChooseItem ()
	{
		float total = 0;
		int i = 0;
		foreach (Gift elem in gifts)
		{
			total += elem.probability;
		}
		
		float randomPoint = Random.value * total;
		
		for (i = 0; i < gifts.Length; i++)
		{
			if (randomPoint < gifts[i].probability)
				return i;
			else
				randomPoint -= gifts[i].probability;
		}
		
		return gifts.Length - 1;
	}
	
	public void TooNarrow ()
	{
		minX -= Mathf.Abs(minX * 0.1f);
		maxX +=Mathf.Abs(minX * 0.1f);
		elfState = ElfStates.Surprised;
	}
	
	public void IncreaseStrength ()
	{
		minX -= Mathf.Abs(minX * 0.1f);
		maxX -= Mathf.Abs(minX * 0.1f);
	}

	public void DecreaseStrength ()
	{
		minX += Mathf.Abs(minX * 0.1f);
		maxX += Mathf.Abs(minX * 0.1f);
	}

	public void ReceiveDamage ()
	{
		minX += Mathf.Abs(minX * 0.1f);
		maxX -= Mathf.Abs(minX * 0.1f);
		elfState = ElfStates.Trolling;
    }

    void ReceiveAGift ()
    {
        elfState = ElfStates.Surprised;
    }

    static T GetRandomEnum<T>() //elfState = GetRandomEnum<ElfStates>();
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

	void StartSpawner ()
    {
		stop = false;
        elfState = ElfStates.None;
    }
    
    void StopSpawner ()
    {
		StartCoroutine("Attack");
    }

	IEnumerator Attack()
	{
		yield return new WaitForSeconds(1);
		stop = true;
		elfState = ElfStates.Idle;
	}
}

[System.Serializable]
public class Gift
{
	public GameObject gift;
	public float probability;
}

public enum ElfStates
{
    None,
    Idle,
    Attacking,
	Trolling,
    Surprised
}