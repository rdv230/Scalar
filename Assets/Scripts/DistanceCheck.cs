using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DistanceCheck : MonoBehaviour {

	//GameObject lastHit;
	public int MannequinsSelected;
	public List<GameObject> Mannequins;
	public static int played;
	public AudioSource myAudio;
	public AudioClip clip;
	private static int PASSWORD;

	// Use this for initialization
	void Start () {
		if(played < 40){
		for(int i = played; i < 41; i++){
			GameObject obj = GameObject.Find(i.ToString());
			Mannequins.Add(obj);
		}
		if(played > 0){
				for(int i = 41 - played; i <=40; i++){
					GameObject obj = GameObject.Find (i.ToString());
					obj.SetActive(false);
				}
		}

		}else{
		}

	}


	
	// Update is called once per frame
	void Update () {
//
//		if(Input.GetKeyDown(KeyCode.A)){
//			MannequinsSelected++;
//			Debug.Log ("MannequinsSelected= " + MannequinsSelected); 
//		}

		if(Input.GetKeyDown(KeyCode.Alpha1)){
			PASSWORD++;
		}

		if(PASSWORD >= 10){
			if(Input.GetKeyDown(KeyCode.Equals)){
				played+=4;
				Application.LoadLevel(0);
			}
		}
	
		//if you're looking at something, do not change the size of the object you're looking at

		RaycastHit hit;

		Ray fwd = new Ray(transform.position, transform.forward);

		Debug.DrawRay(transform.position, transform.forward, Color.magenta);

		Camera.main.fieldOfView = 60 + MannequinsSelected *(played/4);


		if(Physics.SphereCast(fwd, 3, out hit, Mathf.Infinity)){
			//Debug.Log(hit.collider.gameObject.name.ToString());
			if(hit.collider.gameObject.GetComponent<ChangeObjectSize>() != null){
		//		Debug.Log ("Dammit.");
				if( hit.collider.gameObject.GetComponent<ChangeObjectSize>().staticSize == true){
					MannequinsSelected++;
					myAudio.PlayOneShot(clip);
					hit.collider.gameObject.GetComponent<ChangeObjectSize>().ChangeSize();
				}
			}
		}
//		else {
//			if(lastHit != hit.collider.gameObject){
//				lastHit.GetComponent<ChangeObjectSize>().StaticSize();
//			}
		//}

		if(MannequinsSelected >= Mannequins.Count-1){
			played += 4;
			Application.LoadLevel(0);
		}


	}
}
