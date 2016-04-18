using UnityEngine;
using System.Collections;

public class CharacMove : MonoBehaviour {

	public float speed = 10f;
	public float JumpHigh = 10f;
	public Transform CharacTransform;
	public Rigidbody CharacRigidbody;

	private Vector3 CharacTransformPos;
 
	void Start() {
		CharacTransformPos = CharacTransform.position;
	}


	void Update() {
		UpdateMove();
		UpdateRotation();
	}


	#region UpdateMove

	void UpdateMove() {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			speed = speed * 2;
		} else if (Input.GetKeyUp(KeyCode.LeftShift)) {
			speed = speed / 2;
		}

		if (Input.GetKey(KeyCode.Z)) {
			CharacTransformPos.z += speed / 100;
		}


		transform.position = Vector3.MoveTowards(transform.position, CharacTransformPos, speed * Time.deltaTime);
	}
	#endregion


	#region UpdateRotation
	public void UpdateRotation() {
		CharacTransform.localEulerAngles = new Vector3(CharacTransform.localEulerAngles.x, Input.mousePosition.x/2, CharacTransform.localEulerAngles.z);
	}
	#endregion
}
