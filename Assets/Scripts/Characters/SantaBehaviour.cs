using UnityEngine;
using System.Collections;

public class SantaBehaviour : MonoBehaviour
{
	public static SantaBehaviour santa;
    public Transform player; //player transform reference
    Jump2D playerJump2D; //player jump2d reference
    public SantaStates santaStates = SantaStates.BeforeEnter;

    public float amplitudeX = 1;
    public float frequencyX = 1;
    public float amplitudeY = 1;
    public float frequencyY = 1;

    public Vector3 offset;	// The offset at which Santa is from the player
    private Vector3 senoidalOffset;  // The offset at which Santa is from the player
    private Vector3 behaviourOffset;  // The offset at which Santa is from the player

    public float smoothMovement = 0.3F; //smooth the movement intensity
    public float smoothRotation = 2.0F; //smooth the rotation intensity

    private float timer; //Variable to track time
	private float rotationTimer = 0f; //Variable to track time
	private float sinDivisor = 20; //The divisor used in our sin curve
    private float timeToNextAnimation; //Variable used to trigger a stronger behaviour
    private Vector3 velocity = Vector3.zero; //velocity
    private float returnYPosition; // This variable has no use right now but is already implemented for future use. It tracks the return position so this character use it as a reference when the player jumps
    private bool isSpawnning;
	public AudioClip enter;

    void Awake()
    {
		//player = GameObject.Find("Cthulhu").transform; //finds player transform reference
		santa = this;
        NotificationCenter.DefaultCenter().AddObserver(this, "QuitScene");
        NotificationCenter.DefaultCenter().AddObserver(this, "ReceiveDamage");
        NotificationCenter.DefaultCenter().AddObserver(this, "OnDead");
        NotificationCenter.DefaultCenter().AddObserver(this, "StopSpawner");
        NotificationCenter.DefaultCenter().AddObserver(this, "OnLvlUp");

        playerJump2D = player.GetComponent<Jump2D>(); //finds Jump2D reference
    }

    void Start ()
    {
        timeToNextAnimation = Random.Range(5, 30);
        StartCoroutine("SenoidalMovement");
        StartCoroutine("LookToDirection");
    }

    IEnumerator SenoidalMovement () //Do a senoidal movement
    {
        while (true)
        {
            senoidalOffset.x = amplitudeX * Mathf.Sin(frequencyX*Time.time);
            senoidalOffset.y = amplitudeY * Mathf.Sin(frequencyY*Time.time);
            yield return 0;
        }
    }

    IEnumerator LookToDirection () //Rotate to move direction
    {
        while (true)
        {
            Quaternion rotation;
            if (velocity == Vector3.zero)
                velocity = Vector3.right;
            rotation = Quaternion.LookRotation(velocity);
            rotation.x = 0;
            rotation.y = 0;
            rotationTimer += Time.deltaTime * smoothRotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationTimer/1); 
            yield return 0;
        }
    }

    void FixedUpdate ()
    {
		if(player.position.y <= 0.5f)
		{
			offset.y = 4;
		}
		else
		{
			offset.y = player.position.y + 4f;
		}
		switch (santaStates)
        {
            case SantaStates.BeforeEnter:
                BeforeEnter();
                break;
            case SantaStates.Entering:
                GoingToPosition(offset);
                break;
            case SantaStates.DownAttackPosition:
                GoingToPosition(new Vector3(offset.x,offset.y - Random.Range(0,5)));
                ChooseAttackPosition();
                break;
            case SantaStates.MiddleAttackPosition:
                GoingToPosition(offset);
                ChooseAttackPosition();
                break;
            case SantaStates.UpperAttackPosition:
                GoingToPosition(new Vector3(offset.x,offset.y + Random.Range(0,5)));
                ChooseAttackPosition();
                break;
            case SantaStates.QuittingToTheRight:
                GoingToPosition(new Vector3(offset.x + 30,offset.y));
                break;
            case SantaStates.GoingToMiddle:
                GoingToPosition(new Vector3(offset.x - 30,offset.y));
                break;
            case SantaStates.QuittingToUp:
                GoingToPosition(new Vector3(offset.x,offset.y + 100));
                break;
        }
        Move();
    }

    void BeforeEnter ()
    {
        transform.position = new Vector3 (player.position.x - 80 ,player.position.y + offset.y + 10,0);
        transform.rotation = Quaternion.identity;
        StartCoroutine("WaitAndGoToMiddlePointPosition");
        santaStates = SantaStates.Entering;
    }

    IEnumerator WaitAndGoToMiddlePointPosition ()
    {
		yield return new WaitForSeconds (0.5f);
		AudioSource.PlayClipAtPoint (enter, transform.position, 0.5f);
        yield return new WaitForSeconds(5.5f);
		santaStates = SantaStates.MiddleAttackPosition;
    }
    
    
    void GoingToPosition (Vector3 newOffset)
    {
        behaviourOffset = iTween.Vector3Update(behaviourOffset,newOffset,smoothMovement);
    }
    
    void ChooseAttackPosition ()
    {
        timer += Time.deltaTime;
        if (timer < 2)
            return;

        timer = 0;
		if (santaStates == SantaStates.DownAttackPosition && transform.position.y < player.position.y)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    santaStates = SantaStates.UpperAttackPosition;
                    break;
                case 1:
                    santaStates = SantaStates.MiddleAttackPosition;
                    break;
            }
        } else if (santaStates == SantaStates.MiddleAttackPosition && transform.position.y <= player.position.y)
        {
            santaStates = SantaStates.UpperAttackPosition;
        } else if (santaStates == SantaStates.MiddleAttackPosition && transform.position.y >= player.position.y)
        {
            santaStates = SantaStates.DownAttackPosition;
        } else if (santaStates == SantaStates.UpperAttackPosition && transform.position.y <= player.position.y)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    santaStates = SantaStates.DownAttackPosition;
                    break;
                case 1:
                    santaStates = SantaStates.MiddleAttackPosition;
                    break;
            }
        }
        else
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    santaStates = SantaStates.DownAttackPosition;
                    break;
                 case 1:
                    santaStates = SantaStates.MiddleAttackPosition;
                    break;
                case 2:
                   santaStates = SantaStates.UpperAttackPosition;
                   break;
            }
        }
    }

    void Move ()
    {
        if (playerJump2D.grounded) //there's different behaviours if the player is on the ground our it isn't
        {
            returnYPosition = player.position.y; //we updates our return position on the ground every frame
            transform.position = Vector3.SmoothDamp(transform.position, player.position + senoidalOffset + behaviourOffset, ref velocity, smoothMovement); //when the player is on the ground, we just try to stay at offset distance from the player
        }
        else
            transform.position = Vector3.SmoothDamp(transform.position,
                                                    new Vector3(player.position.x +senoidalOffset.x + behaviourOffset.x,returnYPosition +senoidalOffset.y+behaviourOffset.y,transform.position.z),ref velocity, smoothMovement); //when the player is off the ground, we use the return position as reference so this character don't go out our screen just because the player is jumping
    }


    public void ReceiveDamage ()
    {
        if (!(santaStates == SantaStates.UpperAttackPosition || santaStates == SantaStates.MiddleAttackPosition || santaStates == SantaStates.DownAttackPosition))
            return;

        santaStates = SantaStates.QuittingToTheRight;
        if (!isSpawnning)
        {
            isSpawnning = true;
            NotificationCenter.DefaultCenter().PostNotification(this, "StartSpawner");
        }
    }

    public void StopSpawner ()
    {
        isSpawnning = false;
        santaStates = SantaStates.BeforeEnter;
    }
    
    IEnumerator OnDead ()
    {
        santaStates = SantaStates.MiddleAttackPosition;
        yield return new WaitForSeconds(5f);
        santaStates = SantaStates.QuittingToUp;
    }

    IEnumerator QuitScene ()
	{
        santaStates = SantaStates.MiddleAttackPosition;
        yield return new WaitForSeconds(3f);
        santaStates = SantaStates.QuittingToUp;
    }

    void OnLvlUp ()
    {
        Vector3 newOffSet;
        newOffSet = new Vector3 (offset.x + 3, offset.y, offset.z);
        offset = newOffSet;
    }


    public enum SantaStates
    {
        None,
        Entering,
        BeforeEnter,
        QuittingToTheRight,
        GoingToMiddle,
        QuittingToUp,
        DownAttackPosition,
        MiddleAttackPosition,
        UpperAttackPosition
    }
}