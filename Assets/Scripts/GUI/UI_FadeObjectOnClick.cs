using UnityEngine;
using System.Collections;

public class UI_FadeObjectOnClick : MonoBehaviour
{
    public GameObject target;
    public float fadeIntensity;
    public iTween.EaseType easeType;

	void OnMouseUpAsButton()
	{
        iTween.FadeTo(target, iTween.Hash("alpha", fadeIntensity,"easeType", easeType));
	}
}
