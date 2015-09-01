using UnityEngine;
using System.Collections;

public class CravedIdolBehaviour : MonoBehaviour
{
    public GameObject iDol;
    public ParticleSystem breakFx;
    public AudioClip spawnIdolSfx;

    public void ApplyDamage()
    {
        // Play the collection sound.
        //breakFx.transform.parent = null;
        breakFx.Play();
        PoolManager.Pools["props"].Spawn(iDol.transform, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(spawnIdolSfx, transform.position, 1f);
        gameObject.SetActive(false);
    }
}
