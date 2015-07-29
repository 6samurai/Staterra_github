using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Bogue : Animal_parents {
	

	public int [] food_chain = new int[2];
	
	//public int count_pop = 0;

	public Animal_Section_Bogue(){


		base.power=30f ;
		base.defence=87f;
		base.command_pnts = 2;
		base.repro_ratio = 3;
		base.feed_ratio = 1;
		base.death_limit = 7;
	//	count_pop = 0;
	}

	public int Feed_items(){
		
		//int feed = 0;
		
		GameObject copepod =  GameObject.Find ("Copepod_Counter");
		GameObject	shrimp = GameObject.Find ("Shrimp_Counter");
		
		food_chain [0] = copepod.GetComponent<Animal_Section_Copepod>().pop;
		food_chain [1] = shrimp.GetComponent<Animal_Section_Shrimp>().pop;
	
			
		if (food_chain [0] + food_chain [1]  == 0)
			return 7; // this value represents the case where there is no populations that can be eaten
		
		else if (pop <= food_chain [0])
			return 0;
		else if (pop <= food_chain [0] + food_chain [1])
			return 1;
		else if (pop > food_chain [0] + food_chain [1]  && food_chain [0] + food_chain [1]  != 0)
			return 2;
		
		
		return 10;
	}

}