using UnityEngine;
using System.Collections;
using System;



public class Animal_Type_Shell : Animal_parents {


	public float Modify_def_div_10() {
	

		return base.defence /10f;

	}

}