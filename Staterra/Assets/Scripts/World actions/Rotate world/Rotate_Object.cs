using UnityEngine;
using System.Collections;

public class Rotate_Object : MonoBehaviour {

	public float angle;
	public float current_angle;
	public float diff_angle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (1)) {
			Vector3 mouse_pos = Input.mousePosition;
			Vector3 player_pos = Camera.main.WorldToScreenPoint (this.transform.position);
		
			mouse_pos.x = mouse_pos.x - player_pos.x;
			mouse_pos.y = mouse_pos.y - player_pos.y;
		
			current_angle= Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;
			diff_angle = current_angle - angle;

			//this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, diff_angle));

			Debug.Log("current angle " + current_angle);
		//	Debug.Log("diff angle " + diff_angle);
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, current_angle));
		} else if (!Input.GetMouseButton (1)) {
		//	Debug.Log("not pressed");
			Vector3 mouse_pos = Input.mousePosition;
			Vector3 player_pos = Camera.main.WorldToScreenPoint (this.transform.position);
			
			mouse_pos.x = mouse_pos.x - player_pos.x;
			mouse_pos.y = mouse_pos.y - player_pos.y;
			
			 angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90f;


		}


	}
}
