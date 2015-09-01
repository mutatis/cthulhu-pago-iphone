using UnityEngine;
using System.Collections;

public class trail : MonoBehaviour {

	public TrailRenderer traik;
	// Use this for initialization
	void Start () {
		traik.sortingLayerName = "Character";
		traik.sortingOrder = 2;
		
	}
}
