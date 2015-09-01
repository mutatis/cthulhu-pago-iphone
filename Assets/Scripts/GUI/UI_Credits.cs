using UnityEngine;
using System.Collections;

public class UI_Credits : UI_PopImage
{
	void Update()
	{

	}

  	public void OnMouseDownAsButton()
    {
			Application.LoadLevel("Creditos");
    }
}
