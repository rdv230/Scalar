using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 6.0F;
	public float rotSpeed = 3.0F;
//	public float jumpSpeed = 8.0F;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		controller.Move(moveDirection * Time.deltaTime);
		transform.RotateAround(transform.position,Vector3.up,Input.GetAxis("Mouse X") * rotSpeed);
		//transform.RotateAround(transform.position,Vector3.left,Input.GetAxis("Mouse Y") * rotSpeed);
	}

	void Start(){
		if(DistanceCheck.played > 2){
			speed = 6.0F * DistanceCheck.played/5;
		}
	}


}