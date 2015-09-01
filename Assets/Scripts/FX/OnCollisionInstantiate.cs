using UnityEngine;
using System.Collections;

public class OnCollisionInstantiate : MonoBehaviour
{
    public int howMuch = 1;
    public GameObject instance;
    public InstantiationType iType;

    public Vector3 positionToInstantiate;

    public float upperLimit;
    public float bottomLimit;
    public float leftLimit;
    public float rightLimit;

    void OnCollisionEnter2D (Collision2D collision)
    {
		if(collision.gameObject.tag == "Player")
		{
	        if (!instance)
	            Debug.Log("An Instance of OnCollisionInstantiate in " + gameObject.name + " needs a Gameobject reference but null was found.");

	        for (int i = 0; i < howMuch; i++)
	        {
	            switch (iType)
	            {
	                case InstantiationType.PARENT:
	                    PoolManager.Pools ["props"].Spawn(instance.transform, transform.position, Quaternion.identity);
	                    break;
	                case InstantiationType.EXACTPOINT:
	                    PoolManager.Pools ["props"].Spawn(instance.transform, transform.position + positionToInstantiate, Quaternion.identity);
	                    break;
	                case InstantiationType.RANDOM:
	                    PoolManager.Pools ["props"].Spawn(instance.transform, transform.position + positionToInstantiate + new Vector3(Random.Range(leftLimit, rightLimit), Random.Range(upperLimit, bottomLimit), 0), Quaternion.identity);
	                    break;
	                case InstantiationType.LAUCHED:
	                    GameObject instantiatedObject;
	                    instantiatedObject = PoolManager.Pools ["props"].Spawn(instance.transform, transform.position, Quaternion.identity).gameObject;
	                    if (!instantiatedObject.rigidbody2D)
	                        instantiatedObject.AddComponent<Rigidbody2D>();
	                    if (instantiatedObject.rigidbody2D.isKinematic)
	                        instantiatedObject.rigidbody2D.isKinematic = false;
	                    instantiatedObject.rigidbody2D.gravityScale = 0.3f;
	                    instantiatedObject.rigidbody2D.AddForce(new Vector2 (Random.Range(leftLimit, rightLimit),Random.Range(bottomLimit, upperLimit)),ForceMode2D.Impulse);
	                    break;
	            }
	        }
		}

    }
}

public enum InstantiationType
{
    PARENT,
    EXACTPOINT,
    RANDOM,
    LAUCHED
}