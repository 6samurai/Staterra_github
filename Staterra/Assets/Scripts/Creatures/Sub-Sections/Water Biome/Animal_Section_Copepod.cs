using UnityEngine;
using System.Collections;

using System;



public class Animal_Section_Copepod : Animal_parents {

	//public int count_stage1 = 0;
//public int count_stage2 = 0;
//	public  Animal_Section_Fighterplankton plankton_class = new Animal_Section_Fighterplankton();
	//	public int []  counter = new int[2];
//	public int [] death = new int[5];
	//public GameObject[] alive;
	//public int count_pop = 0;


	public Animal_Section_Copepod(){



		base.power=0 ;
		base.defence=30f;
		base.command_pnts = 1;
		base.repro_ratio = 1;
		base.feed_ratio = 1;
		//base.pop = 0;
		base.death_limit = 4;
	//	base.counter.Add (0);
		for (int i =0; i<3; i++)
			base.death.Add (0);
		//base.death_ratio = 5;
		//count_pop = 0;


	}



	public void Death_Cycle(int blank){

		Debug.Log (" cope pop before death " + pop);

		int lastindex = 0;

		for (int i =0; i< death[3]; i++) {
			
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

		pop = pop  - death[3];

		//death[4] = death[3];
		
		//counter modify
		for (int i =0; i<1;i++){
			if(i==0 && counter[0]>=death[3]){
				counter[i] = counter[i] - death[3];
				break;
			}else if (i!=0){
				
				death[3] = death[3]-counter[i-1];

				if(death[3] ==0){
					counter[i-1] = 0;
					
					break;
					
					
				}else if(death[3] >0){
					counter[i-1] =0;
					
				}
			}
		}
		
		
		shift_Values_death(3);


		Debug.Log (" cope pop after death " + pop);

	}

	public void Feeding_Cycle(ref Animal_Section_Fighterplankton food){

		//int food = plankton_class.pop;
		int pops = pop;
		int lastindex = 0;
		int food_counter = pops - food.pop;

		if ( food.pop>=pops) {
		//		Debug.Log ("pop less or equal food");
			food.pop = food.pop - pops;
			//return
		} else if (food.pop < pops) {
			Debug.Log ("pop" + pops );
			Debug.Log ("food " + food.pop);
			Debug.Log ("food less pop" + (pops - food.pop));
			Debug.Log ("index counter" + (alive.Count - 1));			
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
			Debug.Log(" AFTER DESTORY");
			
			pop = food.pop;
			food.pop = 0;
			//return (0);

			//repro allocation after death
			counter[0] = pop;

			
			Debug.Log(" BEFORE COUNT");
			//food_counter = pops - food;
			for (int i =3; i>=0;i--){
				
			//	Debug.Log(" before food" + food_counter);
			//	Debug.Log(" before death i " + death[i]);
			
				
				
				food_counter = food_counter - death[i] ;

		//		Debug.Log("  food counter" + food_counter);
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
			//	Debug.Log("last death i " + death[i]);
			//	Debug.Log("last before food" + food);
				
			}
			
		}

		
		Debug.Log ("pop after eating " + pop);
		Debug.Log ("pop after eating " + alive);
		if (pop == 0) {


			zeroDeath();
			zeroCounter();

		}
	}

	public void Repro_Cycle(Vector3 pos, Vector3 rot){

		int prev_count = 0;
	//	Debug.Log ("before for");
			for (int i =0; i<counter[0]; i++) {
		//	Debug.Log ("counter val " + counter[0]);
		//	Debug.Log ("in if");
			GameObject new_creat = GameObject.Instantiate (creature_object, pos, Quaternion.Euler( rot))as GameObject;
				alive.Add (new_creat);
				
			}
		//Debug.Log ("after spawning");
			death[0] = counter[0];
			pop = pop +	counter[0];
			
			prev_count = counter[0];
			//prev_count[1] = creature.GetComponent<Animal_Section_Copepod> ().counter[1];
			
			counter[0] = prev_count * 2;
			//	creature.GetComponent<Animal_Section_Copepod> ().counter[1] = prev_count[0];
			death[0] = prev_count;
		Debug.Log ("pop after repro " + pop);
		}
		
}