using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour 
{
	public float movementSpeed = 1f;

	private enum MovementIndicator
	{
		Keyboard,
		Mouse
	}

	private Vector3 resetPositon;

	//Not used for now, only keyboard camera movement allowed at this time
	//Private for now, change when mouse camera movement is implemented

	//private MovementIndicator movementType = MovementIndicator.Keyboard;

	public void Start()
	{
		resetPositon = transform.position;
	}

	public void LateUpdate()
	{
		MoveByKeyboard();

		if(Input.GetButton("Reset Camera"))
		{
			transform.position = resetPositon;
		}
	}

	//TODO:
	//Implement system for resetting cameraResets based on WorldInteraction
	public void SetResetPosition(Vector3 newPosition)
	{
		this.resetPositon = new Vector3(newPosition.x, newPosition.y, -10);
	}

	//Possibly some frame cuts
	private void MoveByKeyboard()
	{
		float verticalTranslation = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		float horizontalTranslation = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

		transform.Translate(horizontalTranslation, verticalTranslation, 0);
	}

	private void MoveByMouse()
	{
		throw new NotImplementedException();
	}

}
