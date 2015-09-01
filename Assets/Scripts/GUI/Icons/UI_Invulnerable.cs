using UnityEngine;
using System.Collections;

public class UI_Invulnerable : UI_Buttons
{
    public override void ApplyEffect ()
    {
        LightTravelBehaviour.rate += 1; //increase Magnetic Rate
    }
}