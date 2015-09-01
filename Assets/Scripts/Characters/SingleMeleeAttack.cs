using UnityEngine;
using System.Collections;
using System.Linq;

public class SingleMeleeAttack : MonoBehaviour
{
    public float attackDistance = 16;
    private RaycastHit2D[] targets;
    private bool isAttacking = false;
	public int attack;
	public int cont;
	public AudioClip slash;
	public AudioClip galinhas;
	public GameObject aerialExplosion;

    public void Attack ()
    {
		if(attack != 0)
		{
			AudioSource.PlayClipAtPoint (slash, transform.position, 1f);
		}
		//attack.SetTrigger ("Attack");
        isAttacking = true;
        //yield return new WaitForSeconds(0.2f);
        targets = Physics2D.RaycastAll((Vector2)transform.position + new Vector2(0, 4), Vector2.right, attackDistance, 1 << LayerMask.NameToLayer("Destroyable"));
        if (targets.Length == 0)
            targets = Physics2D.RaycastAll((Vector2)transform.position + new Vector2(0, 8), Vector2.right, attackDistance, 1 << LayerMask.NameToLayer("Destroyable"));
        if (targets.Length == 0)
            targets = Physics2D.RaycastAll((Vector2)transform.position + new Vector2(0, 2), Vector2.right, attackDistance,1 << LayerMask.NameToLayer("Destroyable"));

        //Debug.DrawLine((Vector2)transform.position + new Vector2(0, 8), (Vector2)transform.position + new Vector2(18, 8));
        //Debug.DrawLine((Vector2)transform.position + new Vector2(0, 2), (Vector2)transform.position + new Vector2(18, 2));
        audio.Play();
        //Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(15, 3));
		if(attack == 0)
		{
	        for (int i = 0; i < targets.Length; i++)
	        {
	            targets[i].collider.SendMessage("ApplyDamage");
	        }
		}
		else
		{
			for (int i = 0; i < targets.Length; i++)
			{
				Destroy(targets[i].collider.gameObject);
				AudioSource.PlayClipAtPoint(galinhas, transform.position, 1);
				PoolManager.Pools["fx"].Spawn(aerialExplosion.transform, new Vector3(transform.position.x + 28, transform.position.y, transform.position.z), Quaternion.identity);
				
				iTween.ShakePosition(Camera.main.transform.root.gameObject, iTween.Hash("amount",new Vector3 (1f,1f,1f), "islocal", true));
				
				PoolManager.Pools["props"].Despawn(transform);
				cont ++;
				PlayerPrefs.SetInt("Galinhas", cont);
			}
		}
        isAttacking = false;
    }
}