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

		base.counter.Add (0);
		base.counter.Add (0);
		
		for (int i =0; i<6; i++)
			base.death.Add (0);
		//	count_pop = 0;
	}
	
	public void Death_Cycle(int blank){
		Debug.Log ("in death");
		
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
		Debug.Log ("after for loop death");
		pop = pop  - death[6];
		
		reduce_Count (death [6], death_limit);
		/*for (int i =0; i<3; i++) {
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
		}*/
		
		
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



	public void Feeding_Cycle(ref Animal_Section_Copepod food1, ref Animal_Section_Shrimp food2){
		
		Animal_parents [] foods = new Animal_parents[2];
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

}