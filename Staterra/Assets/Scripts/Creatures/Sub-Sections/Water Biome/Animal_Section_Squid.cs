using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Squid : Animal_parents {
	

	public int [] food_chain = new int[3];
/*	public int count_stage1 = 0;
	public int count_stage2 = 0;
	public int count_stage3 = 0;
*/
	
	//public int count_pop = 0;

	public Animal_Section_Squid(){



		base.power=85f;
		base.defence=150f;
		base.command_pnts = 17;
		base.repro_ratio = 5;
		base.feed_ratio = 1;
		base.death_limit = 11;

		/*count_stage1 = 0;
		count_stage2 = 0;*/
	//	count_pop = 0;
	}

	public int Feed_items(){
		
		//int feed = 0;
		
		GameObject crab =  GameObject.Find ("Crab_Counter");
		GameObject bogue = GameObject.Find ("Bogue_Counter");
		GameObject octopus = GameObject.Find ("Octopus_Counter");

		food_chain [0] = crab.GetComponent<Animal_Section_Crab>().pop;
		food_chain [1] = bogue.GetComponent<Animal_Section_Bogue>().pop;
		food_chain [2] = octopus.GetComponent<Animal_Section_Octopus>().pop;
		
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