using UnityEngine;
using System.Collections;

public class espinhoisclick : MonoBehaviour
{
	public int tipo;
	public Transform kkkk;
	bool ds;
	bool ks;
	public AudioClip fx;
	public UserControl indi;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.timeScale  != 0)
		{
			if(tipo == 0 && Input.GetMouseButtonDown(0))
			{
				AudioSource.PlayClipAtPoint(fx, PlayerStatus.playerStatus.transform.position, 1f); 
				ks = true;
				indi.indi = 1;
			}
			if(tipo == 1 && Input.GetMouseButtonDown(0))
			{
				AudioSource.PlayClipAtPoint(fx, PlayerStatus.playerStatus.transform.position, 1f); 
				ds = true;
				indi.indi = 1;
			}
			if(ds && transform.position.y <= kkkk.position.y)
			{
				transform.Translate(0, 2f, 0);
			}
			if(ks && transform.position.y >= kkkk.position.y)
			{
				transform.Translate(0, -2f, 0);
			}
		}
	}
}
