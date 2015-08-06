using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_SeaUrchin : Animal_parents {
	


		public Animal_Section_SeaUrchin(){



		base.power=0 ;
		base.defence=96f;
		base.command_pnts = 2;
		base.repro_ratio = 1;
		base.feed_ratio = 1;
		base.death_limit = 3;
		//base.counter.Add (0);
		for (int i =0; i<2; i++)
			base.death.Add (0);


	//	count_pop = 0;
	}

	public void Death_Cycle(int blank){
		int lastindex = 0;
		for (int i =0; i< death[2]; i++) {
			
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
		pop = pop  - death[2];

		for (int i =0; i<1;i++){
			if(i==0 && counter[0]>=death[2]){
				counter[i] = counter[i] - death[2];
				break;
			}else if (i!=0){
				
				death[2] = death[2]-counter[i-1];
				if(death[2] ==0){
					counter[i-1] = 0;
					
					break;
					
					
				}else if(death[2] >0){
					counter[i-1] =0;
					
				}
			}
		}
		
		
		shift_Values_death(2);
		
		
		
		
	}


	public void Feeding_Cycle(ref Animal_Section_Fighterplankton food){
		
		
		int pops = pop;
		int lastindex = 0;
		int food_counter = pops - food.pop;
	
		if ( food.pop >= pops) {
			
			food.pop = food.pop - pops;
			
		} else if (food.pop < pops) {
			
			for (int i =0; i<=	pops-food.pop; i++) {
				lastindex = alive.Count - 1;

				if(lastindex >0){

					GameObject.Destroy (alive [lastindex]);
					alive.RemoveAt (lastindex);

				}else if (lastindex ==0){
					
					//lastindex = alive.Count - 1;
					GameObject.Destroy (alive [lastindex]);
					alive[lastindex] = null;
				}
			}
			
			
			pop = food.pop;
			food.pop = 0;
			
			counter[0] = pop;

			for (int i =2; i>=0;i--){

				food_counter = food_counter - death[i];
				
				
				if(food_counter ==0){
					
					death[i] = 0;
					break;
					
				} else	if(food_counter <0){
					
					death[i] = food_counter *-1;
					break;
					
				}
				
				if(death[i] <0){
					
					
					death[i] =	death[i] *-1;
				}
				
				
			}
			
		}
		
		if (pop == 0) {
			
			
			zeroDeath();
			zeroCounter();
			
		}
		Debug.Log ("pop after eating " + pop);
	}


	public void Repro_Cycle(Vector3 pos, Vector3 rot){
		
		int prev_count = 0;
		
		for (int i =0; i<counter[0]; i++) {
			
			GameObject new_creat = GameObject.Instantiate (creature_object, pos, Quaternion.Euler( rot))as GameObject;
			alive.Add (new_creat);
			
		}
		
		death[0] = counter[0];
		pop = pop +	counter[0];
		
		prev_count = counter[0];
		
		
		counter[0] = prev_count * 2;
		
		death[0] = prev_count;
		Debug.Log ("pop after repro " + pop);
	}


	
}