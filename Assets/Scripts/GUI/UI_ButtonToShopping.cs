using UnityEngine;
using System.Collections;

public class UI_ButtonToShopping : UI_PopImage
{
	void OnMouseUpAsButton()
	{
        if (isActive)
        {
            Application.LoadLevel("Shopping");
        }
    }
}