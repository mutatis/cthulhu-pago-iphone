using UnityEngine;
using System.Collections;

public class CallDisplayOptions : MonoBehaviour
{
    public GameObject target;
	public menuDesce desce;
	//public AudioSource play;

	void Update () 
	{
		if (guiTexture.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
		{
			desce.Desca();
			desce.target = target;
		}
	}

    void Clico()
    {
		//play.Play ();
        if (ShoppingManager.shoppingManager.displayingOption)
            return;
        //iTween.MoveTo(Camera.main.gameObject, iTween.Hash("position", new Vector3(transform.position.x,transform.position.y,Camera.main.transform.position.z)));
        NotificationCenter.DefaultCenter().PostNotification(this,"DisplayOptions" , target);
    }
}
