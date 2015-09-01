using UnityEngine;
using System.Collections;

public class PickupPrefabManager : MonoBehaviour
{
    public PickupObject[] pickupObjects;
	// Use this for initialization
	void Start ()
    {
        pickupObjects = GetComponentsInChildren<PickupObject>();
        print(pickupObjects.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}