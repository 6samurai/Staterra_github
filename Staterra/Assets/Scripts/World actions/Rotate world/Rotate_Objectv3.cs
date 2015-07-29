using UnityEngine;
using System.Collections;

public class Rotate_Objectv3 : MonoBehaviour {

	public float angle;
	public float current_angle;
	public float diff_angle;
	public float prev_angle;
	public float stored_angle;

	public bool first_press = true;
	public bool change =false;
	public bool first_iter = true;
	public int count = 0;
	public int count_2 = 0;

	private Vector3 mouse_pos;
	private Vector3 player_pos;
	// Use this for initialization
	void Start () {
		current_angle = 0;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButton (1)) {
			count++;
			Debug.Log("count"  + count);
		}

		if (Input.GetMouseButtonDown (1)) {
			count_2++;
			Debug.Log("count_2"  + count_2);

		}

		if (Input.GetMouseButton (1)) {

			if(first_iter==true){
				first_iter= false;

			}else{
			 mouse_pos = Input.mousePosition;
			 player_pos = Camera.main.WorldToScreenPoint (this.transform.position);
			
			mouse_pos.x = mouse_pos.x - player_pos.x;
			mouse_pos.y = mouse_pos.y - player_pos.y;

		/*	if(first_press == true){
				first_press = false;
				prev_angle= Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;
			}*/

			current_angle= Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;
			//diff_angle = current_angle - angle;

			//this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, diff_angle));




			//change = true;
		//	Debug.Log("diff angle " + diff_angle);
				diff_angle = current_angle - prev_angle + stored_angle;

			Debug.Log("current angle " + current_angle);
			Debug.Log("prerv angle " + prev_angle);
			Debug.Log("diff angle " + diff_angle);
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, diff_angle));
			}

		} 
			if (!Input.GetMouseButton (1)) {
			stored_angle = diff_angle;
			first_press = true;
			prev_angle = current_angle;
			//	Debug.Log("not pressed");
			//if(first_iter ==true){
			current_angle = 0;
				 mouse_pos = Input.mousePosition;
				 player_pos = Camera.main.WorldToScreenPoint (this.transform.position);
				
				mouse_pos.x = mouse_pos.x - player_pos.x;
				mouse_pos.y = mouse_pos.y - player_pos.y;
				
				prev_angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;

		//	}
		

		}
	}
}
