using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Seabass : Animal_parents {
	

	public Animal_Section_Seabass(){
		base.max_pop = 50;
		base.power=75 ;
		base.defence=250;
		base.command_pnts = 22;
		base.repro_ratio = 5;
		base.feed_ratio = 1;
		base.death_limit = 11;

		for (int i =0; i<10; i++)
			base.death.Add (0);
		
		for (int i =0; i<5; i++)
			base.counter.Add (0);
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
	
	
	
	
	public void Feeding_Cycle(ref Animal_Section_Bogue food1, ref Animal_Section_Octopus food2, ref Animal_Section_SeaUrchin food3, ref Animal_Section_Squid food4){
		
		Animal_parents [] foods = new Animal_parents[4];
		int pops = pop;
		int lastindex = 0;
		//		int food_counter = pops;
		foods [0] = food1;
		foods [1] = food2;
		
		
		
		if (food1.pop <= 0 && food2.pop <= 0 && pop > 0) {
			Debug.Log ("zero");
			
			for (int i =0; i<pop; i++) {
				
				lastindex = alive.Count - 1;
				if (lastindex > 0) {
					GameObject.Destroy (alive [lastindex]);
					alive.RemoveAt (lastindex);
				} else if (lastindex == 0) {
					
					//lastindex = alive.Count - 1;
					GameObject.Destroy (alive [lastindex]);
					alive [lastindex] = null;
				}
			}
			
			zeroDeath ();
			zeroCounter ();
			pop = 0;
		} else {
			Debug.Log ("for each case");
			Debug.Log ("foods contents" + foods);
			foreach (Animal_parents food in foods) {
				Debug.Log ("food parent" + food);
				if(pops>0 && food.pop>0){
					if (food.pop >= pops) {
						Debug.Log("food greater than pop");
						//normal eating (no loss from eating creature)
						for (int i =0; i<pops; i++) {
							
							lastindex = food.alive.Count - 1;
							if (lastindex > 0) {
								GameObject.Destroy (food.alive [lastindex]);
								food.alive.RemoveAt (lastindex);
							} else if (lastindex == 0) {
								
								GameObject.Destroy (food.alive [lastindex]);
								food.alive [lastindex] = null;
							}
						}
						
						pops = pops - food.pop;
						
						
						food.pop = food.pop - pop;
						food.counter [0] = food.counter [0] - pop;
						
						food.reduce_Death (pop, food.death_limit);
						food.reduce_Count (pop, food.repro_ratio);
						
						
						
						
					}else if (food.pop < pops && food.pop > 0) {
						Debug.Log ("feed with few sources");
						
						//	copepod_class.pop = food.pop - pops;
						
						/*		for (int i =0; i<=pops-food.pop; i++) {
							lastindex = alive.Count - 1;
					
							if (alive.Count > 0) {
						
								if (lastindex > 0) {
									GameObject.Destroy (alive [lastindex]);
									alive.RemoveAt (lastindex);
								} else if (lastindex == 0) {
							
									GameObject.Destroy (alive [lastindex]);
									alive [lastindex] = null;
								}
							}
						}*/
						
						while (food.alive.Count >0) {
							if (food.alive.Count > 1) {
								GameObject.Destroy (food.alive [0]);
								food.alive.RemoveAt (0);
							} else if (food.alive.Count == 1) {
								GameObject.Destroy (alive [lastindex]);
								alive [lastindex] = null;
							}
							
						}
						
						/*			pop = food.pop;
						counter [0] = pop;
						counter [1] = 0;
						counter [2] = 0;
				
				
						Debug.Log ("pops " + pops);
						Debug.Log ("food " + food);
						reduce_Death (pops - food.pop, death_limit);
						reduce_Count (pops - food.pop, repro_ratio);*/
						pops = pops - food.pop;
						
						food.pop = 0;
						food.zeroCounter ();
						
						food.zeroDeath ();
						//food_counter = food.pop - pops;
						
						
						
						
					} 
					
					Debug.Log ("pop after eating " + pop);
					
					
				}
				
			}
			
			if(pops>0){
				
				for (int i =0; i<=pops; i++) {
					lastindex = alive.Count - 1;
					
					if (alive.Count > 0) {
						
						if (lastindex > 0) {
							GameObject.Destroy (alive [lastindex]);
							alive.RemoveAt (lastindex);
						} else if (lastindex == 0) {
							
							GameObject.Destroy (alive [lastindex]);
							alive [lastindex] = null;
						}
					}
				}
				
				pop = pop - pops;
				
				//counter [1] = 0;
				//counter [2] = 0;
				zeroCounter();
				counter [0] = pop;
				
				Debug.Log ("pops " + pops);
				//	Debug.Log ("food " + food);
				reduce_Death (pops, death_limit);
				reduce_Count (pops, repro_ratio);
				
				
			}
		}
	}
	
	
	
	
	public void Repro_Cycle(Vector3 pos, Vector3 rot){
		
		int [] prev_count = new int[repro_ratio];
		
		//	Debug.Log ("before for");
		for (int i =0; i<counter[repro_ratio -1]; i++) {
			
			GameObject new_creat = GameObject.Instantiate (creature_object, pos, Quaternion.Euler( rot))as GameObject;
			alive.Add (new_creat);
			
		}
		
		death[0] = death[0] + counter[repro_ratio -1];
		pop = pop +	counter[repro_ratio -1];
		
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