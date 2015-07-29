using UnityEngine;
using System.Collections;
using System;

public class Animal_properties : MonoBehaviour {

	public float reproductive_rate =0;
	public float power =0;
	public float defence =0;
	public float feed_no =0;
	public float feeding_rate = 0;

	// Use this for initialization
	void Start () {
		feeding_rate = power / defence;
		SimpleStruct ss = new SimpleStruct();
		ss.X = 500;
		ss.DisplayX();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	struct SimpleStruct
	{
		private int xval;
		public int X
		{
			get {
				return xval;
			}
			set 	{
				if (value < 100)
					xval = value;
			}
		}
		public void DisplayX()
		{
			Debug.Log ("The stored value is: {0}"+ xval);
			//Console.WriteLine();
		}
	}

}
