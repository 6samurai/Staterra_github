using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	iTween.RotateFrom(gameObject, iTween.Hash("y", 90.0f, "time", 2.0f, "easetype", iTween.EaseType.easeInExpo));
	//	iTween.RotateBy(gameObject, iTween.Hash("x", 0.5f, "delay", 4.4f));

	//	iTween.RotateFrom(gameObject, iTween.Hash("y", 90.0f, "time", 0.1f, "easetype", iTween.EaseType.easeInExpo));
	//	iTween.MoveFrom(gameObject, iTween.Hash("y", 3.5f, "time", 2.0f, "easetype", iTween.EaseType.easeInExpo));
	//	iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("y", 0.3f, "time", 0.8f, "delay", 2.0f));
	//	iTween.ColorTo(gameObject, iTween.Hash("r", 1.0f, "g", 0.5f, "b", 0.4f, "delay", 1.5f, "time", 0.3f));
	//	iTween.ScaleTo(gameObject, iTween.Hash("y", 1.75f, "delay", 2.8f, "time", 2.0f));
		iTween.RotateBy(gameObject, iTween.Hash("y", 0.5f, "delay", 0.1f));
	//	transform.LookAt(iTween.PointOnPath(path,percentage+.05f));
	//	iTween.MoveTo(gameObject, iTween.Hash("y", 1.5f, "delay", 5.8f));
	//	iTween.MoveTo(gameObject, iTween.Hash("y", 0.5f, "delay", 7.0f, "easetype", iTween.EaseType.easeInExpo));
	//	iTween.ScaleTo(gameObject, iTween.Hash("y", 1.0f, "delay", 7.0f));
	//	iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("y", 0.3f, "time", 0.8f, "delay", 8.0f));
	//	iTween.ColorTo(gameObject, iTween.Hash("r", 0.165f, "g", 0.498f, "b", 0.729f, "delay", 8.5f, "time", 0.5f));
		
	//	iTween.CameraFadeAdd();
	//	iTween.CameraFadeTo(iTween.Hash("amount", 1.0f, "time", 2.0f, "delay", 10.0f));
	}
	
	// Update is called once per frame

}
