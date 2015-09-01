using UnityEngine;
using System.Collections;

public class OftenSpawn : MonoBehaviour
{
    public static float[] broughtProbalitys = {0, 0, 0, 0, 0};
    public Item[] item0;
	public Item[] item1;
	public Item[] item2;
	int x;
	int itemIndex = Random.Range(0, 5);
	int temp;

	void Start()
	{
		temp = PlayerPrefs.GetInt("tempSalva");
		while(temp == itemIndex)
		{
			itemIndex = Random.Range(0, 5);
			if(itemIndex < 0)
				itemIndex = Random.Range(0, 5);
		}
	}

	void Update()
	{
		PlayerPrefs.SetInt("tempSalva", temp);

		temp = itemIndex;

		temp = PlayerPrefs.GetInt("tempSalva");
		while(temp == itemIndex)
		{
			itemIndex = Random.Range(0, 5);
			if(itemIndex < 0)
				itemIndex = Random.Range(0, 5);
		}
	}

    void OnSpawned ()
    {
        if (item0[itemIndex].gameObject && x == 0)
		{
           PoolManager.Pools["props"].Spawn(item0[itemIndex].gameObject.transform, transform.position, Quaternion.identity);
			x ++;
		}
		else if (item1[itemIndex].gameObject && x == 1)
		{
			PoolManager.Pools["props"].Spawn(item1[itemIndex].gameObject.transform, transform.position, Quaternion.identity);
			x ++;
		}
		else if (item2[itemIndex].gameObject && x == 2)
		{
			PoolManager.Pools["props"].Spawn(item2[itemIndex].gameObject.transform, transform.position, Quaternion.identity);
			x ++;
		}
    }
	
  /*  int Choose(float[] probs)
    {
        float total = 0;
        
        foreach (float elem in probs)
        {
            total += elem;
        }
        
        float randomPoint = Random.value * total;
        
        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
                return i;
            else
                randomPoint -= probs[i];
        }
        
        return probs.Length - 1;
    }*/
}

[System.Serializable]
public class Item
{
    public GameObject gameObject;
    public float probability;
}