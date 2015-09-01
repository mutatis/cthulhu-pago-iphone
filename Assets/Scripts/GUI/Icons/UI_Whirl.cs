using UnityEngine;
using System.Collections;

public class UI_Whirl : UI_Buttons
{
    public override void ApplyEffect ()
    {
        MagneticBehaviour.rate += 1; //increase Magnetic Rate
	}
}
