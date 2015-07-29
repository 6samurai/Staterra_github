using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Animal_parents:MonoBehaviour {

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

		public int []  counter = new int[4];
		public int [] death = new int[17];


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

	public void zeroDeath(int iter){
		
		for (int i =0; i <iter; i ++) {
			
			death [i] = 0;
			
		}
		
	}


	public void zeroCounter(int iter){
		
		for (int i =0; i <iter; i ++) {
			
			counter [i] = 0;
			
		}
		
	}


	public void reduce_Death(int limit, int iter){
		//Time.timeScale = 0;
		Debug.Log ("limit " + limit);
		int temp = 0;
		
		for (int i = 0; i<iter; i++) {
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
		
		
	}


	public void reduce_Count(int limit, int iter){
		//Time.timeScale = 0;
		Debug.Log ("limit " + limit);
		int temp = 0;
		
		for (int i = 0; i<iter; i++) {
			temp = counter[i];
			if(counter[i] >= limit){
				counter[i] = counter [i] - limit;
				limit = limit - temp; 
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

