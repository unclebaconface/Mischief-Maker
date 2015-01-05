using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float Distance;
	public Transform Target;
	public float lookAtDistance = 25f;
	public float chaseRange = 15f;
	public float moveSpeed = 5.0f;
	public bool lookingAtCube = false;

	void Update(){
		Distance = Vector3.Distance(Target.position, transform.position);
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 offset = transform.TransformDirection (5, 5, 0);
		Vector3 offset2 = transform.TransformDirection (-5, -5, 5);
		RaycastHit hit;

		Debug.DrawRay (transform.position, forward * 10, Color.red);
		Debug.DrawRay (transform.position, offset * 10, Color.red);
		Debug.DrawRay (transform.position, offset2 * 10, Color.red);

		if ((Distance < lookAtDistance) && !lookingAtCube) {
			lookAt();
		}

		if ((Distance < chaseRange) && !lookingAtCube) {
			chase();
		}

		if(Physics.Raycast(transform.position, transform.forward, out hit, 10)){
			if(hit.collider.gameObject.tag == "Cube"){
				lookingAtCube = true;
			}
		}
		if(Physics.Raycast(transform.position, offset, out hit, 10)){
			if(hit.collider.gameObject.tag == "Cube"){
				lookingAtCube = true;
			}
		}
		if(Physics.Raycast(transform.position, offset2, out hit, 10)){
			if(hit.collider.gameObject.tag == "Cube"){
				lookingAtCube = true;
			}
		}


	}

	void lookAt() {
		transform.LookAt(Target);
	}

	void chase() {
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
	}
}



	/*
	public Transform Target;
	public float MoveSpeed = 3f;
	public float RotationSpeed = 3f;

	private Transform _transform;

	void Awake(){
		_transform = transform;
	}

	// Use this for initialization
	void Start () {
		Target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.rotation = Quaternion.Slerp (_transform.rotation, Quaternion.LookRotation (Target.position - _transform.position), RotationSpeed * Time.deltaTime);
		_transform.position += _transform.forward*MoveSpeed*Time.deltaTime;
	}
}
*/