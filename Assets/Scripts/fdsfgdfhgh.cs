using UnityEngine;
using System.Collections;

public class fdsfgdfhgh : MonoBehaviour {

	public GameObject[] hg;
	public AudioClip audio;

	public void Toca()
	{
		AudioSource.PlayClipAtPoint(audio, transform.position, 1f);
	}

	public void DF()
	{
		for(int i = 0; i < hg.Length; i++)
		{
			hg[i].SetActive(false);
		}
		hg[3].SetActive(true);
	}

	void Start()
	{
		hg[2].SetActive(false);
	}

	public void FG()
	{
		hg[3].SetActive(true);
		gameObject.SetActive(false);
	}
}
