using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Shrimp : Animal_parents {
	


	
	//public int count_pop = 0;

	public Animal_Section_Shrimp(){



		base.power=30 ;
		base.defence=40f;
		base.command_pnts = 4;
		base.repro_ratio = 2;
		base.feed_ratio = 1;
		base.death_limit = 5;
		base.counter.Add (0);
		for (int i =0; i<4; i++)
			base.death.Add (0);

	//	count_pop = 0;
	}

	public void Death_Cycle(int blank){
		
		
		int lastindex = 0;
		
		for (int i =0; i< death[4]; i++) {
			
			lastindex = alive.Count - 1;
			GameObject.Destroy (alive [lastindex]);
			alive.RemoveAt (lastindex);
		}
		
		pop = pop  - death[4];
		
		
		for (int i =0; i<3;i++){
			if(i==0 && counter[0]>=death[4]){
				counter[i] = counter[i] - death[4];
				break;
			}else if (i!=0){
				
				death[4] = death[4]-counter[i-1];
				
				if(death[4] ==0){
					counter[i-1] = 0;
					
					break;
					
					
				}else if(death[4] >0){
					counter[i-1] =0;
					
				}
			}
		}
		
		
		shift_Values_death(4);
		
		
		Debug.Log ("pop after death " + pop);
		
	}

	public void Feeding_Cycle(ref Animal_Section_Copepod food){
		
		
		int pops = pop;
		int lastindex = 0;
		int food_counter =   pops;
		int death_counter = 0;
		if (food.pop >= pops ) {

			//normal eating (no loss from creature)
			for (int i =0; i<pops; i++) {
				
				lastindex = food.alive.Count - 1;
				if(lastindex>=0){
					GameObject.Destroy (food.alive [lastindex]);
					food.alive.RemoveAt (lastindex);
				}
			}

			food.pop = food.pop - pops;
			food.counter[0] = food.counter[0] - pops;

			for (int i =4; i>=0;i--){

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
				
			}

			
		} if ( food.pop < pops && food.pop >0) {
			Debug.Log("feed with few sources");
			
		//	copepod_class.pop = food.pop - pops;
			
			for (int i =0; i<pops-food.pop; i++) {
				
				
				if(alive.Count >0){
					lastindex = alive.Count - 1;
					if(lastindex>=0){
						GameObject.Destroy (alive [lastindex]);
						alive.RemoveAt (lastindex);
					}
				}
				
				
				if(food.alive.Count >0){
					GameObject.Destroy (food.alive [0]);
					food.alive.RemoveAt (0);
					
				}
				
			}
			pop = food.pop;
			counter[0] = pop;
			counter[1] = 0;
			counter[2] = 0;
			
			
			Debug.Log("pops " + pops);
			Debug.Log("food "+food);
			reduce_Death(pops-food.pop,death_limit );
			reduce_Count(pops-food.pop,death_limit );

			food.pop = 0;
			food.counter[0] = 0;

			food.zeroDeath();
			food_counter = food.pop - pops;


		/*	for(int i =0; i <=2; i++){
				
				counter[i] = counter[i] - food_counter;
				
				if(counter[i]<0)
					counter[i] = counter[i]*-1;
				
				food_counter = food_counter - 	counter[i];
	
			}*/
		
			
			
			
		}else if(food.pop <=0 && pops>0){
			Debug.Log("zero");
			
			for (int i =0; i<pops; i++) {
				
				lastindex = alive.Count - 1;
				GameObject.Destroy (alive [lastindex]);
				alive.RemoveAt (lastindex);
			}

			zeroDeath();
			zeroCounter();
			pop = 0;
		}

		Debug.Log ("pop after eating " + pop);
	}

}