using UnityEngine;
using System.Collections;
//using UnityEditor;

public class TileableSpriteCreator : MonoBehaviour
{
    public GameObject[] spriteToBeCreated;
    private SpriteRenderer[] spriteRenderers;

    public int howMuch;
	public void CreateSprites ()
    {
        int index;

        spriteRenderers = new SpriteRenderer [spriteToBeCreated.Length];
        for (int j = 0 ; j<spriteToBeCreated.Length ; j++)
        {
            spriteRenderers[j] = spriteToBeCreated[j].renderer as SpriteRenderer;
        }

        for (int i = 0 ; i<howMuch ; i++)
        {
            index = Random.Range(0, spriteToBeCreated.Length);
            GameObject newInstance;
            newInstance = Instantiate(spriteToBeCreated[index], new Vector3 (i*spriteRenderers[index].sprite.bounds.size.x,transform.position.y,0), Quaternion.identity) as GameObject;
            newInstance.transform.parent = transform;
        }
    }
}
