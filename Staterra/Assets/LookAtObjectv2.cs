using UnityEngine;
using System.Collections;

public class LookAtObjectv2 : MonoBehaviour {
	public GameObject [] axes;
	public float distance = 1000;
	public float temp_distance = 0;
	public int index =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i =0; i <4; i++) {
		//	Debug.Log("temp distance " + temp_distance);
			temp_distance = Vector3.Distance(transform.position,axes[i].transform.position);
			if(distance > temp_distance){

				index = i;
				distance = temp_distance;
			}

		}

		Vector3 relativePos = axes[index].transform.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		transform.rotation = rotation;

		

	//	Debug.Log ("index  " + index);
	//	Debug.Log ("object " + axes [index]);
		//transform.LookAt(new Vector3(axes[index].transform.position.x,transform.rotation.y, axes[index].transform.position.z));
	//	transform.LookAt (axes [index].transform);
		distance = 10000;
	}


}
