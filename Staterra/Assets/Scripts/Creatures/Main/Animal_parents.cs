using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Animal_parents {

	//public class Animals 
	//{

		public float power ;
		public float defence;
		public int command_pnts;
		public int repro_ratio;
		public int feed_ratio;
		public int pop;
		public List <GameObject> alive = new List<GameObject>();
	    public int death_limit;

		public List<int> counter = new List<int>();
		public List<int>  death = new List<int>();
		public List <GameObject> creatures = new List<GameObject>();
		public GameObject creature_object;
	
//	public int [] food_chain = new int[8];
		//public int [] death_ratio;
		//This is the first constructor for the Fruit class
		//and is not inherited by any derived classes.
	public Animal_parents()
		{

			power=0 ;
			defence=0;
			command_pnts = 0;
			repro_ratio = 0;
			feed_ratio = 0;
			pop = 0;
		death_limit = 0;
	//	alive.Add (null);

		counter.Add (0);
		death.Add (0);

		//for (int i=0; i<15; i++) {

		/*creatures.Add((Resources.Load("Copepod_object")) as GameObject);
		creatures.Add((Resources.Load("SeaUrchin_object")) as GameObject);
		creatures.Add((Resources.Load("Shrimp_object")) as GameObject);
		creatures.Add((Resources.Load("Bogue_object")) as GameObject);
		creatures.Add((Resources.Load("Crab_object"))as GameObject);
		creatures.Add((Resources.Load("Jellyfish_object"))as GameObject);*/
		//}
		//	death_ratio[0] = 0;


		}
		
		//This is the second constructor for the Fruit class
		//and is not inherited by any derived classes.
	public Animal_parents(int cp, float pwr, float dfc, int repr, int feed, int pops, int dead)
		{
		power=pwr ;
		defence=dfc;
		command_pnts = cp;
		repro_ratio = repr;
		feed_ratio = feed;
		pop = pops;
		death_limit = dead;
		//death = dead;
		//death_ratio[pos] = death;

		}


	public void zeroDeath(){
		Debug.Log ("death.Count" + death.Count);
		for (int i =0; i <death.Count; i ++) {
			
			death[i] = 0;
		}
	
		
	}


	public void zeroCounter(){
		Debug.Log ("counter.Count" + counter.Count);
		for (int i =0; i <counter.Count; i ++) {
			
			counter[i] = 0;
		}

	}

	public int Death_Cycle(){

		return 0;
		
	}
	
	public void Feed_Cycle(){
		
		
	}
	
	public void Repro_Cycle(){
		
		
	}
	public void reduce_Death(int limit, int iter){
		//Time.timeScale = 0;
		Debug.Log ("limit " + limit);

		Debug.Log ("iter " + iter);
		int temp = 0;

		if (limit == 0) {
			zeroDeath();

		}else
		for (int i = iter-1; i>=0; i--) {

			temp = death[i];

			death[i] = death [i] - limit;

			if(limit > 0){

				limit = limit - temp; 
			} 

			if (limit <0){
				death[i] = death[i] + limit*-1;
				limit =0;


			}
			
			if(death[i]<0){
				
				limit = limit + death[i] *-1;
				death[i] = 0;
			}
			
			
			if(limit ==0)
				break;
			
		}
		
		Debug.Log ("end of reduce death");
	}


	public void reduce_Count(int limit, int iter){
		//Time.timeScale = 0;
		Debug.Log ("limit " + limit);
		Debug.Log ("iter " + iter);
		int temp = 0;
		
		for (int i = 0; i<iter; i++) {
			temp = counter[i];

			counter[i] = counter [i] - limit;
			if(limit >0){
			
				limit = limit - temp; 
			}

			if(limit <0){
				counter[i] = counter[i] + limit*-1;
				limit = 0;
			}
			
			if(death[i]<0){
				
				limit = limit + counter[i] *-1;
				counter[i] = 0;
			}
			
			
			if(limit ==0)
				break;
			
		}
		
		
	}


public	void shift_Values_death(int iter){
		// int [] death_temp = new int[17];
		//int death_temp = death [0];
		//int death_temp2 = death [1];
		for (int i =iter; i >0; i--) {
			death[i] = death[i-1];

			//death_temp = death_temp2;
			//death_temp2
			//Debug.Log("i " + i + "death temp " + death_temp[i]);
			//
			//Debug.Log("i " + i + "death " + death[i]);
		

		}
		death [0] = 0;


	}
}

