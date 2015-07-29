using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Shrimp : Animal_parents {
	
//	public int []  counter = new int[3];
//	public int [] death = new int[7];

	public int count_stage1 = 0;
	public int count_stage2 = 0;
	public int count_stage3 = 0;

	
	//public int count_pop = 0;

	public Animal_Section_Shrimp(){



		base.power=30 ;
		base.defence=40f;
		base.command_pnts = 4;
		base.repro_ratio = 2;
		base.feed_ratio = 1;
		base.death_limit = 5;


	//	count_pop = 0;
	}

/*	public void zeroDeath(){

		for (int i =0; i <7; i ++) {
			
			death [i] = 0;
			
		}

	}

	public void zeroCounter(){
		
		for (int i =0; i <3; i ++) {
			
			counter [i] = 0;
			
		}
		
	}

	public void reduce_Death(int limit){
		//Time.timeScale = 0;
		Debug.Log ("limit " + limit);
		int temp = 0;

		for (int i = 0; i<7; i++) {
			temp = death[i];
			if(death[i] >= limit){
				death[i] = death [i] - limit;
				limit = limit - temp; 
			}

			if(death[i]<0){

				limit = limit + death[i] *-1;
				death[i] = 0;
			}


			if(limit ==0)
				break;

		}


	}*/

}