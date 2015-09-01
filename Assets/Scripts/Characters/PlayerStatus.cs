using UnityEngine;
using System.Collections;

/// <summary>
/// Player status.
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus playerStatus;

    public float lives = 3;
	public int ia_indi = 0;
    public SpriteRenderer headSpriteRenderer;
	public SpriteRenderer bodySpriteRenderer;
	public SpriteRenderer braco;
    public SpriteRenderer[] othersSpriteRenderer;
	public Sprite[] desativalight;
	public GameObject[] desCodigos;
	public Transform sombraBomb;
	public GameObject[] desativar;
    public bool invulnerable {get; private set;}
	private GameObject invulnerablePrefab;
	public GameObject hasContinuePrefab;
	public float sombra;
	public AudioClip[] damage;
	public bool pause;
	public AudioClip[] dead;
	int random;
	float sLives;
	int x;
	public int idol;
	bool ok;
	public UserControl indi;
	public bool kk;
	public SantaBehaviour santa;
	public ElfBehaviour elf;

    /// <summary>
    /// Awake this instance.
    /// </summary>
	void Awake ()
	{
		playerStatus = this;
        if (!bodySpriteRenderer)
		    bodySpriteRenderer = GetComponent<SpriteRenderer>();
		NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveDamage");
	}

    /// <summary>
    /// Start this instance.
    /// </summary>
	public void Start ()
	{
		GameManager.gameManager.gift = 9;
		sombra = transform.position.y;
        headSpriteRenderer.color = new Color (1,1,1,1);
		if (PlayerPrefs.GetInt("extraLife") != 0)
		{
			if(ia_indi == 0)
			{
				if(PlayerPrefs.GetInt("extraLife") < 5)
				{
					lives += PlayerPrefs.GetInt("extraLife");
				}
				else
				{
					lives += 5;
				}
			}
		}
		if(PlayerPrefs.GetInt("Passo") == 1)
		{
			lives = PlayerPrefs.GetFloat("sLives");
		}
		else
		{
			PlayerPrefs.SetFloat("sLives", lives);
		}
		sLives = lives;

		if (GameManager.gameManager.hasContinue)
		{
			Transform head = transform.FindChild("Head");
			Instantiate(hasContinuePrefab);
			hasContinuePrefab.transform.parent = head;
		}
		Debug.Log(GameManager.gameManager.extraLife + "" + PlayerPrefs.GetInt("extraLife"));
		/*lives += PlayerPrefs.GetInt("extraLife");
		if(PlayerPrefs.GetInt("extraLife") >= 5)
		{
			lives = 6;
		}*/
	}

	void Update()
	{
		if(lives <= 0)
		{
			for(int i = 0; i < desCodigos.Length; i++)
			{
				Destroy(desCodigos[i].gameObject);
			}
			for(int i = 0; i < desativar.Length; i++)
			{
				desativar[i].SetActive(false);
			}
			if (GameManager.gameManager.hasContinue && ia_indi == 0)
			{
				lives = sLives + 1;
				//Destroy(hasContinuePrefab);
				PlayerPrefs.SetInt("hasContinue", 0);
				GameManager.gameManager.hasContinue = false;
				//PlayerPrefs.SetInt("hasContinue", 0);
				kk = true;
				return;
			}
			lives = 0;
			random = Random.Range(0, dead.Length);
			if(ok == false && lives <= 0)
			{
				StartCoroutine("Dying");
				ok = true;
			}
		}
		headSpriteRenderer.enabled = true;
		braco.enabled = true;
	}

    /// <summary>
    /// Receives the damage.
    /// </summary>
	public void ReceiveDamage ()
	{
		if (invulnerable)
			return;

		random = Random.Range (0, damage.Length);
		if(Application.loadedLevelName != "ManOfSteel")
			AudioSource.PlayClipAtPoint(damage[random], transform.position, 1f);
		lives --;
		if (lives <= 0)
        {
            //iTween.Pause(gameObject);
           if (GameManager.gameManager.hasContinue && ia_indi == 0)
            {
				santa.santaStates = SantaBehaviour.SantaStates.BeforeEnter;
				StartCoroutine("atira");
                lives = sLives + 1;
				//Destroy(hasContinuePrefab);
				PlayerPrefs.SetInt("hasContinue", 0);
                GameManager.gameManager.hasContinue = false;
				//PlayerPrefs.SetInt("hasContinue", 0);
				kk = true;
                return;
            }
            lives = 0;
			random = Random.Range(0, dead.Length);
			if(ok == false && lives <= 0)
			{
            	StartCoroutine("Dying");
				ok = true;
			}
        }
        else
        {
			if(kk == false)
            InvulnerableByXTimes (2);
        }
	}

	IEnumerator atira()
	{
		yield return new WaitForSeconds(0.4F);
		elf.elfState = ElfStates.Attacking;
		StopCoroutine("atira");
	}

    /// <summary>
    /// Dying this instance.
    /// </summary>
    IEnumerator Dying ()
    {
		Debug.Log(random);
		if(GameManager.gameManager.hasContinue == false)
		{
			if(lives == 0 && x == 0 && ia_indi == 0)
			{
				AudioSource.PlayClipAtPoint(dead[random], transform.position, 1f);
				x =1;
			}
			if (CthulhuAnimationSetter.cthulhuAnimationSetter)
			{
		       	CthulhuAnimationSetter.cthulhuAnimationSetter.StartCoroutine("Dying");
		       	yield return new WaitForSeconds(3);
			}

			if (DagonAnimationSetter.dagonAnimationSetter)
			{
				DagonAnimationSetter.dagonAnimationSetter.StartCoroutine("Dying");
				yield return new WaitForSeconds(3);
			}
			if(deadSuper.deadCthulhu)
			{
				deadSuper.deadCthulhu.Morreu();
				yield return new WaitForSeconds(3);
			}
			else
			{
				yield return new WaitForSeconds(3);
			}
	        NotificationCenter.DefaultCenter().PostNotification(this, "OnDead");
		}
    }

    public void InvulnerableByXTimes (float time, bool isBlinking = true)
    {   
        if (isBlinking)
            StartCoroutine("Blink", time);
        StartCoroutine("Invulnerable", time);
    }


    /// <summary>
    /// Invulnerables the by X times.
    /// </summary>
    /// <returns>The by X times.</returns>
    /// <param name="time">Time.</param>
	private IEnumerator Invulnerable (float time)
	{
        invulnerable = true;
        //iTween.ColorTo(gameObject, iTween.Hash("a", 0, "time", 0.2f, "looptype", "pingPong")); 

        yield return new WaitForSeconds (time);
        //iTween.Stop(gameObject);
        //iTween.ColorTo(gameObject, iTween.Hash("a", 1, "time", 0.2f)); 
        invulnerable = false;
	}


    /// <summary>
    /// Raises the blink completed event.
    /// </summary>
    public void OnBlinkCompleted ()
    {

        bodySpriteRenderer.color = new Color (1,1,1,1);
        headSpriteRenderer.color = new Color (1,1,1,1);
		if(indi.indi != 1)
			braco.color = new Color (1,1,1,1);
        foreach (SpriteRenderer spriteRenderer in othersSpriteRenderer)
            spriteRenderer.color = new Color (1,1,1,1);
    }

    public IEnumerator Blink (float time)
	{
		float initialTime = Time.time;
		while (Time.time - (initialTime + time) < 0)
		{
			time -= Time.deltaTime;

			if (bodySpriteRenderer.color.a == 1)
			{
				bodySpriteRenderer.color = new Color (1,1,1,0);
				headSpriteRenderer.color = new Color (1,1,1,0);
				if(indi.indi != 1)
					braco.color = new Color (1,1,1,0);
                foreach (SpriteRenderer spriteRenderer in othersSpriteRenderer)
                    spriteRenderer.color = new Color (1,1,1,0);
			}
			else
			{
				bodySpriteRenderer.color = new Color (1,1,1,1);
				headSpriteRenderer.color = new Color (1,1,1,1);
				if(indi.indi != 1)
					braco.color = new Color (1,1,1,1);
                foreach (SpriteRenderer spriteRenderer in othersSpriteRenderer)
                    spriteRenderer.color = new Color (1,1,1,1);
            }
            
            
            yield return new WaitForSeconds (0.2f);
		}
        OnBlinkCompleted ();
	}

    public void DisableRenderers ()
    {
        bodySpriteRenderer.color = new Color (1,1,1,0);
		if(indi.indi != 1)
			braco.color = new Color (1,1,1,0);
        headSpriteRenderer.color = new Color (1,1,1,0);
        foreach (SpriteRenderer spriteRenderer in othersSpriteRenderer)
            spriteRenderer.color = new Color (1,1,1,0);
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "CravedCave")
		{
			ReceiveDamage();
		}
	}
}