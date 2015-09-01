using UnityEngine;
using System.Collections;

public class EspecifyParticleLayer : MonoBehaviour
{
	public string layerName = "Foreground";
	void Awake ()
	{
		particleSystem.renderer.sortingLayerName = layerName;
	}
}
