using UnityEngine;
using System.Collections;

public class Spawn_Kill_processv7 : MonoBehaviour {

	public float timer; // for feeding cycle
	public float timer_limit;

	public GameObject [] creatures;
	public GameObject plankton;
	public int spawn_limit =0;

	public float timer2;// for reproduce cycle
	public float timer2_limit;

	public int food = 0;
	public int pops =0;

	public GameObject Plakton;
	public GameObject Copepod;
	public GameObject SeaUrchin;
	public GameObject Shrimp;
	public GameObject Jellyfish;
	public GameObject Bogue;

	public GameObject copepod_spawn;
	public GameObject seaurchin_spawn;
	public GameObject shrimp_spawn;
	public GameObject jellyfish_spawn;
	//for death distribution (if not fed)
	public int percent;
	public int percent2;
	public int num1;
	public int num2;

	int [] prev_count = new int[8]; // for reproduction

	int[] death = new int[17];


	public GameObject Copepod_details;
	public GameObject SeaUrchind_details;
	public GameObject Plankton_details;
	public GameObject Shrimp_details;
	public GameObject Jellyfish_details;
	public GameObject Starfish_details;
	public GameObject Bogue_details;
	public GameObject Crab_details;
	public GameObject Squid_details;
	public GameObject Turtle_details;
	public GameObject Seabass_details;
	public GameObject Octopus_details;
	public GameObject GulperShark_details;
	public GameObject Tuna_details;
	public GameObject Dolphin_details;
	public GameObject Hammerheadshark_details;

	public int death_counter =0;
	public  int food_counter = 0;

	public int eating_counter = 0;
	public int lastindex=0;
	void Start () {
		timer_limit = 2f;

		Copepod_details = GameObject.Find ("Copepod_Counter");
		SeaUrchind_details = GameObject.Find ("SeaUrchin_Counter");
		Plankton_details = GameObject.Find ("Plankton");
		Shrimp_details = GameObject.Find ("Shrimp_Counter");
		Jellyfish_details = GameObject.Find ("Jellyfish_Counter");
		Starfish_details = GameObject.Find ("Dummy");
		Bogue_details = GameObject.Find ("Dummy");
		Crab_details = GameObject.Find ("Dummy");
		Squid_details = GameObject.Find ("Dummy");
		Turtle_details = GameObject.Find ("Dummy");
		Seabass_details = GameObject.Find ("Dummy");
		Octopus_details = GameObject.Find ("Dummy");
		GulperShark_details = GameObject.Find ("Dummy");
		Tuna_details = GameObject.Find ("Dummy");
		Dolphin_details = GameObject.Find ("Dummy");
		Hammerheadshark_details = GameObject.Find ("Dummy");

	}

	// Update is called once per frame
	void FixedUpdate () {


		timer = timer + Time.deltaTime;

		//if (timer >= Time.deltaTime + timer_limit) {
		if (Input.GetKeyUp(KeyCode.Space)) {


			//basic resource (present in the game from start - created by system)
			plankton = GameObject.FindGameObjectWithTag ("Plankton");
			plankton.GetComponentInChildren<Animal_parents> ().pop = plankton.GetComponentInChildren<Animal_Section_Fighterplankton> ().pop + 10;
			
			creatures = GameObject.FindGameObjectsWithTag ("Creatures");
		
			//DEATH---------------------------------------------------------------------------------------------------------------------------------

			foreach (GameObject creature in creatures) {
			//	Debug.Log ("after check");

				//copepod =========================================================================
				if(creature.GetComponent<Animal_parents>().pop !=0){
				if (creature.gameObject.name == "Copepod_Counter"  ) {

						for (int i =0; i< creature.GetComponent<Animal_Section_Copepod>().death[4]; i++) {
							
							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}
					creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
						creature.GetComponent<Animal_Section_Copepod>().death[4];
					
				/*	death[0] =creature.GetComponent<Animal_Section_Copepod>().death[0];
					death[1]= creature.GetComponent<Animal_Section_Copepod>().death[1];
					death[2]=creature.GetComponent<Animal_Section_Copepod>().death[2];
					death[3]=creature.GetComponent<Animal_Section_Copepod>().death[3];*/
					death[4] =creature.GetComponent<Animal_Section_Copepod>().death[4];

					//counter modify
					for (int i =0; i<=2;i++){
						if(i==0 && creature.GetComponent<Animal_Section_Copepod>().counter[0]>=death[4]){
							creature.GetComponent<Animal_Section_Copepod>().counter[i] = creature.GetComponent<Animal_Section_Copepod>().counter[i] - death[4];
							break;
						}else if (i!=0){
							
							creature.GetComponent<Animal_Section_Copepod>().death[4] = creature.GetComponent<Animal_Section_Copepod>().death[4]-
								creature.GetComponent<Animal_Section_Copepod>().counter[i-1];
							if(creature.GetComponent<Animal_Section_Copepod>().death[4] ==0){
								creature.GetComponent<Animal_Section_Copepod>().counter[i-1] = creature.GetComponent<Animal_Section_Copepod>().death[4];

								break;

						//	}else if(creature.GetComponent<Animal_Section_Copepod>().death[4] <0){
							//	creature.GetComponent<Animal_Section_Copepod>().counter[i-1] =creature.GetComponent<Animal_Section_Copepod>().death[4] *-1;

							}else if(creature.GetComponent<Animal_Section_Copepod>().death[4] >0){
								creature.GetComponent<Animal_Section_Copepod>().counter[i-1] =0;

							}
						}
					}
		
					//counter end
					creature.GetComponent<Animal_Section_Copepod>().shift_Values_death(4);
					/*creature.GetComponent<Animal_Section_Copepod>().death[1]= death[0];
					creature.GetComponent<Animal_Section_Copepod>().death[2] =death[1];
					creature.GetComponent<Animal_Section_Copepod>().death[3] = death [2];
					creature.GetComponent<Animal_Section_Copepod>().death[4] =death[3];
					creature.GetComponent<Animal_Section_Copepod>().death[0] =0;*/

				}

//Seaurchin ================================================================================
				if (creature.gameObject.name == "SeaUrchin_Counter" ) {
					
					
					for (int i =0; i< creature.GetComponent<Animal_Section_SeaUrchin>().death[4]; i++) {
						
						lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
						Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
						creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
					}
					
					
					creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
						creature.GetComponent<Animal_Section_SeaUrchin>().death[4];
					
				/*	death[0] =creature.GetComponent<Animal_Section_SeaUrchin>().death[0];
					death[1]= creature.GetComponent<Animal_Section_SeaUrchin>().death[1];
					death[2]=creature.GetComponent<Animal_Section_SeaUrchin>().death[2];
					death[3]=creature.GetComponent<Animal_Section_SeaUrchin>().death[3];*/
					death[4] =creature.GetComponent<Animal_Section_SeaUrchin>().death[4];
					
					//counter modify
					for (int i =0; i<=2;i++){
						if(i==0 && creature.GetComponent<Animal_Section_SeaUrchin>().counter[0]>=death[4]){
							creature.GetComponent<Animal_Section_SeaUrchin>().counter[i] = creature.GetComponent<Animal_Section_SeaUrchin>().counter[i] - death[4];
							break;
						}else if (i!=0){
							
							creature.GetComponent<Animal_Section_SeaUrchin>().death[4] = creature.GetComponent<Animal_Section_SeaUrchin>().death[4]-
								creature.GetComponent<Animal_Section_SeaUrchin>().counter[i-1];
							if(creature.GetComponent<Animal_Section_SeaUrchin>().death[4] ==0){
								creature.GetComponent<Animal_Section_SeaUrchin>().counter[i-1] = creature.GetComponent<Animal_Section_SeaUrchin>().death[4];
								
								break;
								
								//	}else if(creature.GetComponent<Animal_Section_Copepod>().death[4] <0){
								//	creature.GetComponent<Animal_Section_Copepod>().counter[i-1] =creature.GetComponent<Animal_Section_Copepod>().death[4] *-1;
								
								
								
							}else if(creature.GetComponent<Animal_Section_SeaUrchin>().death[4] >0){
								creature.GetComponent<Animal_Section_SeaUrchin>().counter[i-1] =0;
								
							}
						}
					}
					
					//counter end
					creature.GetComponent<Animal_Section_SeaUrchin>().shift_Values_death(4);
				/*	creature.GetComponent<Animal_Section_SeaUrchin>().death[1]= death[0];
					creature.GetComponent<Animal_Section_SeaUrchin>().death[2] =death[1];
					creature.GetComponent<Animal_Section_SeaUrchin>().death[3] = death [2];
					creature.GetComponent<Animal_Section_SeaUrchin>().death[4] =death[3];
					creature.GetComponent<Animal_Section_SeaUrchin>().death[0] =0;*/
					
					
					
					
					
				}

				//Shrimp ================================================================
				if (creature.gameObject.name == "Shrimp_Counter") {
					
					
					for (int i =0; i< creature.GetComponent<Animal_Section_Shrimp>().death[4]; i++) {
						
						lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
						Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
						creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
					}
					
					
					creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
						creature.GetComponent<Animal_Section_Shrimp>().death[4];
					
			/*	death[0] =creature.GetComponent<Animal_Section_Shrimp>().death[0];
					death[1]= creature.GetComponent<Animal_Section_Shrimp>().death[1];
					death[2]=creature.GetComponent<Animal_Section_Shrimp>().death[2];
					death[3]=creature.GetComponent<Animal_Section_Shrimp>().death[3];*/
					death[4] =creature.GetComponent<Animal_Section_Shrimp>().death[4];
					
					//counter modify
					for (int i =0; i<=2;i++){
						if(i==0 && creature.GetComponent<Animal_Section_Shrimp>().counter[0]>=death[4]){
							creature.GetComponent<Animal_Section_Shrimp>().counter[i] = creature.GetComponent<Animal_Section_Shrimp>().counter[i] - death[4];
							break;
						}else if (i!=0){
							
							creature.GetComponent<Animal_Section_Shrimp>().death[4] = creature.GetComponent<Animal_Section_Shrimp>().death[4]-
								creature.GetComponent<Animal_Section_Shrimp>().counter[i-1];
							if(creature.GetComponent<Animal_Section_Shrimp>().death[4] ==0){
								creature.GetComponent<Animal_Section_Shrimp>().counter[i-1] = creature.GetComponent<Animal_Section_Shrimp>().death[4];
								
								break;
								
								//	}else if(creature.GetComponent<Animal_Section_Copepod>().death[4] <0){
								//	creature.GetComponent<Animal_Section_Copepod>().counter[i-1] =creature.GetComponent<Animal_Section_Copepod>().death[4] *-1;
								
								
								
							}else if(creature.GetComponent<Animal_Section_Shrimp>().death[4] >0){
								creature.GetComponent<Animal_Section_Shrimp>().counter[i-1] =0;
								
							}
						}
					}
					
					//counter end

					creature.GetComponent<Animal_Section_Shrimp>().shift_Values_death(4);
					/*creature.GetComponent<Animal_Section_Shrimp>().death[1]= death[0];
					creature.GetComponent<Animal_Section_Shrimp>().death[2] =death[1];
					creature.GetComponent<Animal_Section_Shrimp>().death[3] = death [2];
					creature.GetComponent<Animal_Section_Shrimp>().death[4] =death[3];
					creature.GetComponent<Animal_Section_Shrimp>().death[0] =0;*/

				}


			//jellyfish=============================================================================================

				if (creature.gameObject.name == "Jellyfish_Counter") {
					
					
					for (int i =0; i< creature.GetComponent<Animal_Section_Jellyfish>().death[8]; i++) {
						
						lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
						Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
						creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
					}
					
					
					creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
						creature.GetComponent<Animal_Section_Jellyfish>().death[8];

					
				/*	death[0] =creature.GetComponent<Animal_Section_Jellyfish>().death[0];
					death[1]= creature.GetComponent<Animal_Section_Jellyfish>().death[1];
					death[2]=creature.GetComponent<Animal_Section_Jellyfish>().death[2];
					death[3]=creature.GetComponent<Animal_Section_Jellyfish>().death[3];
					death[4] =creature.GetComponent<Animal_Section_Jellyfish>().death[4];
					death[5] =creature.GetComponent<Animal_Section_Jellyfish>().death[5];
					death[6] =creature.GetComponent<Animal_Section_Jellyfish>().death[6];
					death[7] =creature.GetComponent<Animal_Section_Jellyfish>().death[7];*/
					death[9] =creature.GetComponent<Animal_Section_Jellyfish>().death[8];
					//counter modify
					for (int i =0; i<=3;i++){
						if(i==0 && creature.GetComponent<Animal_Section_Jellyfish>().counter[0]>=death[8]){
							creature.GetComponent<Animal_Section_Jellyfish>().counter[i] = creature.GetComponent<Animal_Section_Jellyfish>().counter[i] - death[8];
							break;
						}else if (i!=0){
							
							creature.GetComponent<Animal_Section_Jellyfish>().death[8] = creature.GetComponent<Animal_Section_Jellyfish>().death[8]-
								creature.GetComponent<Animal_Section_Jellyfish>().counter[i-1];
							if(creature.GetComponent<Animal_Section_Jellyfish>().death[8] ==0){
								creature.GetComponent<Animal_Section_Jellyfish>().counter[i-1] = creature.GetComponent<Animal_Section_Jellyfish>().death[8];
								
								break;

							}else if(creature.GetComponent<Animal_Section_Jellyfish>().death[8] >0){
								creature.GetComponent<Animal_Section_Jellyfish>().counter[i-1] =0;
								
							}
						}
					}
					
					//counter end
					creature.GetComponent<Animal_Section_Jellyfish>().shift_Values_death(8);
					
					/*creature.GetComponent<Animal_Section_Jellyfish>().death[1]= death[0];
					creature.GetComponent<Animal_Section_Jellyfish>().death[2] =death[1];
					creature.GetComponent<Animal_Section_Jellyfish>().death[3] = death [2];
					creature.GetComponent<Animal_Section_Jellyfish>().death[4] =death[3];
					creature.GetComponent<Animal_Section_Jellyfish>().death[5] =death[4];
					creature.GetComponent<Animal_Section_Jellyfish>().death[6] =death[5];
					creature.GetComponent<Animal_Section_Jellyfish>().death[7] =death[6];
					creature.GetComponent<Animal_Section_Jellyfish>().death[8] =death[7];
					creature.GetComponent<Animal_Section_Jellyfish >().death[0] =0;*/
					
				}



			}
			}

		//	Debug.Log ("before check");


			//FEEDING CYCLE --------------------------------------------------------------------------------------------------------------
			foreach (GameObject creature in creatures) {
					if(creature.GetComponent<Animal_parents>().pop !=0){
			//	Debug.Log ("after check");
			
				if (creature.gameObject.name == "Copepod_Counter") {
			 	
				//	Debug.Log ("copepod loop");

					food = plankton.GetComponentInChildren<Animal_parents> ().pop;
					pops = creature.GetComponent<Animal_parents> ().pop;
					if (pops <= food) {
				//		Debug.Log ("pop less or equal food");
						plankton.GetComponentInChildren<Animal_parents> ().pop = food - pops;
	
					} else if (food < pops) {
					//	Debug.Log ("food less pop");
					//	Debug.Log (pops - food);
		
						for (int i =0; i<	pops-food; i++) {

							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}

			
						creature.GetComponent<Animal_parents> ().pop = food;
						plankton.GetComponentInChildren<Animal_parents> ().pop = 0;

						//repro allocation after death
						creature.GetComponent<Animal_Section_Copepod> ().counter[0] = creature.GetComponent<Animal_parents> ().pop;
						creature.GetComponent<Animal_Section_Copepod> ().counter[1] = 0;

			
						food_counter = pops - food;
						for (int i =4; i>=0;i--){
						
							Debug.Log(" before food" + food_counter);
								Debug.Log(" before death i " + creature.GetComponent<Animal_Section_Copepod>().death[i]);
								death_counter = creature.GetComponent<Animal_Section_Copepod>().death[i];


								food_counter = food_counter - death_counter ;

							Debug.Log("  food counter" + food_counter);
								if(food_counter ==0){

									creature.GetComponent<Animal_Section_Copepod>().death[i] = 0;
									break;
									
							} else	if(food_counter <0){
								
								creature.GetComponent<Animal_Section_Copepod>().death[i] = food_counter *-1;
								break;
									
								}
							
								if(creature.GetComponent<Animal_Section_Copepod>().death[i] <0){
								
						
									creature.GetComponent<Animal_Section_Copepod>().death[i] =	creature.GetComponent<Animal_Section_Copepod>().death[i] *-1;
								}
								Debug.Log("last death i " + creature.GetComponent<Animal_Section_Copepod>().death[i]);
								Debug.Log("last before food" + food);

						}

					}

				}


				if (creature.gameObject.name == "SeaUrchin_Counter") {

					food = plankton.GetComponentInChildren<Animal_parents> ().pop;
					pops = creature.GetComponent<Animal_parents> ().pop;
					if (pops <= food) {
					//	Debug.Log ("pop less or equal food");
						plankton.GetComponentInChildren<Animal_parents> ().pop = food - pops;
						
					} else if (food < pops) {
		
						
						for (int i =0; i<	pops-food; i++) {
							
							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}

						creature.GetComponent<Animal_parents> ().pop = food;
						plankton.GetComponentInChildren<Animal_parents> ().pop = 0;
						
						creature.GetComponent<Animal_Section_SeaUrchin> ().counter[0] = creature.GetComponent<Animal_parents> ().pop;
						creature.GetComponent<Animal_Section_SeaUrchin> ().counter[1] = 0;


						food_counter = pops - food;
						for (int i =4; i>=0;i--){
							
							Debug.Log(" before food" + food_counter);
							Debug.Log(" before death i " + creature.GetComponent<Animal_Section_SeaUrchin>().death[i]);
							death_counter = creature.GetComponent<Animal_Section_SeaUrchin>().death[i];
							
							
							food_counter = food_counter - death_counter ;
							
							Debug.Log("  food counter" + food_counter);
							if(food_counter ==0){
								
								creature.GetComponent<Animal_Section_SeaUrchin>().death[i] = 0;
								break;
								
							} else	if(food_counter <0){
								
								creature.GetComponent<Animal_Section_SeaUrchin>().death[i] = food_counter *-1;
								break;
								
							}
							
							if(creature.GetComponent<Animal_Section_SeaUrchin>().death[i] <0){
								
								
								creature.GetComponent<Animal_Section_SeaUrchin>().death[i] =	creature.GetComponent<Animal_Section_SeaUrchin>().death[i] *-1;
							}
							Debug.Log("last death i " + creature.GetComponent<Animal_Section_SeaUrchin>().death[i]);
							Debug.Log("last before food" + food);
						}
					}
				}

				if (creature.gameObject.name == "Shrimp_Counter") {
					
					food = Copepod_details.GetComponent<Animal_parents> ().pop;
					pops = creature.GetComponent<Animal_parents> ().pop; //population to feed

					if (pops<= food && pops > 0 && food >0) {
						Debug.Log("feed normal");
							if(Copepod_details.GetComponentInChildren<Animal_parents>().pop > pops){

								for (int i =0; i<pops; i++) {
									
								lastindex = Copepod_details.GetComponent<Animal_parents> ().alive.Count - 1;
									Destroy (Copepod_details.GetComponent<Animal_parents> ().alive [lastindex]);
									Copepod_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
								}
					
								Copepod_details.GetComponent<Animal_parents> ().pop =  food - pops;

							//-----------------------------NEW--------------------------------------------
							//food_counter = food - pops;

							if(Copepod_details.GetComponent<Animal_Section_Copepod>().counter[0]>=pops){

								Copepod_details.GetComponent<Animal_Section_Copepod>().counter[0] = Copepod_details.GetComponent<Animal_Section_Copepod>().counter[0] - food_counter;


							}else if (Copepod_details.GetComponent<Animal_Section_Copepod>().counter[0]<pops){
							
								Copepod_details.GetComponent<Animal_Section_Copepod>().counter[1] =Copepod_details.GetComponent<Animal_Section_Copepod>().counter[1] -
									(pops - Copepod_details.GetComponent<Animal_Section_Copepod>().counter[0]);

								Copepod_details.GetComponent<Animal_Section_Copepod>().counter[0] = 0;

							}

							for (int i =4; i>=0;i--){


								death_counter = Copepod_details.GetComponent<Animal_Section_Copepod>().death[i];
								food_counter = food_counter - death_counter ;

								if(food_counter ==0){
									Copepod_details.GetComponent<Animal_Section_Copepod>().death[i] = 0;
									break;
									
								} else	if(food_counter <0){
									Copepod_details.GetComponent<Animal_Section_Copepod>().death[i] = food_counter *-1;
									break;
								}
								
								if(Copepod_details.GetComponent<Animal_Section_Copepod>().death[i] <0){
									Copepod_details.GetComponent<Animal_Section_Copepod>().death[i] =	Copepod_details.GetComponent<Animal_Section_Copepod>().death[i] *-1;
								}
	
							}
						}

							}else	if (pops > food && pops >0 && food >0) {
						Debug.Log("feed with few sources");

						Copepod_details.GetComponent<Animal_parents> ().pop = food - pops;
						
						for (int i =0; i<pops-food; i++) {

				
							if(creature.GetComponent<Animal_parents> ().alive.Count >0){
								lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
								if(lastindex>=0){
								Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
								creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
								}
							}

							
							if(Copepod_details.GetComponentInChildren<Animal_parents> ().alive.Count >0){
								Destroy (Copepod_details.GetComponent<Animal_parents> ().alive [0]);
								Copepod_details.GetComponent<Animal_parents> ().alive.RemoveAt (0);

						}

						}

						Copepod_details.GetComponent<Animal_parents> ().pop = 0;
						Copepod_details.GetComponent<Animal_Section_Copepod> ().counter[0] = 0;
						Copepod_details.GetComponent<Animal_Section_Copepod> ().counter[1] = 0;
						Copepod_details.GetComponent<Animal_Section_Copepod> ().zeroDeath(	Copepod_details.GetComponent<Animal_Section_Copepod> ().death_limit);

						food_counter = food - pops;
						for(int i =0; i <=2; i++){

							creature.GetComponent<Animal_Section_Shrimp> ().counter[i] = creature.GetComponent<Animal_Section_Shrimp> ().counter[i] -
								food_counter;

							if(creature.GetComponent<Animal_Section_Shrimp> ().counter[i]<0)
								creature.GetComponent<Animal_Section_Shrimp> ().counter[i] = creature.GetComponent<Animal_Section_Shrimp> ().counter[i]*-1;

							food_counter = food_counter - 	creature.GetComponent<Animal_Section_Shrimp> ().counter[i];




						}
						creature.GetComponent<Animal_parents> ().pop = food;
						creature.GetComponent<Animal_Section_Shrimp> ().counter[0] = creature.GetComponent<Animal_parents> ().pop;
						creature.GetComponent<Animal_Section_Shrimp> ().counter[1] = 0;
						creature.GetComponent<Animal_Section_Shrimp> ().counter[2] = 0;


						Debug.Log("pops " + pops);
						Debug.Log("food "+food);
						creature.GetComponent<Animal_Section_Shrimp>().reduce_Death(pops-food,creature.GetComponent<Animal_Section_Shrimp>().death_limit );



					}else if(food <=0 && pops>0){
						Debug.Log("zero");

						for (int i =0; i<pops; i++) {
							
							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (Shrimp_details.GetComponent<Animal_parents> ().alive [lastindex]);
							Shrimp_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}
						creature.GetComponent<Animal_Section_Shrimp> ().zeroDeath(creature.GetComponent<Animal_Section_Shrimp> ().death_limit);
						creature.GetComponent<Animal_Section_Shrimp> ().zeroCounter(creature.GetComponent<Animal_Section_Shrimp> ().feed_ratio);
						creature.GetComponent<Animal_parents> ().pop = 0;
					}
					
					}


				//JELLYFISH ================================================================================================

				if (creature.gameObject.name == "Jellyfish_Counter") {
					
					food = Copepod_details.GetComponent<Animal_parents> ().pop +Shrimp_details.GetComponent<Animal_parents> ().pop +
						Bogue_details.GetComponent<Animal_parents> ().pop;
					pops = creature.GetComponent<Animal_parents> ().pop; //population to feed
					eating_counter = creature.GetComponent<Animal_Section_Jellyfish> ().Feed_items();
						Debug.Log ("eating_counter " + eating_counter);

					if(eating_counter == 10)
						Debug.Log("invalid results");

					if(eating_counter == 7){

						Debug.Log("zero");
						
						for (int i =0; i<pops; i++) {
							
							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (Jellyfish_details.GetComponent<Animal_parents> ().alive [lastindex]);
							Jellyfish_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}
						Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().zeroDeath(Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().death_limit);
						Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().zeroCounter(Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().repro_ratio);
						Jellyfish_details.GetComponent<Animal_parents> ().pop = 0;
						

						
					}else if (eating_counter <=3){
							Debug.Log("eating ");
					for(int i =0; i <=eating_counter;i++){
						if(i == 0 ){

							if(eating_counter==1 || eating_counter ==2 || eating_counter ==3 || (eating_counter ==0 && 
								Jellyfish_details.GetComponent<Animal_parents> ().pop == Shrimp_details.GetComponent<Animal_parents> ().pop) ){
										Debug.Log("eating in 0");
										for (int j =0; j<Shrimp_details.GetComponent<Animal_parents> ().pop; j++) {
											
											lastindex = Shrimp_details.GetComponent<Animal_parents> ().alive.Count - 1;
											
											if(lastindex <= -1)
												break;
											
											Destroy (Shrimp_details.GetComponent<Animal_parents> ().alive [lastindex]);
											Shrimp_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
											
										}

										Shrimp_details.GetComponent<Animal_Section_Shrimp> ().zeroDeath(Shrimp_details.GetComponent<Animal_Section_Shrimp> ().death_limit);
										Shrimp_details.GetComponent<Animal_Section_Shrimp> ().zeroCounter(Shrimp_details.GetComponent<Animal_Section_Shrimp> ().repro_ratio);
										food_counter =  Jellyfish_details.GetComponent<Animal_parents> ().pop - Shrimp_details.GetComponent<Animal_parents> ().pop  ;
										Shrimp_details.GetComponent<Animal_parents> ().pop = 0;
									


								} else if (eating_counter ==0 && Jellyfish_details.GetComponent<Animal_parents> ().pop < Shrimp_details.GetComponent<Animal_parents> ().pop){
									food_counter =  Shrimp_details.GetComponent<Animal_parents> ().pop -Jellyfish_details.GetComponent<Animal_parents> ().pop  ;


										for (int j =0; j<food_counter; j++) {
											
											lastindex = Shrimp_details.GetComponent<Animal_parents> ().alive.Count - 1;
											
											if(lastindex <= -1)
												break;
											
											Destroy (Shrimp_details.GetComponent<Animal_parents> ().alive [lastindex]);
											Shrimp_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
											
										}


									Shrimp_details.GetComponent<Animal_Section_Shrimp> ().reduce_Death(food_counter, Shrimp_details.GetComponent<Animal_Section_Shrimp> ().death_limit);
									Shrimp_details.GetComponent<Animal_Section_Shrimp> ().reduce_Count(food_counter, Shrimp_details.GetComponent<Animal_Section_Shrimp> ().repro_ratio);
									Shrimp_details.GetComponent<Animal_Section_Shrimp> ().pop = food_counter;
								}


						}
						if(i == 1){
									Debug.Log(" i = 1");
									Debug.Log("food counter " + food_counter);
									Debug.Log("copeopd pop " + Copepod_details.GetComponent<Animal_parents> ().pop);
							if( eating_counter ==2 || eating_counter ==3 || (eating_counter ==1 && food_counter == Copepod_details.GetComponent<Animal_parents> ().pop) ){
										Debug.Log("eating in 1 eqaul or smaller");
										
										for (int j =0; j<Copepod_details.GetComponent<Animal_parents> ().pop; j++) {
											
											lastindex = Copepod_details.GetComponent<Animal_parents> ().alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (Copepod_details.GetComponent<Animal_parents> ().alive [lastindex]);
											Copepod_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
										}



										Copepod_details.GetComponent<Animal_Section_Copepod> ().zeroDeath(Copepod_details.GetComponent<Animal_Section_Copepod> ().death_limit);
										Copepod_details.GetComponent<Animal_Section_Copepod> ().zeroCounter(Copepod_details.GetComponent<Animal_Section_Copepod> ().repro_ratio);
										food_counter = food_counter - Copepod_details.GetComponent<Animal_parents> ().pop;
										Copepod_details.GetComponent<Animal_parents> ().pop = 0;

							} else if (eating_counter ==1 &&food_counter < Shrimp_details.GetComponent<Animal_parents> ().pop){
										Debug.Log("eating 1 remover larger");
										food_counter = Shrimp_details.GetComponent<Animal_parents> ().pop -food_counter  ;
									

										for (int j =0; j<food_counter; j++) {
											
											lastindex = Copepod_details.GetComponent<Animal_parents> ().alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (Copepod_details.GetComponent<Animal_parents> ().alive [lastindex]);
											Copepod_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
										}
									//	food_counter =  Copepod_details.GetComponent<Animal_parents> ().pop -Jellyfish_details.GetComponent<Animal_parents> ().pop  ;
										
										Copepod_details.GetComponent<Animal_Section_Copepod> ().reduce_Death(food_counter, Copepod_details.GetComponent<Animal_Section_Copepod> ().death_limit);
										Copepod_details.GetComponent<Animal_Section_Copepod> ().reduce_Count(food_counter, Copepod_details.GetComponent<Animal_Section_Copepod> ().repro_ratio);
										Copepod_details.GetComponent<Animal_Section_Copepod> ().pop = food_counter;
								}






							}

							if(i == 2){
								
								
						
								//Bogue_details.GetComponent<Animal_Section_Copepod> ().zeroDeath(Bogue_details.GetComponent<Animal_Section_Copepod> ().death_limit);
							//	Bogue_details.GetComponent<Animal_Section_Copepod> ().zeroCounter(Bogue_details.GetComponent<Animal_Section_Copepod> ().repro_ratio);
								//Bogue_details.GetComponent<Animal_parents> ().pop = Shrimp_details.GetComponent<Animal_parents> ().pop - pops;
								

									if(  eating_counter ==3 || (eating_counter ==2 && food_counter == Bogue_details.GetComponent<Animal_parents> ().pop) ){

										for (int j =0; j<Bogue_details.GetComponent<Animal_parents> ().pop; j++) {
											
											lastindex = Bogue.GetComponent<Animal_parents> ().alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (Bogue.GetComponent<Animal_parents> ().alive [lastindex]);
											Bogue_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
										}



										Bogue_details.GetComponent<Animal_Section_Bogue> ().zeroDeath(Bogue_details.GetComponent<Animal_Section_Bogue> ().death_limit);
										Bogue_details.GetComponent<Animal_Section_Bogue> ().zeroCounter(Bogue_details.GetComponent<Animal_Section_Bogue> ().repro_ratio);
										food_counter = food_counter - Bogue_details.GetComponent<Animal_parents> ().pop;
										Bogue_details.GetComponent<Animal_parents> ().pop = 0;
										
									} else if (eating_counter ==2 &&food_counter < Shrimp_details.GetComponent<Animal_parents> ().pop){
										
										food_counter = Bogue_details.GetComponent<Animal_parents> ().pop -food_counter  ;


										for (int j =0; j<food_counter; j++) {
											
											lastindex = Bogue.GetComponent<Animal_parents> ().alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (Bogue.GetComponent<Animal_parents> ().alive [lastindex]);
											Bogue_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
										}
										//	food_counter =  Copepod_details.GetComponent<Animal_parents> ().pop -Jellyfish_details.GetComponent<Animal_parents> ().pop  ;
										
										Bogue_details.GetComponent<Animal_Section_Bogue> ().reduce_Death(food_counter, Bogue_details.GetComponent<Animal_Section_Bogue> ().death_limit);
										Bogue_details.GetComponent<Animal_Section_Bogue> ().reduce_Count(food_counter, Bogue_details.GetComponent<Animal_Section_Bogue> ().repro_ratio);
										Bogue_details.GetComponent<Animal_Section_Bogue> ().pop = food_counter;
									}
	
							}

							if(i == 3){
								
								
								for (int j =0; j<food_counter; j++) {
									
									lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
									Destroy (Jellyfish.GetComponent<Animal_parents> ().alive [lastindex]);
									Jellyfish_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
								}
									Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().reduce_Death(food_counter, Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().death_limit);
									Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().reduce_Count(food_counter, Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().repro_ratio);
									Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().pop = food_counter;
								
								
							}
							
							

					}

				}
			}
		}
	}
			//REPRODUCTION CYCLE ----------------------------------------------------------------------------------------------------------------------

			foreach (GameObject creature in creatures) {
				if(creature.GetComponent<Animal_parents>().pop !=0){

				if (creature.gameObject.name == "Jellyfish_Counter") {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {
						
						for (int i =0; i<creature.GetComponent<Animal_Section_Jellyfish>().counter[3]; i++) {
							GameObject new_creat = Instantiate (Jellyfish, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
							creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
							
						}
						
						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
							creature.GetComponent<Animal_Section_Jellyfish> ().counter[3];
						
						prev_count[0] = creature.GetComponent<Animal_Section_Jellyfish> ().counter[0];
						prev_count[1] = creature.GetComponent<Animal_Section_Jellyfish> ().counter[1];
						prev_count[2] = creature.GetComponent<Animal_Section_Jellyfish> ().counter[2];
						prev_count[3] = creature.GetComponent<Animal_Section_Jellyfish> ().counter[3];
						
						creature.GetComponent<Animal_Section_Jellyfish> ().counter[0] = prev_count[3] * 2;
						creature.GetComponent<Animal_Section_Jellyfish> ().counter[1] = prev_count[0];
						creature.GetComponent<Animal_Section_Jellyfish> ().counter[2] = prev_count[1];
						creature.GetComponent<Animal_Section_Jellyfish> ().counter[3] = prev_count[2];
						creature.GetComponent<Animal_Section_Jellyfish> ().death[0] = prev_count[3] ;
					}
					
				}








				if (creature.gameObject.name == "Shrimp_Counter") {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {
						
						for (int i =0; i<creature.GetComponent<Animal_Section_Shrimp>().counter[2]; i++) {
							GameObject new_creat = Instantiate (Jellyfish, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
							creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
							
						}

						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
						creature.GetComponent<Animal_Section_Shrimp> ().counter[2];
						
						prev_count[0] = creature.GetComponent<Animal_Section_Shrimp> ().counter[0];
						prev_count[1] = creature.GetComponent<Animal_Section_Shrimp> ().counter[1];
						prev_count[2] = creature.GetComponent<Animal_Section_Shrimp> ().counter[2];

						creature.GetComponent<Animal_Section_Shrimp> ().counter[0] = prev_count[2] * 2;
						creature.GetComponent<Animal_Section_Shrimp> ().counter[1] = prev_count[0];
						creature.GetComponent<Animal_Section_Shrimp> ().counter[2] = prev_count[1];
						creature.GetComponent<Animal_Section_Shrimp> ().death[0] = prev_count[2] ;
					}
					
				}
				



				if (creature.gameObject.name == "SeaUrchin_Counter") {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {
						
						for (int i =0; i<creature.GetComponent<Animal_Section_SeaUrchin>().counter[1]; i++) {
							GameObject new_creat = Instantiate (SeaUrchin, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
							creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
							
						}
						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
							creature.GetComponent<Animal_Section_SeaUrchin> ().counter[1];
						
						prev_count[0] = creature.GetComponent<Animal_Section_SeaUrchin> ().counter[0];
						prev_count[1] = creature.GetComponent<Animal_Section_SeaUrchin> ().counter[1];
						
						creature.GetComponent<Animal_Section_SeaUrchin> ().counter[0] = prev_count[1] * 2;
						creature.GetComponent<Animal_Section_SeaUrchin> ().counter[1] = prev_count[0];
						creature.GetComponent<Animal_Section_SeaUrchin> ().death[0] = prev_count[1] ;
					}
					
				}
				

				if (creature.gameObject.name == "Copepod_Counter" ) {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {

						for (int i =0; i<creature.GetComponent<Animal_Section_Copepod>().counter[1]; i++) {
							GameObject new_creat = Instantiate (Copepod, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
							creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
			
						}

						creature.GetComponent<Animal_Section_Copepod>().death[0] = creature.GetComponent<Animal_Section_Copepod>().counter[1];
						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
							creature.GetComponent<Animal_Section_Copepod> ().counter[1];

						prev_count[0] = creature.GetComponent<Animal_Section_Copepod> ().counter[0];
						prev_count[1] = creature.GetComponent<Animal_Section_Copepod> ().counter[1];

						creature.GetComponent<Animal_Section_Copepod> ().counter[0] = prev_count[1] * 2;
						creature.GetComponent<Animal_Section_Copepod> ().counter[1] = prev_count[0];
						creature.GetComponent<Animal_Section_Copepod> ().death[0] = prev_count[1] ;

					}

				}

			}
			}
			timer = 0;
			
		}


	}
}

