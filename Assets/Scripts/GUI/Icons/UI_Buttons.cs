using UnityEngine;
using System.Collections;

public class UI_Buttons : MonoBehaviour
{
    void OnMouseDown ()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("amount", 0.5f));
    }
    void OnMouseUpAsButton ()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("amount", 1f));
        ApplyEffect ();
    }

    public virtual void ApplyEffect ()
    {

    }
}
