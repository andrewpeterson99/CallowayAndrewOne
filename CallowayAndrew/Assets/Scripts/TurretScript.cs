using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	
	public GameObject bullet;
	public GameObject spawnDummy;
	public GameObject playerPos;
	public float shootTimer;
	private Rigidbody bulletRB;
	public float bulletSpeed;
	public AudioClip bulletSFX;
 	public AudioSource turretSounds;
	private bool slower = false;
	
	// Use this for initialization
	void Start () {
		shootTimer = Random.Range (10f, 5f);
		turretSounds = this.gameObject.GetComponent<AudioSource> ();
		StartCoroutine (Shooter ());
	}
	
	// Update is called once per frame
	void Update () {
		if (shootTimer <= 0.5f) {
			shootTimer = Random.Range(10f, 5f);
		}
		if (Input.GetKeyDown (KeyCode.CapsLock)) {
			slower = !slower;
		}
		if (slower == true) {
			turretSounds.pitch = 0.6f;
		}  
		if (slower == false) {
			turretSounds.pitch = 1f;
		}
	}
	void LateUpdate(){
		transform.LookAt (new Vector3(playerPos.transform.position.x, this.transform.position.y, playerPos.transform.position.z));
	}
	void Shoot(){
		turretSounds.PlayOneShot (bulletSFX);
		GameObject bulletInstance = (GameObject) Instantiate (bullet, spawnDummy.transform.position, spawnDummy.transform.rotation);
		bulletInstance.GetComponent<Rigidbody> ().AddForce (bulletInstance.transform.forward * bulletSpeed, ForceMode.VelocityChange);
		Destroy(bulletInstance, 5f);
		
	}
	IEnumerator Shooter(){
		while (true) {
			Shoot ();
			shootTimer -= 0.1f;
			yield return new WaitForSeconds (shootTimer);
		}
	}
}

