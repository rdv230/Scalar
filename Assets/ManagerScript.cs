using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour {

	AudioSource myAudioSource;

	// Use this for initialization
	void Start () {

		myAudioSource = GetComponent<AudioSource>();
		if(DistanceCheck.played > 0){
		myAudioSource.volume = 1f - ((DistanceCheck.played*2)/100f);
//			Debug.Log (1f - ((DistanceCheck.played*2)/100f));
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
