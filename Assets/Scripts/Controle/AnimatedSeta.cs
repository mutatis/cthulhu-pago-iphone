using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimatedSeta : MonoBehaviour 
{
	public Sprite imagem;
	public Sprite imagem2;
	public Image seta;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnPress ()
	{
			seta.sprite = imagem;
	}

	public void OnUp()
	{
		seta.sprite = imagem2;
	}
}
