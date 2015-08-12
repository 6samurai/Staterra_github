using UnityEngine;
using System.Collections;

public class PathExamplev2 : MonoBehaviour{
	public Transform[] path;
	public bool change = false;
	public GameObject [] targets;
	public GameObject  target;

	public float speed = 10.0F;
	private float startTime;
	private float journeyLength;
	private float distCovered =0;
	private float fracJourney =0;
	public Vector3 prev_pos;
	public bool trans = false;
	public Vector3 target_pos;


	void Start(){
		tween();

	//	StartCoroutine (tween ());
	}
	
	void Update(){
		//transform.rotation = Quaternion.Euler (transform.rotation.x, Mathf.Clamp (transform.rotation.y, 0, 90), transform.rotation.z);
	/*	if (this.transform.rotation.y >=270) {
			transform.Rotate(transform.rotation.x, 90, transform.rotation.z);
			Debug.Log("in loop");
		}*/
		if (Input.GetKeyUp (KeyCode.Space) && target != null) {

			if (change == false){
				change = true;

				prev_pos = transform.position;
				iTween.Pause (gameObject);
				startTime = Time.time;
				target_pos = target.transform.position;
				journeyLength = Vector3.Distance(transform.position, target_pos);

			}else if(change == true){
				change = false;
				trans = true; 
				startTime = Time.time;

				target_pos  = prev_pos;
				journeyLength = Vector3.Distance(transform.position, target_pos);


			}
			Debug.Log("change "+ change);
			Debug.Log("trans "+ trans);
		}


		if (change == false) {
			if(trans == true){
				distCovered = (Time.time - startTime) * speed;
				fracJourney = distCovered / journeyLength;

				transform.position = Vector3.Lerp(transform.position, target_pos, fracJourney);
				transform.LookAt(target_pos);
			}

			if( target_pos == transform.position && trans == true){		
				trans = false;
				iTween.Resume (gameObject);

			}
		} else if(change == true){
			distCovered = (Time.time - startTime) * speed;
			 fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(transform.position, target_pos, fracJourney);
			transform.LookAt(target_pos);
			
		}
		
		
	}


	void OnDrawGizmos(){
		iTween.DrawPath(path);
	}
	
	void tween(){

	//	while (true) {
			//	iTween.MoveTo(gameObject,iTween.Hash("path",path,"time",15,"orienttopath",true,"looktime",.2,"looptype",iTween.LoopType.loop,"movetopath",false));	
			iTween.MoveTo (gameObject, iTween.Hash ("path", path, "time", 15, "orienttopath", false, "looktime", 0.2, "easetype", "linear", "looptype", iTween.LoopType.loop, "movetopath", false));	
		//	yield return new WaitForSeconds (1f);
			Debug.Log ("hello after 1 second");


		//	reset();
			//	iTween.MoveTo(gameObject,iTween.Hash("path",path,"time",2,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.loop,"movetopath",false));
	//	}

	}

	void chase(){
		iTween.Pause (gameObject);


	}
	void reset(){
	
		transform.position=new Vector3(0,0,0);
		transform.eulerAngles=new Vector3(0,0,0);
	}

public	void setTarget(string creature1, string creature2 = "", string creature3 = "", string creature4 = "", string creature5 = "" ){






	}



}

