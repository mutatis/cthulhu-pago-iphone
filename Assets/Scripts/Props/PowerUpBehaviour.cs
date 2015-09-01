using UnityEngine;
using System.Collections;

public class PowerUpBehaviour : MonoBehaviour
{
    public static bool hasInstance = false;
    public static float rate = 1;

    public ParticleSystem effect;
    public Renderer[] rendererToBeOccluded;

    protected bool isInCharacter = false;

	public static int cont;

    private Vector3 directionToMove;

    public virtual void OnSpawned ()
    {
        isInCharacter = false;
    }

    void Update ()
    {
       if (!isInCharacter)
       {
            if (Vector3.Distance(transform.position, IABuyDagon.buyDagon.transform.position) < 60)
            {
                directionToMove = new Vector3 (25f*Time.deltaTime,Mathf.Sin(2*Time.time)*0.4f,0);
                if ((transform.position.y < 0 && directionToMove.y < 0)||(transform.position.y > 30 && directionToMove.y > 0))
                {
                    directionToMove = new Vector3 (directionToMove.x,-directionToMove.y,directionToMove.z);
                }
                transform.Translate(directionToMove);
            }

			if (IABuyDagon.buyDagon.transform.position.x - transform.position.x > 60)
            {
                PowerUpBehaviour.SpawnNewItem();
                PoolManager.Pools["props"].Despawn(transform);
            }
        }

    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        OnTriggerEnter2D (collision.collider);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PowerUpBehaviour.SpawnNewItem();

            isInCharacter = true;
            
            foreach (Renderer sR in rendererToBeOccluded)
                sR.enabled = false;
            if (effect)
                PoolManager.Pools["props"].Spawn (effect,transform.position,transform.rotation);
			//transform.position = ola.oi.transform.position;
			transform.parent = IABuyDagon.buyDagon.transform;
			if(PlayerPrefs.GetInt("Srepelente") != 1)
			{
				iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(2f,2f,2f)));
				iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(1f,1f,1f),"delay",1.1f));
			}
            
        }

        ApplyEffect (collider);
    }

    static public void SpawnNewItem ()
    {
		if(cont <= 1)
		{
			Vector3 positionToSpawn = new Vector3(IABuyDagon.buyDagon.transform.position.x + Random.Range(1000,3000), 12, 0);
        	PoolManager.Pools["props"].Spawn("OftenSpawner", new Vector3(positionToSpawn.x + 500, positionToSpawn.y, positionToSpawn.z), Quaternion.identity);
			cont ++;
		}
    }
    public virtual void ApplyEffect (Collider2D collider)
    {
        
    }
}