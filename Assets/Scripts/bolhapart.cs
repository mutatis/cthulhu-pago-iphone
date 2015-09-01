using UnityEngine;
using System.Collections;

public class bolhapart : MonoBehaviour 
{
	public Transform cthulhu;
	public Transform dagon;
	bool posY;
	ParticleSystem part;

	// Use this for initialization
	void Start () 
	{
		part = GetComponent<ParticleSystem>();
		if(PlayerPrefs.GetString("Dagon") != "Dagon")
		{
			posY = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(posY)
		{
			transform.position = new Vector2(cthulhu.position.x, transform.position.y);
			if(!part.isPlaying)
			{
				transform.position = new Vector3(cthulhu.position.x, cthulhu.position.y + 5, cthulhu.position.z);
				part.Play();
			}
		}
		else
		{
			transform.position = new Vector2(dagon.position.x, transform.position.y);
			if(!part.isPlaying)
			{
				transform.position = new Vector3(dagon.position.x, dagon.position.y, dagon.position.z);
				part.Play();
			}
		}
	}
}
