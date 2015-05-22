using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Water") {
			Destroy(player.gameObject);
			//Application.LoadLevel(Application.loadedLevel);
		}
	}
}
