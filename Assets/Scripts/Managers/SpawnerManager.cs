using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour
{
    bool spawning = false;
	// Use this for initialization
	void Start ()
	{
        NotificationCenter.DefaultCenter().AddObserver(this, "StartSpawner");
	}

    IEnumerator StartSpawner ()
    {
        if (!spawning)
        {
            spawning = true;
            yield return new WaitForSeconds(Random.Range(5,15));
            NotificationCenter.DefaultCenter().PostNotification(this, "StopSpawner");
            spawning = false;
        }
    }
}
