using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jump;

	public float speedCamera;


	[Space(20)]

	public Rigidbody Rigidbody;
	public Animator Animator;

	public Camera Camera;
	public GameObject AnchorCamera;

	[Space(20)]

	public GameObject BallGameObject;
	public GameObject BallGameObjectTab;

	public GameObject Cible;

	private Vector3 baseRotation;

	void Start() {
		baseRotation = transform.localEulerAngles;
	}

	void Update() {
		UpdateMove();
		UpdateRotation();
		UpdateShoot();

	}

	private GameObject[] ballObjectTab = new GameObject[5];
	private int fillBall=0;
	private void UpdateShoot() {
		if (Input.GetButtonDown("Fire")) {
			if (ballObjectTab[fillBall] != null) {
				Destroy(ballObjectTab[fillBall]);
			}

			ballObjectTab[fillBall] = (GameObject) Instantiate(BallGameObject, Rigidbody.transform.position + (Rigidbody.transform.rotation * Vector3.forward * 2) + new Vector3(0, 1, 0), Rigidbody.transform.rotation);


			ballObjectTab[fillBall].GetComponent<Rigidbody>().velocity = (Rigidbody.transform.rotation * Vector3.forward * 50);
			ballObjectTab[fillBall].transform.parent = BallGameObjectTab.transform;

			fillBall++;

			if (fillBall >= ballObjectTab.Length) {
				fillBall = 0;
			}
		}

	}


	private void UpdateMove() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


		if (Input.GetButtonDown("Run")) {
			speed = speed * 2;
		} else if (Input.GetButtonUp("Run")) {
			speed = speed / 2;
		}
		Animator.speed = Mathf.Clamp((Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical)), 0, 1);
		Vector3 v = Camera.transform.TransformDirection(movement);

		Rigidbody.transform.position = Rigidbody.transform.position + new Vector3(v.x, 0, v.z) * speed * Time.deltaTime;


		Rigidbody.transform.LookAt(Rigidbody.transform.position + new Vector3(v.x, 0, v.z) * speed * Time.deltaTime);



		if (Input.GetButtonDown("Jump")) {
			Rigidbody.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
		}






	

	}

	private void UpdateRotation() {
		float moveHorizontal = Input.GetAxis("Horizontal2");
		float moveVertical = Input.GetAxis("Vertical2");
		if (Mathf.Abs(moveHorizontal) > 0.2f) {
			AnchorCamera.transform.eulerAngles += new Vector3(0, moveHorizontal * speedCamera, 0);
		}

	}

}