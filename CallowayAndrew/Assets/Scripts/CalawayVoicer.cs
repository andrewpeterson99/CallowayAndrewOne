using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class CalawayVoicer : MonoBehaviour {

	public AudioMixerSnapshot slowed;
	public AudioMixerSnapshot norm;
	private AudioSource voice;
	bool temp = false;
	public float switcher;

	// Use this for initialization
	void Start () {
		voice = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (voice.time >= 6.85f) {
			slowed.TransitionTo (0.1f);
		}
		if (voice.time >= 8f) {
			temp = true;
		}
		if (temp) {
			switcher += 0.01f;
		}
		if (switcher >= 2f) {
			norm.TransitionTo(0.1f);
		}
	
	}
}
