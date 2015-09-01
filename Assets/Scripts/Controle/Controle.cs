using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controle : MonoBehaviour
{
	public Transform dificuldade;
	public GameObject dificul;
	public Transform max;
	public Transform min;
	public UserControl indi;
	float dificult;
	bool oi;
	string button;
	public GameObject[] codigos;
	bool click;
	public bool link;
	public Image image;
	bool v = true;
	public AudioClip erro;
	public AudioSource ok;
	public GameObject[] cthulhu;
	public GameObject[] pika;
	public IABuyDagon ii;

	// Use this for initialization
	void Start ()
	{
		dificult = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Vector3.Distance(transform.position, dificuldade.transform.position) < 500)
		{
			transform.Translate(0, -20, 0);
		}
		if(oi == false)
		{
			if(transform.position.y < max.position.y)
			{
				transform.Translate(0, 20, 0);
				dificuldade.Translate(0, 20, 0);
			}
			/*else if(transform.position.y > max.position.y + 5)
			{
				transform.Translate(0, -20, 0);
				dificuldade.Translate(0, -20, 0);
			}*/
			else
			{
				transform.position = new Vector2(transform.position.x, max.position.y);
				//dificul.SetActive(false);
			}
		}
		else
		{
			if(transform.position.y > dificult)
			{
				transform.Translate(0, -20, 0);
				dificuldade.Translate(0, -20, 0);
			}
			else
			{
				dificuldade.position = max.position;
				transform.position = new Vector2(transform.position.x, dificult);
				oi = false;
				gameObject.SetActive(false);
			}
		}
		if(button == "babaupdownbaleftrightbastart" || PlayerPrefs.GetString("Controle") == "babaupdownbaleftrightbastart")
		{
			PlayerPrefs.SetString("Controle", "babaupdownbaleftrightbastart");
			Debug.Log("tartarugas");
			StopCoroutine("Cont");
			if(v)
			StartCoroutine("Clean");
		}
		else if(button == "abacabb" || PlayerPrefs.GetString("Controle") == "abacabb")
		{
			PlayerPrefs.SetString("Controle", "abacabb");
			codigos[0].SetActive(true);
			Debug.Log("mortal");
			StopCoroutine("Cont");
			if(v)
			StartCoroutine("Clean");
		}
		else if(button == "updownleftrightastart" || PlayerPrefs.GetString("Controle") == "updownleftrightastart")
		{
			PlayerPrefs.SetString("Controle", "updownleftrightastart");
			Debug.Log("sonic");
			StopCoroutine("Cont");
			if(v)
			StartCoroutine("Clean");
		}
		else if(button == "abdown" || PlayerPrefs.GetString("Controle") == "abdown")
		{
			PlayerPrefs.SetString("Controle", "abdown");
			for(int i = 0; i < cthulhu.Length; i++)
			{
				cthulhu[i].SetActive(false);
			}
			for(int i = 0; i < pika.Length; i++)
			{
				pika[i].SetActive(true);
			}
			ii.ok = true;
			Debug.Log("pokemon");
			StopCoroutine("Cont");
			StartCoroutine("Clean");
		}
		else if(button == "aarightac" || PlayerPrefs.GetString("Controle") == "aarightac")
		{
			PlayerPrefs.SetString("Controle", "aarightac");
			codigos[1].SetActive(true);
			StopCoroutine("Cont");
			if(v)
			StartCoroutine("Clean");
			Debug.Log("akuma");
		}
		else if(button == "upupdowndownleftrightleftrightba" || PlayerPrefs.GetString("Controle") == "upupdowndownleftrightleftrightba")
		{
			PlayerPrefs.SetString("Controle", "upupdowndownleftrightleftrightba");
			codigos[3].SetActive(true);
			Debug.Log("konami");
			StopCoroutine("Cont");
			if(v)
			StartCoroutine("Clean");
		}
		else if(button == "startupa" || PlayerPrefs.GetString("Controle") == "startupa")
		{
			Destroy(codigos[5].gameObject);
			codigos[1].SetActive(false);
			PlayerPrefs.SetString("Controle", "startupa");
			codigos[2].SetActive(true);
			codigos[4].SetActive(true);
			codigos[6].SetActive(true);
			indi.indi = 1;
			Debug.Log("zelda");
			StopCoroutine("Cont");
			if(v)
			StartCoroutine("Clean");
			link = true;
		}

	}

	IEnumerator Clean()
	{
		image.color = Color.green;
		System.DateTime timeToShowNextElement = System.DateTime.Now.AddSeconds(1);
		while (System.DateTime.Now < timeToShowNextElement)
		{
			yield return null;
		}
		PlayerPrefs.SetString("Controle", button);
		image.color = Color.white;
		ok.Play ();
		v = false;
		StopCoroutine("Clean");
	}

	IEnumerator Cont()
	{
		System.DateTime timeToShowNextElement = System.DateTime.Now.AddSeconds(4);
		while (System.DateTime.Now < timeToShowNextElement)
		{
			yield return null;
		}
		if(click == false)
		{
			//PlayerPrefs.SetString("Controle", "");
			button = "";
		}
		else
		{
			click = false;
		}
		audio.Play ();
		image.color = Color.red;
		timeToShowNextElement = System.DateTime.Now.AddSeconds(0.5f);
		while (System.DateTime.Now < timeToShowNextElement)
		{
			yield return null;
		}
		image.color = Color.white;
	}

	public void IIH()
	{
		oi = true;
	}

	public void OOh()
	{
		oi = false;
	}

	public void Up()
	{
		button += "up";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
	public void Down()
	{
		button += "down";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
	public void Left()
	{
		button += "left";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
	public void Right()
	{
		button += "right";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
	public void StartButton()
	{
		button += "start";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
	public void Select()
	{
		button += "select";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
	public void A()
	{
		button += "a";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
	public void B()
	{
		button += "b";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
	public void C()
	{
		button += "c";
		click = true;
		v = true;
		StartCoroutine("Cont");
	}
}
