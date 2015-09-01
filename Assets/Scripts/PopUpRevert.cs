using UnityEngine;
using System.Collections;

public class PopUpRevert : MonoBehaviour 
{
	bool ok;

	void Update()
	{
		if(ok && transform.localScale.x > 0)
		{
			transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
		}
		if(ok && transform.localScale.x <= 0)
		{
			transform.localScale = new Vector3(0, 0, 0);
		}
	}

	public void Click()
	{
		ok = true;
	}
}
