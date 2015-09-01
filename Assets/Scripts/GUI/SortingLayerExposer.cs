using UnityEngine;
using System.Collections;

public class SortingLayerExposer : MonoBehaviour
{
	
	public Layer2D SortingLayerName;
	public int SortingOrder = 0;
	
	void Awake ()
	{
		if(SortingLayerName == Layer2D.Default)
		{
			gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "Default";
		}
		else if(SortingLayerName == Layer2D.ParallaxBackground)
		{
			gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "ParallaxBackground";
		}
		else if(SortingLayerName == Layer2D.Background)
		{
			gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "Background";
		}
		else if(SortingLayerName == Layer2D.Character)
		{
			gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "Character";
		}
		else if(SortingLayerName == Layer2D.Foreground)
		{
			gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "Foreground";
		}
		else if(SortingLayerName == Layer2D.FirstPlane)
		{
			gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "FirstPlane";
		}
		else if(SortingLayerName == Layer2D.UI)
		{
			gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "UI";
		}
		else if(SortingLayerName == Layer2D.Loading)
		{
			gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "Loading";
		}
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
	}
}
public enum Layer2D
{
	Default, ParallaxBackground, Background, Character, Foreground, FirstPlane, UI, Loading
}