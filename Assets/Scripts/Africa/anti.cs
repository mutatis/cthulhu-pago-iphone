using UnityEngine;
using System.Collections;

public class anti : MonoBehaviour
{
	public Transform posX;
	public GameObject anti1;
	public GameObject anti2;
	public GameObject anti3;
	public GameObject anti4;
	public GameObject anti5;
	public GameObject anti6;
	public GameObject anti7;
	public GameObject anti8;
	public GameObject anti9;
	bool um;
	bool dois;
	bool tres;
	float tempo = 2;

	void Start()
	{
		tempo += Time.time;
	}

	// Update is called once per frame
	void Update ()
	{
		if(tempo <= Time.time && um == false)
		{
			um = true;
			tempo += Time.time + (Random.Range(0,4));
		}
		if(tempo <= Time.time && um && dois == false)
		{
			dois = true;
			tempo += Time.time + (Random.Range(0,4));
		}
		if(tempo <= Time.time && dois && tres == false)
		{
			tres = true;
			tempo += Time.time + (Random.Range(0,4));
		}
		if(um && dois && tres)
		{
			StartCoroutine("Apareca");
		}
		transform.position = new Vector3(posX.position.x, transform.position.y, transform.position.z);
	}

	IEnumerator Apareca()
	{
		anti1.SetActive(true);
		anti2.SetActive(true);
		anti3.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		anti4.SetActive(true);
		anti5.SetActive(true);
		anti6.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		anti7.SetActive(true);
		anti8.SetActive(true);
		anti9.SetActive(true);
		yield return new WaitForSeconds(2.7f);
		anti1.SetActive(false);
		anti2.SetActive(false);
		anti3.SetActive(false);
		anti4.SetActive(false);
		anti5.SetActive(false);
		anti6.SetActive(false);
		yield return new WaitForSeconds(2.8f);
		anti7.SetActive(false);
		anti8.SetActive(false);
		anti9.SetActive(false);
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}
}
