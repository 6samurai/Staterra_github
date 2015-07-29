using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Jellyfish : Animal_parents {
	
//	public int []  counter = new int[4];
//	public int [] death = new int[9];
	public int [] food_chain = new int[3];

	public int count_stage1 = 0;
	public int count_stage2 = 0;
	public int count_stage3 = 0;

	
	//public int count_pop = 0;

	public Animal_Section_Jellyfish(){



		base.power=44f ;
		base.defence=102f;
		base.command_pnts = 7;
		base.repro_ratio = 3;
		base.feed_ratio = 1;
		base.death_limit = 7;
	//	count_stage1 = 0;
	//	count_stage2 = 0;
	//	count_pop = 0;
	}

	public int Feed_items(){

		//int feed = 0;

		GameObject copepod =  GameObject.Find ("Copepod_Counter");
		GameObject	bogue = GameObject.Find ("Bogue_Counter");
		GameObject	shrimp = GameObject.Find ("Shrimp_Counter");
	

		food_chain [0] = shrimp.GetComponent<Animal_Section_Shrimp>().pop;
		food_chain [1] = copepod.GetComponent<Animal_Section_Copepod>().pop;
		food_chain [2] = bogue.GetComponent<Animal_Section_Bogue>().pop;

		if ( food_chain [0] + food_chain [1] + food_chain [2] ==0)
			return 7; // this value represents the case where there is no populations that can be eaten

		else if (pop <= food_chain [0])
			return 0;
		else if (pop <= food_chain [0] + food_chain [1])
			return 1;
		else if (pop <= food_chain [0] + food_chain [1] + food_chain [2])
			return 2;
		else if (pop > food_chain [0] + food_chain [1] + food_chain [2] && food_chain [0] + food_chain [1] + food_chain [2] != 0)
			return 3;


		return 10;
	}

/*	public void zeroDeath(){
		
		for (int i =0; i <9; i ++) {
			
			death [i] = 0;
			
		}
		
	}
	
	public void zeroCounter(){
		
		for (int i =0; i <4; i ++) {
			
			counter [i] = 0;
			
		}
		
	}*/
	
	/*public void reduce_Death(int limit){
		//Time.timeScale = 0;
		Debug.Log ("limit " + limit);
		int temp = 0;
		
		for (int i = 0; i<9; i++) {
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