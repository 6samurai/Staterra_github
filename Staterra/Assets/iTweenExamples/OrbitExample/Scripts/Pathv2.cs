using UnityEngine;
using System.Collections;

public class Pathv2 : MonoBehaviour{
	public Transform[] path;
	
	void OnDrawGizmos(){
		iTween.DrawPath(path);	
	}
	
	void Start(){
		iTween.MoveTo(gameObject,iTween.Hash("path",path,"time",2,"orienttopath",true,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.loop,"movetopath",false));
	
	}

	void LateUpdate () {
	//	iTween.LookUpdate(gameObject,path,2);
	}
}

