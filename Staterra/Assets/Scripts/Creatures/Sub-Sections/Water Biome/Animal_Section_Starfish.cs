using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Starfish : Animal_parents {

	
	//public int count_pop = 0;

	public Animal_Section_Starfish(){



		base.power=20 ;
		base.defence=89;
		base.command_pnts = 11;
		base.repro_ratio = 6;
		base.feed_ratio = 1;
		base.death_limit = 13;
		for (int i =0; i<12; i++)
			base.death.Add (0);

		for (int i =0; i<5; i++)
			base.counter.Add (0);

	//	count_pop = 0;
	}

	public void Death_Cycle(int blank){
		
		
		int lastindex = 0;
		
		for (int i =0; i< death[death_limit-1]; i++) {
			
			lastindex = alive.Count - 1;
			GameObject.Destroy (alive [lastindex]);
			alive.RemoveAt (lastindex);
		}
		
		pop = pop  - death[death_limit-1];
		
		
		for (int i =0; i<repro_ratio; i++) {
			if (i == 0 && counter [0] >= death [death_limit-1]) {
				counter [i] = counter [i] - death [death_limit-1];
				break;
			} else if (i != 0) {
				
				death [death_limit-1] = death [death_limit-1] - counter [i - 1];
				
				if (death [death_limit-1] == 0) {
					counter [i - 1] = 0;
					
					break;
					
					
				} else if (death [death_limit-1] > 0) {
					counter [i - 1] = 0;
					
				} else if (death [death_limit-1] < 0) {
					counter [i - 1] = death [death_limit-1] * -1;
					death [death_limit-1] = 0;
				}
			}
		}
		
		
		shift_Values_death(death_limit-1);
		
		
		Debug.Log ("pop after death " + pop);
		
	}




	public void Feeding_Cycle(ref Animal_Section_SeaUrchin food){
		Debug.Log ("eatne food pop" + food.pop);
		Debug.Log ("feeder food pop" + pop);
		int pops = pop;
		int lastindex = 0;
	//	int food_counter = 0 ;
		
		if (food.pop >= pops ) {
	//		food_counter = food.pop-  pops ;
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
			
			food.reduce_Death (food.pop - pop,food.death_limit);
			food.pop = food.pop - pops;
			food.counter[0] = food.counter[0] - pops;
			
			
			
			
		} else if ( food.pop < pops && food.pop >0) {
			Debug.Log("feed with few sources");
			
			//	copepod_class.pop = food.pop - pops;
			
			for (int i =0; i<=pops-food.pop; i++) {
				
				
				if(alive.Count >0){
					lastindex = alive.Count - 1;
					if(lastindex>=0){
						GameObject.Destroy (alive [lastindex]);
						alive.RemoveAt (lastindex);
					}else if (lastindex ==0){
						
						GameObject.Destroy (alive [lastindex]);
						alive[lastindex] = null;
					}
				}
				
				
			}
			Debug.Log("before while");
			while (food.alive.Count >=1){
				if(food.alive.Count>2){
					GameObject.Destroy (food.alive [0]);
					food.alive.RemoveAt (0);
				}else if (food.alive.Count==1){
					Debug.Log("last case");
					Debug.Log("at last pointer " + food.alive[0]);
					GameObject.Destroy (food.alive [0]);
					food.alive[0] = null;
				}
				
			}
			Debug.Log("after while");
			pop = food.pop;
			counter[0] = pop;
			counter[1] = 0;
			
			
			
			Debug.Log("pops " + pops);
			Debug.Log("food "+food);
			reduce_Death(pops-food.pop,death_limit );
			reduce_Count(pops-food.pop,repro_ratio );
			
			food.pop = 0;
			food.zeroCounter();
			
			food.zeroDeath();
			//food_counter = food.pop - pops;
			
			
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
		
		int [] prev_count = new int[repro_ratio];
		
		//	Debug.Log ("before for");
		for (int i =0; i<counter[1]; i++) {
			
			GameObject new_creat = GameObject.Instantiate (creature_object, pos, Quaternion.Euler( rot))as GameObject;
			alive.Add (new_creat);
			
		}
		
		death[0] = death[0] + counter[1];
		pop = pop +	counter[1];
		
		for (int i =0; i <repro_ratio; i++) {
			prev_count[i] = counter[i];
			
		}
		//prev_count[0] = counter[0];
		//	prev_count [1] = counter [1];
		
		counter[0] = prev_count[repro_ratio-1] * 2;
		for (int i =1; i <repro_ratio; i++) {
			counter [i] = prev_count [i-1];
			
		}
		
		
		//counter [1] = prev_count [0];
		
		//	death[0] = prev_count[1];
		Debug.Log ("pop after repro " + pop);
	}


}