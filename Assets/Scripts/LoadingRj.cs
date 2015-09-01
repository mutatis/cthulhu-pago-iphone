using UnityEngine;
using System.Collections;

public class LoadingRj : MonoBehaviour 
{

	private SpriteRenderer spriteRenderer;
	public SpriteRenderer ss;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = false;
		ss.enabled = false;
		StartCoroutine("Go");
	}
	
	IEnumerator Go() 
	{
		yield return new WaitForSeconds (4f);
		spriteRenderer.enabled = true;
		ss.enabled = true;
		AsyncOperation async = Application.LoadLevelAsync("Rio de Janeiro");
		yield return async;
		Debug.Log(async.progress);
		if(!async.isDone)
		{
			Debug.Log(async.progress);
			yield return 0;
		}
	}
}
