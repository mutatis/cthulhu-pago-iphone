using UnityEngine;
using System.Collections;

public class LaserBehaviour : MonoBehaviour
{
	private LaserStates laserState = LaserStates.lauched;
    public Sprite mineState;
	public ParticleSystem groundExplosion;
	public ParticleSystem aerialExplosion;
	public float timeToStop;
	public float timeToGo;
	public float timeBetweenFire = 2;
	public GameObject ray;
	private float timer = 0;

	void Update ()
	{
		timer += Time.deltaTime;
		switch(laserState)
		{
		case LaserStates.lauched:
			Lauched ();
			break;
		case LaserStates.firing:
			Firing ();
			break;
		case LaserStates.going:
			Going ();
			break;
		}
	}

	private void Lauched ()
	{
		if (timer > timeToStop)
		{
			rigidbody2D.isKinematic = true;
			timer = 0;
			transform.parent = Camera.main.transform;
			laserState = LaserStates.firing;
		}
	}

	private void Firing ()
	{
		if (timer > timeToGo)
		{
			rigidbody2D.isKinematic = false;
			timer = 0;
			transform.parent = null;
			laserState = LaserStates.going;
		}

		if (timer/timeBetweenFire > 1)
		{
			timeBetweenFire+=2;
            PoolManager.Pools["props"].Spawn(ray.transform, transform.position, transform.rotation);
            timer = 0;
		}
		
		transform.Rotate(new Vector3(0,0,1));
	}

	private void Going ()
	{
		collider2D.enabled = true;
	}

	IEnumerator OnCollisionEnter2D (Collision2D collision)
	{
		yield return new WaitForEndOfFrame();

        if (collision.transform.tag == "Gift" || collision.transform.tag == "Rocket")
        {
            PoolManager.Pools["fx"].Spawn(aerialExplosion, transform.position, Quaternion.identity);
            PoolManager.Pools["props"].Despawn(transform);
        }
    }
}
		
		
		
public enum LaserStates
{
	lauched,
	firing,
	going
}