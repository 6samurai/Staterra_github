using UnityEngine;
using System.Collections;

public class Move_Camera : MonoBehaviour {
	public	float cameraDistanceMax = 20f;
	public float cameraDistanceMin = 5f;
	public float cameraDistance = 10f;
	public float scrollSpeed = 0.5f;
	public GameObject upper_limit;
	public GameObject lower_limit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	
	void Update()
	{
		/*if(Input.GetAxisRaw("Mouse ScrollWheel")!=0){
		cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
		cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
		transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z*cameraDistance);
		// set camera position*/

		if((Input.GetAxis("Mouse ScrollWheel") < 0  || Input.GetKey(KeyCode.UpArrow) && lower_limit.transform.position.z< transform.position.z )
		   )
		{
			transform.Translate(0, 0, -1, Space.World);
			transform.position = new Vector3 (transform.position.x ,transform.position.y, transform.position.z) ;  
//			Debug.Log("< 0");
		}                
		if((Input.GetAxis("Mouse ScrollWheel") > 0|| Input.GetKey(KeyCode.DownArrow)  &&  upper_limit.transform.position.z> transform.position.z)
		   ){
		//	Debug.Log("> 0");
			transform.Translate(0,0,1, Space.World);
			transform.position = new Vector3 (transform.position.x ,transform.position.y, transform.position.z);
		}




	}
}
