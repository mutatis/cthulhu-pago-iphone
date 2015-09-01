using UnityEngine;
using System.Collections;

public class UI_DoubleStars : UI_Buttons {

    public override void ApplyEffect ()
    {
        GameManager.gameManager.doubleCoin = true;
	}
}
