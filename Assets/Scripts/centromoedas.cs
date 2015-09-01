using UnityEngine;
using System.Collections;

public class centromoedas : MonoBehaviour
{
	public static centromoedas centro;
	public Transform posY;

	void Awake()
	{
		centro = this;
	}
}
