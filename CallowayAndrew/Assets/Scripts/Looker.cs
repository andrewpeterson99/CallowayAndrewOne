using UnityEngine;
using System.Collections;

public class Looker : MonoBehaviour {

	private Transform spawner;
	public Transform player;

	// Use this for initialization
	void Start () {
		spawner = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		spawner.LookAt (player.position);
	}
}
