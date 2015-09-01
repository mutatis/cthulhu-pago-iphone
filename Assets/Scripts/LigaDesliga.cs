using UnityEngine;
using System.Collections;

public class LigaDesliga : MonoBehaviour {

	public ElfBehaviour[] elf;
	public MineSpawner[] mine;
	public Transform trans;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(trans.position.x > 750)
		{
			for(int i = 0; i < mine.Length; i++)
			{
				mine[i].enabled = true;
			}
		}

		if(trans.position.x > 1250)
		{
			for(int i = 0; i < elf.Length; i++)
			{
				elf[i].enabled = true;
			}
		}
	}
}
