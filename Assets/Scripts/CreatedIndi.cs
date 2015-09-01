using UnityEngine;
using System.Collections;

public class CreatedIndi : MonoBehaviour 
{
	public GameObject floor;
	public Transform cthulhu;
	int posx = 300;
	bool ok;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(cthulhu.position.x >= posx && ok == false)
		{
			Instantiate(floor, new Vector3(cthulhu.position.x + 150, -2.5f, 0), Quaternion.identity);
			ok = true;
		}
		if(ok)
		{
			posx += 300;
			ok = false;
		}
	}
}
