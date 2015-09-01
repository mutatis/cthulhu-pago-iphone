using UnityEngine;
using System.Collections;

public class CreatedIndiCave : MonoBehaviour 
{

	public Transform cthulhu;
	public SpriteRowCreator creator;
	int posx = 500;
	bool ok;

// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");
	}

	// Update is called once per frame
	void Update () 
	{
		if(cthulhu.position.x >= posx && ok == false)
		{
			creator.CreateSprites();
			ok = true;
		}
		if(ok)
		{
			posx += 500;
			ok = false;
		}
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds(2f);
		creator.CreateSprites();
	}
}