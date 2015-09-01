using UnityEngine;
using System.Collections;

public class DesativandoIndi : MonoBehaviour
{

	public Jump2D jump2d;
	public PlayerStatus playerstatus;
	public CthulhuAnimationSetter animation;
	public RigidBody2DUnidirectional dire;
	public SingleMeleeAttack single;
	public UserControl user;
	public GameObject[] braco;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(PlayerStatus.playerStatus.lives <= 0)
		{
			for(int i = 0; i < braco.Length; i++)
			{
				braco[i].SetActive(false);
			}
			jump2d.enabled = false;
			playerstatus.enabled = false;
			animation.enabled = false;
			dire.enabled = false;
			single.enabled = false;
			user.enabled = false;
		}
	}
}