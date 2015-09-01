//
// Spawner.cs
//
// Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//
// Copyright (c) 2014 Yves J. Albuquerque
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


using UnityEngine;
using System.Collections;

/// <summary>
/// Spawner class.
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToBeSpawned;     // Array of enemy prefabs.
    public bool autoStart = true; //The spawn starts with the object otherwise you need to start spawn bu your own
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public float minSpawnTime = 1;
	public float maxSpawnTime = 8;
	public float minSpawnDelay = 2;
	public float maxSpawnDelay = 6;
	bool ok;
	public Controle link;

	private bool isRunningCoroutine;

	void Update()
	{
		if(PlayerPrefs.GetInt("dificuldade") == 1 && ok == false)
		{
			spawnDelay = spawnDelay*2;
			spawnTime = spawnTime*2;
			maxSpawnDelay = maxSpawnDelay*2;
			minSpawnDelay = minSpawnDelay*2;
			maxSpawnTime = maxSpawnTime*2;
			minSpawnTime = minSpawnTime*2;
			ok = true;
		}
		if(PlayerPrefs.GetInt ("Galinhas") >= 3)
		{
			spawnDelay = 0.3f;
			spawnTime = 0.3f;
			maxSpawnDelay = 0.3f;
			minSpawnDelay = 0.3f;
			maxSpawnTime = 0.3f;
			minSpawnTime = 0.3f;
		}
	}

	IEnumerator Start ()
	{
        yield return new WaitForSeconds(spawnDelay);
        NotificationCenter.DefaultCenter().AddObserver(this, "StartSpawner");
        NotificationCenter.DefaultCenter().AddObserver(this, "StopSpawner");

        if (autoStart)
            StartCoroutine("Spawn");
	}


    IEnumerator Spawn ()
	{
		isRunningCoroutine = true;

        // Start calling the Spawn function repeatedly after a delay .
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
    		// Instantiate a random enemy.
			if(link.link == false || ok == true)
			{
           		PoolManager.Pools["props"].Spawn(objectsToBeSpawned[0].transform, transform.position, transform.rotation);
				BroadcastMessage("OnSpawn", 1);
			}
			else
			{
				PoolManager.Pools["props"].Spawn(objectsToBeSpawned[1].transform, transform.position, transform.rotation);
				BroadcastMessage("OnSpawn", 1);
			}
    		// Play the spawning effect from all of the particle systems.
    		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
    		{
    			p.Play();
    		}
            yield return new WaitForSeconds(spawnTime);
        }

	}

    void StartSpawner ()
    {
        Random.seed ++;
        spawnTime = Random.Range(minSpawnTime,maxSpawnTime);
        spawnDelay = Random.Range(minSpawnDelay,maxSpawnDelay);

		if (!isRunningCoroutine)
        	StartCoroutine("Spawn");
    }

    void StopSpawner ()
    {
        StopCoroutine("Spawn");
		isRunningCoroutine = false;
    }

}