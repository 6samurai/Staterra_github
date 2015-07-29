using UnityEngine;
using System.Collections;

using System;



public class Animal_Section_Copepod : Animal_parents {

	public int count_stage1 = 0;
	public int count_stage2 = 0;

//	public int []  counter = new int[2];
//	public int [] death = new int[5];
	//public GameObject[] alive;
	//public int count_pop = 0;


	public Animal_Section_Copepod(){



		base.power=0 ;
		base.defence=30f;
		base.command_pnts = 1;
		base.repro_ratio = 1;
		base.feed_ratio = 1;
		//base.pop = 0;
		base.death_limit = 4;

		//base.death_ratio = 5;
		//count_pop = 0;
	}

	/*void Update(){

	 alive  = GameObject.FindGameObjectsWithTag("Copepod");


	}*/

/*	public void zeroDeath(){

		for (int i =0; i <5; i ++) {

			death [i] = 0;

		}

	}


	public void zeroCounter(){
		
		for (int i =0; i <2; i ++) {
			
			counter [i] = 0;
			
		}
		
	}*/
	
}