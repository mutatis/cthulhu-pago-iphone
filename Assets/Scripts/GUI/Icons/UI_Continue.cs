using UnityEngine;
using System.Collections;

public class UI_Continue : UI_Buttons {

    public override void ApplyEffect ()
    {
        GameManager.gameManager.hasContinue = true;
	}
}
