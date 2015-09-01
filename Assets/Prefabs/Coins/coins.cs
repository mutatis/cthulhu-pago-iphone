using UnityEngine;
using System.Collections;

public class coins : MonoBehaviour 
{
	public int tipo;

	// Use this for initialization
	void Start () 
	{
		if(tipo == 1)
		{
			transform.position = new Vector3(transform.position.x, centromoedas.centro.posY.position.y + 6, transform.position.z);
		}
		else if(tipo == 2)
		{
			transform.position = new Vector3(transform.position.x, centromoedas.centro.posY.position.y - 11, transform.position.z);
		}
		else if(tipo == 3)
		{
			transform.position = new Vector3(transform.position.x, centromoedas.centro.posY.position.y + 4, transform.position.z);
		}
		else if(tipo == 4)
		{
			transform.position = new Vector3(transform.position.x, centromoedas.centro.posY.position.y + 5, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(transform.position.x, centromoedas.centro.posY.position.y, transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
