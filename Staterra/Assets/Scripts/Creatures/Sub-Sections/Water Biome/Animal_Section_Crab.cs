using UnityEngine;
using System.Collections;
using System;

public class Animal_Section_Crab : Animal_parents {

		public Animal_Section_Crab(){

		base.power=10f ;
		base.defence=162f;
		base.command_pnts = 5;
		base.repro_ratio = 2;
		base.feed_ratio = 1;
		base.death_limit = 5;
		base.counter.Add (0);
		for (int i =0; i<4; i++)
			base.death.Add (0);
	
	}

	public void Death_Cycle(int blank){
		
		
		int lastindex = 0;
		
		for (int i =0; i< death[4]; i++) {
			
			lastindex = alive.Count - 1;
			GameObject.Destroy (alive [lastindex]);
			alive.RemoveAt (lastindex);
		}
		
		pop = pop  - death[4];
		
		
		for (int i =0; i<2; i++) {
			if (i == 0 && counter [0] >= death [4]) {
				counter [i] = counter [i] - death [4];
				break;
			} else if (i != 0) {
				
				death [4] = death [4] - counter [i - 1];
				
				if (death [4] == 0) {
					counter [i - 1] = 0;
					
					break;
					
					
				} else if (death [4] > 0) {
					counter [i - 1] = 0;
					
				} else if (death [4] < 0) {
					counter [i - 1] = death [4] * -1;
					death [4] = 0;
				}
			}
		}
		
		
		shift_Values_death(4);
		
		
		Debug.Log ("pop after death " + pop);
		
	}

	public void Feeding_Cycle(ref Animal_Section_SeaUrchin food){
		
		
		int pops = pop;
		int lastindex = 0;
		int food_counter =   pops;
	
		if (food.pop >= pops ) {
			
			//normal eating (no loss from creature)
			for (int i =0; i<pops; i++) {
				
				lastindex = food.alive.Count - 1;
				if(lastindex>0){
					GameObject.Destroy (food.alive [lastindex]);
					food.alive.RemoveAt (lastindex);
				}else if (lastindex ==0){
				
					GameObject.Destroy (food.alive [lastindex]);
					food.alive[lastindex] = null;
				}
			}
			
			food.pop = food.pop - pops;
			food.counter[0] = food.counter[0] - pops;

			food.reduce_Death(pop,death_limit);
			food.reduce_Count(pop,repro_ratio);
	/*		for (int i =4; i>=0;i--){
				
				food_counter = food_counter - food.death[i] ;
				
				if(food_counter ==0){
					food.death[i] = 0;
					break;
					
				} else	if(food_counter <0){
					food.death[i] = food_counter *-1;
					break;
				}
				
				if(food.death[i] <0){
					food.death[i] =	food.death[i] *-1;
				}
				
			}*/
			
			
		} if ( food.pop < pops && food.pop >0) {
			Debug.Log("feed with few sources");
			
			//	copepod_class.pop = food.pop - pops;
			
			for (int i =0; i<=pops-food.pop; i++) {
				lastindex = alive.Count - 1;
				
				if(alive.Count >0){

					if(lastindex>0){
						GameObject.Destroy (alive [lastindex]);
						alive.RemoveAt (lastindex);
					}else if (lastindex ==0){
						
						GameObject.Destroy (alive [lastindex]);
						alive[lastindex] = null;
					}
				}
				
				
			/*	if(food.alive.Count >0){
					GameObject.Destroy (food.alive [0]);
					food.alive.RemoveAt (0);
					
				}*/
				
			}

			while (food.alive.Count >0){
				if(food.alive.Count>1){
					GameObject.Destroy (food.alive [0]);
					food.alive.RemoveAt (0);
				}else if (food.alive.Count==1){
					GameObject.Destroy (alive [lastindex]);
					alive[lastindex] = null;
				}
				
			}

			pop = food.pop;
			counter[0] = pop;
			counter[1] = 0;
			counter[2] = 0;
			
			
			Debug.Log("pops " + pops);
			Debug.Log("food "+food);
			reduce_Death(pops-food.pop,death_limit );
			reduce_Count(pops-food.pop,repro_ratio );
			
			food.pop = 0;
			food.zeroCounter();
			
			food.zeroDeath();
			//food_counter = food.pop - pops;
			
			

			
		}else if(food.pop <=0 && pops>0){
			Debug.Log("zero");
			
			for (int i =0; i<pops; i++) {
				
				lastindex = alive.Count - 1;
				if(lastindex>0){
					GameObject.Destroy (alive [lastindex]);
					alive.RemoveAt (lastindex);
				}else if (lastindex ==0){
					
					//lastindex = alive.Count - 1;
					GameObject.Destroy (alive [lastindex]);
					alive[lastindex] = null;
				}
			}
			
			zeroDeath();
			zeroCounter();
			pop = 0;
		}
		
		Debug.Log ("pop after eating " + pop);
	}
	
	
	public void Repro_Cycle(Vector3 pos, Vector3 rot){
		
		int [] prev_count = new int[2];
		
		//	Debug.Log ("before for");
		for (int i =0; i<counter[1]; i++) {
		
			GameObject new_creat = GameObject.Instantiate (creature_object, pos, Quaternion.Euler( rot))as GameObject;
			alive.Add (new_creat);
			
		}
		
		death[0] = death[0] + counter[1];
		pop = pop +	counter[1];
		
		prev_count[0] = counter[0];
		prev_count [1] = counter [1];
		
		
		counter[0] = prev_count[1] * 2;
		counter [1] = prev_count [0];
		
		//	death[0] = prev_count[1];
		Debug.Log ("pop after repro " + pop);
	}

}