using UnityEngine;
using System.Collections;

public class ChaoDead : UI_PopOnEventBase {
	
	public override void OnDead ()
	{
		Destroy (gameObject);
	}
}
