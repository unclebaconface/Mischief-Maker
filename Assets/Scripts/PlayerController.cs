using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

public class PlayerController : MonoBehaviour {
	
	public float rotationSpeed = 360;
	public float walkSpeed = 5;

	private Quaternion targetRotation;

	public PlayerToy toy;
	private CharacterController controller;
	
	// Use this for initialization
	void Start () {
		
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Shoot")) {
						toy.Shoot ();
		} 
		else if (Input.GetButton ("Shoot")) {
			toy.ShootContinuous();		
		}
		
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
		
		if (input != Vector3.zero) {
			targetRotation = Quaternion.LookRotation(input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);
		}
		
		Vector3 motion = input;
		motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1)?.7f:1;
		motion += Vector3.up * -8;
		
		controller.Move (motion * Time.deltaTime);
	}
}