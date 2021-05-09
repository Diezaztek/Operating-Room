using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

	public GameObject leftDoor;
	public GameObject rightDoor;

	AudioSource audioSource;
	public AudioClip soundFile;

	private bool opening = false;

	private Quaternion leftDoorStartRotation;
	private Quaternion leftDoorEndRotation;
	private Quaternion rightDoorStartRotation;
	private Quaternion rightDoorEndRotation;

	public float timer = 0f;
	public float rotationTime = 15f;


	void Start()
	{
		// TODO: Get a reference to the audio source
		// Use GetComponent<>() to get a reference to the AudioSource component and assign it to the 'audioSource'
		audioSource = GetComponent<AudioSource>();
		// TODO: Set start and end rotation values used when animating the door opening
		// Use 'leftDoor' to get the start rotation of the 'Left_Door' game object and assign it to 'leftDoorStartRotation'
		leftDoorStartRotation = leftDoor.transform.rotation;
		// Use 'leftDoorStartRotation' and Quaternion.Euler() to set the end rotation of the 'Left_Door' game object and assign it to 'leftDoorEndRotation'
		leftDoorEndRotation = leftDoorStartRotation * Quaternion.Euler(0f, 90f, 0f);
		// Use 'rightDoor' to get the start rotation of the 'Right_Door' game object and assign it to 'rightDoorStartRotation'
		rightDoorStartRotation = rightDoor.transform.rotation;
		// Use 'rightDoorStartRotation' and Quaternion.Euler() to set the end rotation of the 'Right_Door' game object and assign it to 'rightDoorEndRotation'
		rightDoorEndRotation = rightDoorStartRotation * Quaternion.Euler(0f, -90f, 0f);
	}


	void Update()
	{
		if (opening == true)
		{
			leftDoor.transform.rotation = Quaternion.Slerp(leftDoorStartRotation, leftDoorEndRotation, timer / rotationTime);
			rightDoor.transform.rotation = Quaternion.Slerp(rightDoorStartRotation, rightDoorEndRotation, timer / rotationTime);
			timer += Time.deltaTime;

		}
	}


	public void OnDoorClicked()
	{

		opening = true;
		audioSource.clip = soundFile;
		audioSource.Play();
		GetComponent<BoxCollider>().enabled = false;

	}
}
