using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShoppingLayout : MonoBehaviour 
{
	RectTransform trans;
	bool ok;
	public float posY;

	// Use this for initialization
	void Start () 
	{
		trans = GetComponent<RectTransform>();
	}

	void Update()
	{
		if(ok)
		{
			transform.Translate(0, 0.5f, 0);
			StartCoroutine("Go");
		}
		Debug.Log(transform.position);
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds(0.5f);
		ok = false;
	}
	
	// Update is called once per frame
	public void click () 
	{
		ok = true;
	}


}
