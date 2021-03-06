﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterMotor))]
public class PlayerStateBase : StateBase
{
	private CharacterMotor motor;
	private bool InputEnabled = true;

	override protected void InitState()
	{
		base.InitState();
		motor = GetComponent<CharacterMotor>();
	}

	void FixedUpdate ()
	{
		if(InputEnabled)
		{
			UpdateInput();
		}
	}

	void UpdateInput()
	{
		// Get the input vector from keyboard or analog stick
		Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		
		if (directionVector != Vector3.zero) {
			// Get the length of the directon vector and then normalize it
			// Dividing by the length is cheaper than normalizing when we already have the length anyway
			float directionLength = directionVector.magnitude;
			directionVector = directionVector / directionLength;
			
			// Make sure the length is no bigger than 1
			directionLength = Mathf.Min(1, directionLength);
			
			// Make the input vector more sensitive towards the extremes and less sensitive in the middle
			// This makes it easier to control slow speeds when using analog sticks
			directionLength = directionLength * directionLength;
			
			// Multiply the normalized direction vector by the modified length
			directionVector = directionVector * directionLength;
		}
		
		// Apply the direction to the CharacterMotor
		motor.inputMoveDirection = transform.rotation * directionVector;
		motor.inputJump = Input.GetButton("Jump");
	}

	public virtual void EnableInput()
	{
		InputEnabled = true;
	}

	public virtual void DisableInput()
	{
		InputEnabled = false;
		motor.inputMoveDirection = Vector3.zero;
	}

	public virtual void Die()
	{
		if(enabled)
		{
			if(CanGoToState("Dead"))
			{
				GoToState("Dead");
			}
		}
	}
}
