using UnityEngine;
using System.Collections;

public class Rotate_Object_basic : MonoBehaviour {

	public float angle;
	public float current_angle;
	public float diff_angle;
	public float prev_angle;
	public bool first_press = true;
	public bool change =false;
	// Use this for initialization
	void Start () {
		current_angle = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (1)) {

			Vector3 mouse_pos = Input.mousePosition;
			Vector3 player_pos = Camera.main.WorldToScreenPoint (this.transform.position);
			
			mouse_pos.x = mouse_pos.x - player_pos.x;
			mouse_pos.y = mouse_pos.y - player_pos.y;

			if(first_press == true){
				first_press = false;
				prev_angle= Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;
			}

			current_angle= Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;
			//diff_angle = current_angle - angle;

			//this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, diff_angle));




			//change = true;
		//	Debug.Log("diff angle " + diff_angle);
			diff_angle = current_angle - prev_angle + current_angle;

			Debug.Log("current angle " + current_angle);
			Debug.Log("prerv angle " + prev_angle);
			Debug.Log("diff angle " + diff_angle);
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, diff_angle));


		} else if (!Input.GetMouseButton (1) && !Input.GetMouseButtonDown (1)) {
			first_press = true;
			prev_angle = current_angle;
		//	Debug.Log("not pressed");
			/*Vector3 mouse_pos = Input.mousePosition;
			Vector3 player_pos = Camera.main.WorldToScreenPoint (this.transform.position);
			
			mouse_pos.x = mouse_pos.x - player_pos.x;
			mouse_pos.y = mouse_pos.y - player_pos.y;
			
			 angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;*/

			//change = false;
		}


	}
}
