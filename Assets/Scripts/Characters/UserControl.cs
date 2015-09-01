using UnityEngine;
using System.Collections;


public class UserControl : MonoBehaviour
{
    public Axis axisToMove; //Axis to player movement

	public int ia_jump;

    public RigidBody2DUnidirectional rigidBody2DUnidirectional;
    private SingleMeleeAttack singleMeleeAttack;
    private Jump2D jump2d;

    public bool analogicInput;  //true if the input is analogic and has several degrees of movement

    private float inputForce = 1;
    private float touchDirection = 0;
	public int indi;
	public static UserControl userControl;
	int x;
	public int limit;

    // Use this for initialization
	void Awake ()
    {
		userControl = this;
        if (!rigidBody2DUnidirectional)
            rigidBody2DUnidirectional = GetComponent<RigidBody2DUnidirectional>();
        if (!singleMeleeAttack)
            singleMeleeAttack = GetComponent<SingleMeleeAttack>();
        jump2d = GetComponent<Jump2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (rigidBody2DUnidirectional)
            Move();

        if (jump2d)
            Jump ();

      //  if (singleMeleeAttack)
           // Attack ();
	}


    void Move ()
    {
        if (axisToMove == Axis.x)
        {
            inputForce = Input.GetAxis("Horizontal"); // Cache the horizontal input.
        }
        if (axisToMove == Axis.y)
        {
            inputForce = Input.GetAxis("Vertical"); // Cache the vertical input.
        }

        //If not analogic
        if (!analogicInput)
        {
            if (inputForce > 0.1f)
            {
                inputForce = 1;
            }
            else if (inputForce < -0.1f)
            {
                inputForce = -1;
            }
            else
                inputForce = 0;
        }

        if (Input.touchCount>0)
        {
            inputForce = touchDirection;
        }

		if(transform.position.x > limit)
		{
			inputForce ++;
			limit += 500;
		}

        rigidBody2DUnidirectional.Move(inputForce);
    }

	public void JumpLink()
	{
		jump2d.Jump ();
	}
    
    void Jump ()
    {
		if(indi == 0)
		{
	        if (Input.GetButtonDown("Fire1"))
	            jump2d.Jump();

			if (Input.GetButtonUp("Fire1"))
	            jump2d.StopJump();
		}
    }

    void Attack ()
    {
#if UNITY_EDITOR
		if (Input.GetButtonDown("Fire1"))
        {
            singleMeleeAttack.Attack();
        }
#endif
    }

    public void SetTouchDirection (float inputValue)
    {
        touchDirection = inputValue;
    }
}
