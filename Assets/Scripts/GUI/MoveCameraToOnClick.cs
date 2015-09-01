
using UnityEngine;
using System.Collections;

public class MoveCameraToOnClick : MonoBehaviour
{
    public Vector3 goTo;
	
    void OnMouseDown()
    {
        Vector3 nextPosition = new Vector3(goTo.x/Screen.width,goTo.y/Screen.height,Camera.main.transform.position.z);
        iTween.MoveTo(Camera.main.gameObject, iTween.Hash("position", nextPosition));
    }
}