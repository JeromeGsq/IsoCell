using UnityEngine;
using System.Collections;

public class RandomLanePrefab : MonoBehaviour {

	public GameObject[] Prefab;

	public int Amout;
	public int Largeur;
	public int Longueur;

	public bool RandomRotate;



	void Start () {
		for(int i=0; i < Amout; i++) {
			GameObject g = Instantiate(Prefab[(Random.Range(0, Prefab.Length - 1))]);
			g.transform.SetParent(transform);

			g.transform.position = new Vector3(Random.Range(-Largeur, Largeur) , 0, Random.Range(-Longueur, Longueur));

			if(RandomRotate) {
				g.transform.eulerAngles = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
			}
		}
	}

}
