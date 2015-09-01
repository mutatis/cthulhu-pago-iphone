using UnityEngine;
//using UnityEditor;
using System.Collections;


public class SpawnerOnTheFront : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public bool timeBased;
    public float minDistance = 5;
    public float maxDistance = 10;
    public float distanceToNextSpawn = 0;
    private Transform player;
    private float currentDistance;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        distanceToNextSpawn = currentDistance = player.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (distanceToNextSpawn < currentDistance)
        {
            //GameObject newSpawnedObject;
            distanceToNextSpawn = currentDistance + Random.Range(minDistance, maxDistance);
            //newSpawnedObject = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)]) as GameObject;
            //newSpawnedObject.transform.position.x
        }
	}


}