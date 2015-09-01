using UnityEngine;
using System.Collections;

public class LightTravelBehaviour : PowerUpBehaviour
{
    GameObject player;
    RigidBody2DUnidirectional rigidBody2DUnidirectional;
    UserControl newUserControl;
    RigidBody2DUnidirectional newRigidBody2DUnidirectional;
    Jump2D jump2d;
    SpriteRenderer backgrondDarkner;
    float initialMaxSpeed;
	public AudioClip[] getD;
	public AudioClip[] getC;
	int random;

    public override void OnSpawned ()
    {
        base.OnSpawned ();
        if (!player)
        {
            player = PlayerStatus.playerStatus.gameObject;
            rigidBody2DUnidirectional = player.GetComponent<RigidBody2DUnidirectional>();
            jump2d = player.GetComponent<Jump2D>();
            backgrondDarkner = Camera.main.transform.FindChild("BackgroundDarkener").GetComponent<SpriteRenderer>();
        }
        newUserControl = null;
        newRigidBody2DUnidirectional = null;
    }
    public override void ApplyEffect (Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            GetComponent<CircleCollider2D>().radius = 10;
			if(PlayerPrefs.GetString("Dagon") == "Dagon")
			{
				random = Random.Range(0, getD.Length);
				AudioSource.PlayClipAtPoint(getD[random], transform.position, 1f);
				iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(0f,1.5f,0f), "islocal", true));
			}
			else
			{
				random = Random.Range(0, getC.Length);
				AudioSource.PlayClipAtPoint(getC[random], transform.position, 1f);
				iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(0f,5f,0f), "islocal", true));
			}
            StartCoroutine("UsingLightTravel", 8);
        }
        if (collider.CompareTag("Coin")&& isInCharacter)
        {
            ChasePlayer followPlayer = collider.gameObject.AddComponent(typeof(ChasePlayer)) as ChasePlayer;
        }
    }

    public IEnumerator UsingLightTravel (float time)
    {
		PlayerStatus.playerStatus.pause = true;
		for(int i = 0; i < PlayerStatus.playerStatus.othersSpriteRenderer.Length; i++)
		{
			PlayerStatus.playerStatus.othersSpriteRenderer [i].enabled = false;
		}
		PlayerStatus.playerStatus.headSpriteRenderer.enabled = false;
        initialMaxSpeed = rigidBody2DUnidirectional.maxSpeed; //record maxSpeed so we can return to this value later
        player.rigidbody2D.velocity = new Vector2 (0,0);
        player.rigidbody2D.gravityScale = 0.01f;

        backgrondDarkner.enabled = true;

        PlayerStatus.playerStatus.InvulnerableByXTimes(time, false);
        PlayerStatus.playerStatus.headSpriteRenderer.enabled = false;
        PlayerStatus.playerStatus.bodySpriteRenderer.enabled = false;
		for(int i = 0; i < PlayerStatus.playerStatus.othersSpriteRenderer.Length; i++)
		{
			PlayerStatus.playerStatus.othersSpriteRenderer[i].enabled = false;
		}
        foreach (SpriteRenderer spriteRenderer in PlayerStatus.playerStatus.othersSpriteRenderer)
            spriteRenderer.enabled = false;

        if (jump2d)
        {
            jump2d.enabled = false;
            newRigidBody2DUnidirectional = player.AddComponent<RigidBody2DUnidirectional>();
            newRigidBody2DUnidirectional.axisToMove = Axis.y;
            newRigidBody2DUnidirectional.autoMove = false;
            newRigidBody2DUnidirectional.hasLimit = true;
            newRigidBody2DUnidirectional.moveForce = 15;
            newRigidBody2DUnidirectional.upperLimit = 20f;
            newRigidBody2DUnidirectional.bottomLimit = 0f;

            newUserControl = player.AddComponent<UserControl>();
            newUserControl.axisToMove = Axis.y;
            newUserControl.rigidBody2DUnidirectional = newRigidBody2DUnidirectional;
        }

        while (player.rigidbody2D.velocity.x < 65 && time > 0)
        {
            rigidBody2DUnidirectional.maxSpeed *= 1.1f;
            time -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds (time);
		PlayerStatus.playerStatus.pause = false;
        //magneticPrefab.GetComponent<Animator>().speed = 5;
        //yield return new WaitForSeconds (3);
        PoolManager.Pools["props"].Despawn (transform);
    }

    void OnDespawned ()
    {
		for(int i = 0; i < PlayerStatus.playerStatus.othersSpriteRenderer.Length; i++)
		{
			PlayerStatus.playerStatus.othersSpriteRenderer [i].enabled = true;
		}
		PlayerStatus.playerStatus.headSpriteRenderer.enabled = true;
        backgrondDarkner.enabled = false;
        PlayerStatus.playerStatus.InvulnerableByXTimes(3, true);

        PlayerStatus.playerStatus.headSpriteRenderer.enabled = true;
        PlayerStatus.playerStatus.bodySpriteRenderer.enabled = true;
		for(int i = 0; i < PlayerStatus.playerStatus.othersSpriteRenderer.Length; i++)
		{
			PlayerStatus.playerStatus.othersSpriteRenderer[i].enabled = true;
		}
        player.rigidbody2D.gravityScale = 2;
        
        foreach (SpriteRenderer spriteRenderer in PlayerStatus.playerStatus.othersSpriteRenderer)
            spriteRenderer.enabled = true;
        player.rigidbody2D.velocity = new Vector2 (initialMaxSpeed,0);
        
        rigidBody2DUnidirectional.maxSpeed = initialMaxSpeed;

        //turn off effects
        if (jump2d)
        {
            jump2d.enabled = true;
            Destroy (newUserControl);
            Destroy (newRigidBody2DUnidirectional);
        }
    }
}
