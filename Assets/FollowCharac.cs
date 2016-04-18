using UnityEngine;
using System.Collections;

public class FollowCharac : MonoBehaviour {

	public GameObject Charac;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Charac.transform.position.x, Charac.transform.position.y, Charac.transform.position.z);
	}
}
