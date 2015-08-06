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
	
	public void Death_Cycle(int blank){
		
		
		int lastindex = 0;
		
		for (int i =0; i< death[6]; i++) {
			
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
		
		pop = pop  - death[6];
		
		
		for (int i =0; i<3; i++) {
			if (i == 0 && counter [0] >= death [6]) {
				counter [i] = counter [i] - death [6];
				break;
			} else if (i != 0) {
				
				death [6] = death [6] - counter [i - 1];
				
				if (death [6] == 0) {
					counter [i - 1] = 0;
					
					break;
					
					
				} else if (death [6] > 0) {
					counter [i - 1] = 0;
					
				} else if (death [6] < 0) {
					counter [i - 1] = death [6] * -1;
					death [6] = 0;
				}
			}
		}
		
		
		shift_Values_death(6);
		
		
		Debug.Log ("pop after death " + pop);
		
	}



	public void Repro_Cycle(Vector3 pos, Vector3 rot){
		
		int [] prev_count = new int[3];
		
		//	Debug.Log ("before for");
		for (int i =0; i<counter[2]; i++) {
			//	Debug.Log ("counter val " + counter[0]);
			//	Debug.Log ("in if");
			GameObject new_creat = GameObject.Instantiate (creature_object, pos, Quaternion.Euler( rot))as GameObject;
			alive.Add (new_creat);
			
		}
		
		death[0] = death[0] + counter[2];
		pop = pop +	counter[2];
		
		prev_count[0] = counter[0];
		prev_count [1] = counter [1];
		prev_count [2] = counter [2];
		
		counter[0] = prev_count[2] * 2;
		counter [1] = prev_count [0];
		counter [2] = prev_count [1];
		//	death[0] = prev_count[1];
		Debug.Log ("pop after repro " + pop);
	}

}