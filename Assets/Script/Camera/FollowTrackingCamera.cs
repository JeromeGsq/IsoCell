using UnityEngine;
using System.Collections;


public class FollowTrackingCamera : MonoBehaviour {
	// Camera target to look at.
	public Transform target;

	// Exposed vars for the camera position from the target.
	public float height = 20f;
	public float distance = 20f;

	// Camera limits.
	public float min = 10f;
	public float max = 60;

	// Rotation.
	public float rotateSpeed = 1f;

	// Options.
	public bool doRotate;
	public bool doZoom;

	// The movement amount when zooming.
	public float zoomStep = 30f;
	public float zoomSpeed = 5f;
	private float heightWanted;
	private float distanceWanted;

	// Result vectors.
	private Vector3 zoomResult;
	private Quaternion rotationResult;
	private Vector3 targetAdjustedPosition;

	void Start() {
		heightWanted = height;
		distanceWanted = distance;

		zoomResult = new Vector3(0f, height, -distance);
	}

	void LateUpdate() {
	/*
		if (doZoom) {
			float mouseInput = Input.GetAxis("Mouse ScrollWheel");
			heightWanted -= zoomStep * mouseInput;
			distanceWanted -= zoomStep * mouseInput;
			
			heightWanted = Mathf.Clamp(heightWanted, min, max);
			distanceWanted = Mathf.Clamp(distanceWanted, min, max);

			height = Mathf.Lerp(height, heightWanted, Time.deltaTime * zoomSpeed);
			distance = Mathf.Lerp(distance, distanceWanted, Time.deltaTime * zoomSpeed);

			zoomResult = new Vector3(0f, height, -distance);
		}
	

		if (doRotate) {
			float currentRotationAngleX = transform.eulerAngles.x;
			float wantedRotationAngleX = Input.mousePosition.x/2;

			currentRotationAngleX = Mathf.LerpAngle(currentRotationAngleX, wantedRotationAngleX, rotateSpeed * Time.deltaTime);

			rotationResult = Quaternion.Euler(1, currentRotationAngleX, 0);

		}


		targetAdjustedPosition = rotationResult * zoomResult;

		transform.position = target.position + targetAdjustedPosition;
		*/
		//transform.LookAt(target);
	}
}