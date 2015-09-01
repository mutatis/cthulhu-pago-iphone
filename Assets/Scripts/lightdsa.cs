using UnityEngine;
using System.Collections;

public class lightdsa : MonoBehaviour {

	public GameObject[] ok;
	public GameObject repelente;
	public AudioClip audio;

	void Start()
	{
		Instantiate(repelente);
	}

	public void IIH()
	{
		AudioSource.PlayClipAtPoint(audio, transform.position, 1f);
	}

	public void Sai()
	{
		for(int i = 0; i < ok.Length-2; i++)
		{
			ok[i].SetActive(true);
		}
		ok[2].SetActive(false);
		ok[3].SetActive(false);
	}

	public void Ente()
	{
		Destroy(gameObject);
	}
}
