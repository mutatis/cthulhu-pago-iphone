using UnityEngine;
using System.Collections;

public class ShoppingManager : MonoBehaviour
{
    private static ShoppingManager s_shoppingManager;//Singleton
    [HideInInspector]
    public bool displayingOption;
    [HideInInspector]
    public GameObject selectedOption;
	public BoxCollider2D[] consumables;

    public static ShoppingManager shoppingManager
    {
        get
        {
            if (s_shoppingManager == null)
            {
                s_shoppingManager =  FindObjectOfType(typeof (ShoppingManager)) as ShoppingManager;
                
                if (s_shoppingManager == null)
                {
                    GameObject obj = new GameObject("ShoppingManager");
                    s_shoppingManager = obj.AddComponent(typeof (ShoppingManager)) as ShoppingManager;
                }
            }
            
            return s_shoppingManager;
        }
    }

    void Awake ()
    {
        NotificationCenter.DefaultCenter().AddObserver(this,"DisplayOptions");
        NotificationCenter.DefaultCenter().AddObserver(this,"DisplayNoOptions");
    }


    public void DisplayOptions (Notification notification)
	{
		for(int i = 0; i < consumables.Length; i++)
		{
			consumables[i].enabled = true;
		}
        GameObject target = menuDesce.menu.target;
        if (selectedOption)
        {
            selectedOption.SetActive(false);
            //iTweenEvent.GetEvent(selectedOption, "GoOut").Play();
        }
       // iTween.ValueTo(Camera.main.gameObject, iTween.Hash("from", Camera.main.orthographicSize,"to", 3f,"onupdatetarget",gameObject,"onupdate","ValueUpdate"));

        selectedOption = target;
        selectedOption.SetActive(true);
        //iTweenEvent.GetEvent(selectedOption, "GoIn").Play();
        displayingOption = true;
    }

    void ValueUpdate (float _value)
    {
       // Camera.main.orthographicSize = _value;

    }
    public void DisplayNoOptions ()
    {
        //iTweenEvent.GetEvent(selectedOption, "GoOut").Play();
       // iTween.ValueTo(Camera.main.gameObject, iTween.Hash("from", Camera.main.orthographicSize,"to", 6.37f,"delay",0.01f,"onupdatetarget",gameObject,"onupdate","ValueUpdate"));
       // iTween.MoveTo(Camera.main.gameObject, iTween.Hash("position", new Vector3(0,0,-15f)));

		menuDesce.menu.target.SetActive(false);
	
		for(int i = 0; i < consumables.Length; i++)
		{
			consumables[i].enabled = false;
		}
		StartCoroutine("Go");
        selectedOption = null;
        displayingOption = false;
    }
	IEnumerator Go()
	{
		yield return new WaitForSeconds (0.5f);
		for(int i = 0; i < consumables.Length; i++)
		{
			consumables[i].enabled = true;
		}
	}
}
