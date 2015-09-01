using UnityEngine;
using System.Collections;

public class LaserRay : MonoBehaviour
{
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    float ray1_startPoint = 0;
    float ray2_startPoint = 0;
    float ray1_EndPoint = 0;
    float ray2_EndPoint = 0;

    void Update ()
    {
        ray1_EndPoint = iTween.FloatUpdate(ray1_EndPoint, 40, 20);

        if (ray1_EndPoint > 25)
        {
            ray1_startPoint = iTween.FloatUpdate(ray1_startPoint, 40, 20);
        }
        lineRenderer1.SetPosition(0,new Vector3 (0,ray1_startPoint,0));
        lineRenderer2.SetPosition(0,new Vector3 (0,-ray1_startPoint,0));
        lineRenderer1.SetPosition(1,new Vector3 (0,ray1_EndPoint,0));
        lineRenderer2.SetPosition(1,new Vector3 (0,-ray1_EndPoint,0));
    }

	IEnumerator OnCollisionEnter2D (Collision2D collision)
	{			
		yield return new WaitForEndOfFrame();

        if (collision.transform.tag == "Player")
		{
			NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
            PoolManager.Pools["props"].Despawn(transform);
			return false;
		}
        if (collision.transform.tag == "Gift" || collision.transform.tag == "Rocket")
        {
            NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveAGift", transform.position);
            PoolManager.Pools["props"].Despawn(transform);
        }
        else
		{
            PoolManager.Pools["props"].Despawn(transform);
		}
	}
}


//Old laser code
/*



// Update is called once per frame
void Update ()
{
    ray1_EndPoint = iTween.FloatUpdate(ray1_EndPoint, 4, 8);
    if (ray1_EndPoint > 25)
        {
            ray1_startPoint = iTween.FloatUpdate(ray1_startPoint, 4, 8);
            ray2_startPoint = iTween.FloatUpdate(ray2_startPoint, -4, 8);
        }
    lineRenderer1.SetPosition(0,Vector3.zero);
    lineRenderer2.SetPosition(0,Vector3.zero);
    lineRenderer1.SetPosition(1,new Vector3 (0,ray1_EndPoint,0));
    lineRenderer2.SetPosition(1,new Vector3 (0,ray1_EndPoint,0));
}

void OnCollisionEnter2D (Collision2D collision)
{
    
    if (collision.transform.tag == "Player")
    {
        NotificationCenter.DefaultCenter().PostNotification(this,"ReceiveDamage", transform.position);
        //iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("amount",new Vector3 (1f,1f,1f), "islocal", true));
        
        Destroy (gameObject);
        return;
    }
    else
    {
        Destroy (collision.gameObject);
    }
}
*/