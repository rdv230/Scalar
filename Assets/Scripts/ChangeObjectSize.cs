using UnityEngine;
using System.Collections;

public class ChangeObjectSize : MonoBehaviour {

	public bool staticSize;
	public Transform playerTrans;
	Vector3 distanceFromPlayer;
	float growthRate = 10;
	Vector3 lastDistance;
	SpriteRenderer myRenderer;
	public Sprite nonSelected, selected;

	public bool smaller;


	// Use this for initialization
	void Start () {

		if(DistanceCheck.played < 5){
			growthRate = Random.Range(4, 8);
		} else{
			growthRate = Random.Range (DistanceCheck.played - 4,DistanceCheck.played);
		}

		staticSize = true;
		myRenderer = GetComponent<SpriteRenderer>();


		int result; 
		int.TryParse(gameObject.name, out result);
		if(result % 2  == 0){
			//number is even
			smaller = true;
		}
		else if(result % 2 != 0){
			//number is odd
			smaller = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		distanceFromPlayer = playerTrans.position - transform.position;


		if(!staticSize){

			if(!smaller){
			transform.localScale = transform.localScale + new Vector3 (Time.deltaTime/growthRate, Time.deltaTime/growthRate, Time.deltaTime/growthRate);
			} else{
				transform.localScale = transform.localScale - new Vector3 (Time.deltaTime/growthRate, Time.deltaTime/growthRate, Time.deltaTime/growthRate);
			}

		}
	}	

	

	public void StaticSize(){
		staticSize = true;
		myRenderer.sprite = nonSelected;
	}

	public void ChangeSize(){
		staticSize = false;
		myRenderer.sprite = selected;
	}

	IEnumerator Grow(){
		transform.localScale = transform.localScale * growthRate;
		yield return new WaitForSeconds(.05f);
	}
}
