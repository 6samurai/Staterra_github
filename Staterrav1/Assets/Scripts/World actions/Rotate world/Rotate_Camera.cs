using UnityEngine;
using System.Collections;

public class Rotate_Camera : MonoBehaviour {
	//This version allows for obiting around object
	// Use this for initialization
//	public GameObject pivot;
	public Transform target;
	void Start () {
	
	}
	
	// Update is called once per frame

	
	
	void Update () 
	{

		//modify to only raotate around one axis
		Vector3 relativePos = (target.position + new Vector3(0, 0,2f)) - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		
		Quaternion current = transform.localRotation;
		
		transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
		transform.Translate(0, 0, 3 * Time.deltaTime);
	}
}
