using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour{
	public Transform[] path;
	
	void OnDrawGizmos(){
		iTween.DrawPath(path);	
	}
	
	void Start(){
		iTween.MoveTo(gameObject,iTween.Hash("path",path,"time",2,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.loop,"movetopath",false));
	}
}

