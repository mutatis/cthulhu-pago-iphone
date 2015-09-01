using UnityEngine;
using System.Collections;

public class MoveObjectTo : MonoBehaviour
{
    public GameObject target;
    public Vector3 position;
    public iTween.EaseType easeType;

    void OnMouseUpAsButton()
    {
        iTween.MoveTo(target, iTween.Hash("position", position, "easeType", easeType));
    }
}
