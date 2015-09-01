using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class impossibruKill : MonoBehaviour
{

	public Image image;
	public GameObject[] zero;
	public Animator[] zerodes;
	public GameObject[] um;
	public GameObject[] umdes;
	public GameObject[] dois;
	public GameObject[] doisdes;
	public GameObject[] tres;
	public GameObject[] tresdes;
	public GameObject[] quatro;
	public GameObject[] quatrodes;
	public GameObject[] cinco;
	public GameObject[] cincodes;
	public Impossibru ok;
	public UserControl indi;

	// Use this for initialization
	void Start () 
	{
		Debug.Log (PlayerPrefs.GetInt ("Kill"));
		StartCoroutine("Go");
		image.enabled = false;
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds(0.5f);
		if(ok.ok == true)
		{
			if(PlayerPrefs.GetInt("dificuldade") == 2 && PlayerPrefs.GetInt("Kill") == 0)
			{
				for(int i = 0; i < zero.Length; i++)
				{
					zero[i].SetActive(true);
				}
				for(int i = 0; i < zerodes.Length; i++)
				{
					zerodes[i].SetTrigger("Lava");
				}
			}
			if(PlayerPrefs.GetInt("dificuldade") == 2 && PlayerPrefs.GetInt("Kill") == 1)
			{
				indi.indi = 1;
				for(int i = 0; i < um.Length; i++)
				{
					um[i].SetActive(true);
				}
				for(int i = 0; i < umdes.Length; i++)
				{
					umdes[i].SetActive(false);
				}
			}
			if(PlayerPrefs.GetInt("dificuldade") == 2 && PlayerPrefs.GetInt("Kill") == 2)
			{
				indi.indi = 1;
				for(int i = 0; i < dois.Length; i++)
				{
					dois[i].SetActive(true);
				}
				for(int i = 0; i < dois.Length; i++)
				{
					doisdes[i].SetActive(false);
				}
			}
			if(PlayerPrefs.GetInt("dificuldade") == 2 && PlayerPrefs.GetInt("Kill") == 3)
			{
				indi.indi = 1;
				for(int i = 0; i < tres.Length; i++)
				{
					tres[i].SetActive(true);
				}
				for(int i = 0; i < tresdes.Length; i++)
				{
					tresdes[i].SetActive(false);
				}
			}
			if(PlayerPrefs.GetInt("dificuldade") == 2 && PlayerPrefs.GetInt("Kill") == 4)
			{
				for(int i = 0; i < quatro.Length; i++)
				{
					quatro[i].SetActive(true);
				}
				for(int i = 0; i < quatrodes.Length; i++)
				{
					quatrodes[i].SetActive(false);
				}
			}
			/*if(PlayerPrefs.GetInt("dificuldade") == 2 && PlayerPrefs.GetInt("Kill") == 5)
			{
				for(int i = 0; i < cinco.Length; i++)
				{
					cinco[i].SetActive(true);
				}
				for(int i = 0; i < cincodes.Length; i++)
				{
					cincodes[i].SetActive(false);
				}
			}*/
		}
	}
	// Update is called once per frame
	void Update () 
	{

	}
}
