using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LvlUp : MonoBehaviour
{
    public RigidBody2DUnidirectional rigidBody2DUnidirectional;
	public RigidBody2DUnidirectional rigidBody2DUnidirectional2;
    public bool speedUp = false;
    public bool changeSpawnTime = false;

    private delegate void MyDelegate (int num);
    private MyDelegate lvlUp;
	int h;

    void Start ()
    {
        NotificationCenter.DefaultCenter().AddObserver(this,"OnLvlUp");

		if(PlayerPrefs.GetString("Dagon") == "Dagon")
		{
			h = 1;
		}
		else{
			h = 2;
		}

        if (speedUp)
            lvlUp += SpeedUp;
        if (changeSpawnTime)
            lvlUp += ChangeSpawnTime;

		if (GameManager.gameManager.lvlUpCallsInTheLastMission > 0)
			lvlUp (GameManager.gameManager.lvlUpCallsInTheLastMission);

    }

    void OnLvlUp (Notification callNumber)
    {
        lvlUp((int)callNumber.data);
    }

    void SpeedUp (int speedReductor)
    {
		if(h == 2)
       		rigidBody2DUnidirectional.maxSpeed += 3+speedReductor;

		if(h == 1)
			rigidBody2DUnidirectional2.maxSpeed += 3+speedReductor;
    }

    void ChangeSpawnTime (int callNumber)
    {
        Spawner[] spawners;
		MultiSpawner[] multiSpawners;

        spawners = FindObjectsOfType(typeof(Spawner)) as Spawner[];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].maxSpawnTime --;
        }

		multiSpawners = FindObjectsOfType(typeof(MultiSpawner)) as MultiSpawner[];
		
		for (int i = 0; i < multiSpawners.Length; i++)
		{
			multiSpawners[i].spawnTime --;
		}

    }
}