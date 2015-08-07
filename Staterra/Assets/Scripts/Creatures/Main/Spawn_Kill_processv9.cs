using UnityEngine;
using System.Collections;
using System;
public class Spawn_Kill_processv9 : MonoBehaviour {

	public float timer; // for feeding cycle
	public float timer_limit;

	public GameObject [] creatures;
	public GameObject plankton;
	public int spawn_limit =0;

//	public float timer2;// for reproduce cycle
///	public float timer2_limit;

	public int food = 0;
	public int pops =0;


	public GameObject Plakton;
	public GameObject Copepod;
	public GameObject SeaUrchin;
	public GameObject Shrimp;
	public GameObject Jellyfish;
	public GameObject Bogue;
	public GameObject Crab;
	public GameObject Starfish;
	public GameObject Squid;
	public GameObject Octopus;
	public GameObject Seabass;
	public GameObject Turtle;
	public GameObject GulperShark;
	public GameObject Tuna;
	public GameObject Dolphin;
	public GameObject HammerheadShark;


	public GameObject copepod_spawn;
	public GameObject seaurchin_spawn;
	public GameObject shrimp_spawn;
	public GameObject jellyfish_spawn;

	public GameObject crab_spawn;
	public GameObject bogue_spawn;
	public GameObject starfish_spawn;
	public GameObject squid_spawn;

	public GameObject octopus_spawn;
	public GameObject seabass_spawn;
	public GameObject turtle_spawn;
	public GameObject gulper_spawn;

	public GameObject tuna_spawn;
	public GameObject dolphin_spawn;
	public GameObject hammerhead_spawn;

	//for death distribution (if not fed)
	public int percent;
	public int percent2;
	public int num1;
	public int num2;

	int [] prev_count = new int[8]; // for reproduction

	int[] death = new int[17];


/*	public GameObject Copepod_details;
	public GameObject SeaUrchin_details;
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
*/
	public int death_counter =0;
	public  int food_counter = 0;

	public int eating_counter = 0;
	public int lastindex=0;

	public  Animal_Section_Fighterplankton plankton_class = new Animal_Section_Fighterplankton();
	public  Animal_Section_Copepod copepod_class = new Animal_Section_Copepod();
	public  Animal_Section_SeaUrchin seaurchin_class = new Animal_Section_SeaUrchin();
	public  Animal_Section_Crab crab_class = new Animal_Section_Crab();
	public  Animal_Section_Shrimp shrimp_class = new Animal_Section_Shrimp();
	public  Animal_Section_Starfish starfish_class = new Animal_Section_Starfish();
	public  Animal_Section_Bogue bogue_class = new Animal_Section_Bogue();
	public  Animal_Section_Jellyfish jellyfish_class = new Animal_Section_Jellyfish();
	public  Animal_Section_Squid squid_class = new Animal_Section_Squid();
	public  Animal_Section_Octopus octopus_class = new Animal_Section_Octopus();
	public  Animal_Section_Seabass seabass_class = new Animal_Section_Seabass();
	public  Animal_Section_Turtle turtle_class = new Animal_Section_Turtle();
	public  Animal_Section_GulperShark gulper_class = new Animal_Section_GulperShark();
	public  Animal_Section_Tuna tuna_class = new Animal_Section_Tuna();
	public  Animal_Section_HammerheadShark hammer_class = new Animal_Section_HammerheadShark();
	public  Animal_Section_Dolphin dolphin_class = new Animal_Section_Dolphin();


	
	public bool[,] tiers = new bool[5, 2];
	public bool [] tier_stage = new bool [4];
	public bool active = false;

	public int count =0 ;

	public int[] temp_double_pop = new int[13];
	public float timer2;

	public void set_Active(){

		active = true;

	}
	void Awake(){
		for (int i =0; i <tier_stage.Length; i++) {

			tier_stage[i] = true;

		}



	}


	void Create_Creature(){
		
		GameObject cntrl = GameObject.Find("Animal_Object_control");
		Spawn_Kill_processv9 tier = cntrl.GetComponent<Spawn_Kill_processv9>();
		
		timer2 = Time.deltaTime + timer2;
		if(Input.GetKeyUp(KeyCode.F1)){ // && timer>= Time.deltaTime + timer_limit){
			
			//tiers[0,0] = true;
			//active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(Copepod, transform.position, transform.rotation) as GameObject;
			Debug.Log ("create");
			copepod_class.alive.Add(new_inst);
			Debug.Log ("after create");
			copepod_class.pop ++;
			Debug.Log("after pop");
			copepod_class.counter[0] ++;
			Debug.Log("copepod_class.counter[0] ++;");
			copepod_class.death[0]++;
			Debug.Log ("death[0]++");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
		
		if(Input.GetKeyUp(KeyCode.F2)){// && timer>= Time.deltaTime + timer_limit){
			//	tiers[0,0] = true;
			//	active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(SeaUrchin, transform.position, transform.rotation) as GameObject;
			
			seaurchin_class.alive.Add(new_inst);
			
			seaurchin_class.pop ++;
			seaurchin_class.counter[0] ++;
			seaurchin_class.death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
		
		if(Input.GetKeyUp(KeyCode.F3) ){//&& timer>= Time.deltaTime + timer_limit){
			//			tiers[0,0] = true;
			//	Debug.Log("in spawner" + tier.tiers[0,0]+ " tier 1,0" + tier.tiers[0,1]);
			//tier.set_Active();
			if(tier.tier_stage[0] ==false){
				tier.tiers[0,0] = true;
				tier.tiers[0,1] = false;
				tier.active = true;
				tier.tier_stage[0] = true;
			}
			
			
			//tier.set_Active();
			timer2 = 0;
			
			Debug.Log("in spawner" + tier.tiers[0,0]+ " tier 1,0" + tier.tiers[0,1]);
			GameObject new_inst = Instantiate(Shrimp, transform.position, transform.rotation) as GameObject;
			
			shrimp_class.alive.Add(new_inst);
			
			shrimp_class.pop ++;
			shrimp_class.counter[0] ++;
			shrimp_class.death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
		if(Input.GetKeyUp(KeyCode.F4)){// && timer>= Time.deltaTime + timer_limit){
			if(tier.tier_stage[1] ==false){
				tier.tiers[1,0] = true;
				tier.tiers[1,1] = false;
				tier.active = true;
				tier.tier_stage[1] = true;
			}
			timer2 = 0;
			GameObject new_inst = Instantiate(Jellyfish, transform.position, transform.rotation) as GameObject;
			
			jellyfish_class.alive.Add(new_inst);
			
			jellyfish_class.pop ++;
			jellyfish_class.counter[0] ++;
			jellyfish_class.death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
		
		
		if(Input.GetKeyUp(KeyCode.F5)){// && timer>= Time.deltaTime + timer_limit){
			if(tier.tier_stage[0] ==false){
				tier.tiers[0,0] = true;
				tier.tiers[0,1] = false;
				tier.active = true;
				tier.tier_stage[0] = true;
			}
			timer2 = 0;
			GameObject new_inst = Instantiate(Crab, transform.position, transform.rotation) as GameObject;
			
			crab_class.alive.Add(new_inst);
			
			crab_class.pop ++;
			crab_class.counter[0] ++;
			crab_class.death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
		if(Input.GetKeyUp(KeyCode.F6)){// && timer>= Time.deltaTime + timer_limit){
			
			if(tier.tier_stage[0] ==false){
				tier.tiers[0,0] = true;
				tier.tiers[0,1] = false;
				tier.active = true;
				tier.tier_stage[0] = true;
			}
			timer2 = 0;
			GameObject new_inst = Instantiate(Bogue, transform.position, transform.rotation) as GameObject;
			
			bogue_class.alive.Add(new_inst);
			
			bogue_class.pop ++;
			bogue_class.counter[0] ++;
			bogue_class.death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}


	}

	void Start () {



		timer_limit = 2f;

		/*Copepod_details = GameObject.Find ("Copepod_Counter");
		SeaUrchin_details = GameObject.Find ("SeaUrchin_Counter");
		Shrimp_details = GameObject.Find ("Shrimp_Counter");
		Jellyfish_details = GameObject.Find ("Jellyfish_Counter");
		Crab_details = GameObject.Find ("Crab_Counter");
		Starfish_details = GameObject.Find ("Dummy");
		Bogue_details = GameObject.Find ("Bogue_Counter");

		//Squid_details = new Animal_Section_Seach_Urchin()

		Squid_details = GameObject.Find ("Dummy");
		Turtle_details = GameObject.Find ("Dummy");
		Seabass_details = GameObject.Find ("Dummy");
		Octopus_details = GameObject.Find ("Dummy");
		GulperShark_details = GameObject.Find ("Dummy");
		Tuna_details = GameObject.Find ("Dummy");
		Dolphin_details = GameObject.Find ("Dummy");
		Hammerheadshark_details = GameObject.Find ("Dummy");
		plankton = GameObject.FindGameObjectWithTag ("Plankton");*/
//		plankton.GetComponent<Animal_parents> ().pop = 100000000;
		plankton_class.pop = 100000000;
	}

	void tierUpdates(){
		for (int i =0; i <temp_double_pop.Length; i++) {

			temp_double_pop[i] = 0;
		}

		for (int j =0; j<5; j++) {
			Debug.Log("tier start");
			Debug.Log("iter [0,0] value" + tiers[0,0]);
			Debug.Log("iter [0,1] value" + tiers[0,1]);
			while ((tiers[0,0] == true && tiers[0,1] == false) || (tiers[1,0] == true && tiers[1,1] == false)||
			       (tiers[2,0] == true && tiers[2,1] == false) || (tiers[3,0] == true && tiers[3,1] == false)||
			       (tiers[4,0] == true && tiers[4,1] == false)) {
				Debug.Log("tier in while");
				tiers [j, 0] = true; 
				tiers [j, 1] = true;

				if(copepod_class.pop!=0){
					Debug.Log("tier 1");
					for (int i =0; i<copepod_class.pop; i++) {
						GameObject new_creat = Instantiate (Copepod, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
						copepod_class.alive.Add (new_creat);
					
					}
					temp_double_pop[0] += copepod_class.pop;
			
				}

				if(seaurchin_class.pop!=0){
					for (int i =0; i<seaurchin_class.pop; i++) {
						GameObject new_creat = Instantiate (SeaUrchin, seaurchin_spawn.transform.position, seaurchin_spawn.transform.rotation) as GameObject;
						seaurchin_class.alive.Add (new_creat);
					
					}

					temp_double_pop[1] += copepod_class.pop;
		
				}
			}


			while ( (tiers[1,0] == true && tiers[1,1] == false)||(tiers[2,0] == true && tiers[2,1] == false) 
			      ||(tiers[3,0] == true && tiers[3,1] == false)||(tiers[4,0] == true && tiers[4,1] == false)) {
				tiers [j, 0] = true; 
				tiers [j, 1] = true;

				if(crab_class.pop!=0){
					Debug.Log("tier 2");
					for (int i =0; i<crab_class.pop; i++) {
						GameObject new_creat = Instantiate (Crab, crab_spawn.transform.position, crab_spawn.transform.rotation) as GameObject;
						crab_class.alive.Add (new_creat);
						
					}
					temp_double_pop[3] += crab_class.pop;
			
				}
				if(shrimp_class.pop!=0){
					for (int i =0; i<shrimp_class.pop; i++) {
						GameObject new_creat = Instantiate (Shrimp, shrimp_spawn.transform.position, shrimp_spawn.transform.rotation) as GameObject;
					shrimp_class.alive.Add (new_creat);
						
					}
					temp_double_pop[2] += shrimp_class.pop;
				
				}

				if(bogue_class.pop!=0){
					for (int i =0; i<bogue_class.pop; i++) {
						GameObject new_creat = Instantiate (Bogue, bogue_spawn.transform.position, bogue_spawn.transform.rotation) as GameObject;
						bogue_class.alive.Add (new_creat);
						
					}

					temp_double_pop[4] += bogue_class.pop;
				
				}
				

			}

		}


	}

	// Update is called once per frame
	void FixedUpdate () {
		Create_Creature ();

		timer = timer + Time.deltaTime;

		//if (timer >= Time.deltaTime + timer_limit) {
		if (Input.GetKeyUp(KeyCode.Space)) {
			count++;

			if(active == true){
				active = false;
				//		Debug.Log("tier values 1:" +tiers[0,0] + "2: " +tiers[0,1]);
				tierUpdates();
				
				
			}


			//basic resource (present in the game from start - created by system)
	//		plankton = GameObject.FindGameObjectWithTag ("Plankton");
	//		plankton.GetComponentInChildren<Animal_parents> ().pop = plankton.GetComponentInChildren<Animal_Section_Fighterplankton> ().pop + 10;
			
			creatures = GameObject.FindGameObjectsWithTag ("Creatures");
		
			//DEATH---------------------------------------------------------------------------------------------------------------------------------

			foreach (GameObject creature in creatures) {
			//	Debug.Log ("after check");

				//copepod =========================================================================
				if(creature.GetComponent<Animal_parents>().pop !=0){
				if (creature.gameObject.name == "Copepod_Counter"  ) {
		
						copepod_class.Death_Cycle();

				/*	-------------TO GET PREV VERSION
						for (int i =0; i< creature.GetComponent<Animal_Section_Copepod>().death[3]; i++) {
							
							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}
					creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
						creature.GetComponent<Animal_Section_Copepod>().death[3];
					
				/*	death[0] =creature.GetComponent<Animal_Section_Copepod>().death[0];
					death[1]= creature.GetComponent<Animal_Section_Copepod>().death[1];
					death[2]=creature.GetComponent<Animal_Section_Copepod>().death[2];
					death[3]=creature.GetComponent<Animal_Section_Copepod>().death[3];*/

							/*-------------TO GET PREV VERSION

					death[4] =creature.GetComponent<Animal_Section_Copepod>().death[3];

					//counter modify
					for (int i =0; i<=2;i++){
						if(i==0 && creature.GetComponent<Animal_Section_Copepod>().counter[0]>=death[3]){
							creature.GetComponent<Animal_Section_Copepod>().counter[i] = creature.GetComponent<Animal_Section_Copepod>().counter[i] - death[3];
							break;
						}else if (i!=0){
							
							creature.GetComponent<Animal_Section_Copepod>().death[3] = creature.GetComponent<Animal_Section_Copepod>().death[4]-
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
					
					
					for (int i =0; i< creature.GetComponent<Animal_Section_SeaUrchin>().death[3]; i++) {
						
						lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
						Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
						creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
					}
					
					
					creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
						creature.GetComponent<Animal_Section_SeaUrchin>().death[3];
					
				/*	death[0] =creature.GetComponent<Animal_Section_SeaUrchin>().death[0];
					death[1]= creature.GetComponent<Animal_Section_SeaUrchin>().death[1];
					death[2]=creature.GetComponent<Animal_Section_SeaUrchin>().death[2];
					death[3]=creature.GetComponent<Animal_Section_SeaUrchin>().death[3];*/
					death[3] =creature.GetComponent<Animal_Section_SeaUrchin>().death[2];
					
					//counter modify
					for (int i =0; i<=2;i++){
						if(i==0 && creature.GetComponent<Animal_Section_SeaUrchin>().counter[0]>=death[3]){
							creature.GetComponent<Animal_Section_SeaUrchin>().counter[i] = creature.GetComponent<Animal_Section_SeaUrchin>().counter[i] - death[3];
							break;
						}else if (i!=0){
							
							creature.GetComponent<Animal_Section_SeaUrchin>().death[3] = creature.GetComponent<Animal_Section_SeaUrchin>().death[3]-
								creature.GetComponent<Animal_Section_SeaUrchin>().counter[i-1];
							if(creature.GetComponent<Animal_Section_SeaUrchin>().death[3] ==0){
								creature.GetComponent<Animal_Section_SeaUrchin>().counter[i-1] = creature.GetComponent<Animal_Section_SeaUrchin>().death[3];
								
								break;
								
								//	}else if(creature.GetComponent<Animal_Section_Copepod>().death[4] <0){
								//	creature.GetComponent<Animal_Section_Copepod>().counter[i-1] =creature.GetComponent<Animal_Section_Copepod>().death[4] *-1;
								
								
								
							}else if(creature.GetComponent<Animal_Section_SeaUrchin>().death[3] >0){
								creature.GetComponent<Animal_Section_SeaUrchin>().counter[i-1] =0;
								
							}
						}
					}
					
					//counter end
					creature.GetComponent<Animal_Section_SeaUrchin>().shift_Values_death(3);
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
					
					
					for (int i =0; i< creature.GetComponent<Animal_Section_Jellyfish>().death[6]; i++) {
						
						lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
						Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
						creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
					}
					
					
					creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
						creature.GetComponent<Animal_Section_Jellyfish>().death[6];

					
			
					death[6] =creature.GetComponent<Animal_Section_Jellyfish>().death[6];
					//counter modify
					for (int i =0; i<=3;i++){
						if(i==0 && creature.GetComponent<Animal_Section_Jellyfish>().counter[0]>=death[6]){
							creature.GetComponent<Animal_Section_Jellyfish>().counter[i] = creature.GetComponent<Animal_Section_Jellyfish>().counter[i] - death[6];
							break;
						}else if (i!=0){
							
							creature.GetComponent<Animal_Section_Jellyfish>().death[6] = creature.GetComponent<Animal_Section_Jellyfish>().death[6]-
								creature.GetComponent<Animal_Section_Jellyfish>().counter[i-1];
							if(creature.GetComponent<Animal_Section_Jellyfish>().death[6] ==0){
								creature.GetComponent<Animal_Section_Jellyfish>().counter[i-1] = creature.GetComponent<Animal_Section_Jellyfish>().death[7];
								
								break;

							}else if(creature.GetComponent<Animal_Section_Jellyfish>().death[6] >0){
								creature.GetComponent<Animal_Section_Jellyfish>().counter[i-1] =0;
								
							}
						}
					}
					
					//counter end
					creature.GetComponent<Animal_Section_Jellyfish>().shift_Values_death(6);
					

				}


					//Crab ================================================================
					if (creature.gameObject.name == "Crab_Counter") {
						
						
						for (int i =0; i< creature.GetComponent<Animal_Section_Crab>().death[4]; i++) {
							
							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}
						
						
						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
							creature.GetComponent<Animal_Section_Crab>().death[4];
	
						death[5] =creature.GetComponent<Animal_Section_Crab>().death[4];
						
						//counter modify
						for (int i =0; i<=2;i++){
							if(i==0 && creature.GetComponent<Animal_Section_Crab>().counter[0]>=death[4]){
								creature.GetComponent<Animal_Section_Crab>().counter[i] = creature.GetComponent<Animal_Section_Crab>().counter[i] - death[4];
								break;
							}else if (i!=0){
								
								creature.GetComponent<Animal_Section_Crab>().death[4] = creature.GetComponent<Animal_Section_Crab>().death[5]-
									creature.GetComponent<Animal_Section_Crab>().counter[i-1];
								if(creature.GetComponent<Animal_Section_Crab>().death[4] ==0){
									creature.GetComponent<Animal_Section_Crab>().counter[i-1] = creature.GetComponent<Animal_Section_Crab>().death[5];
									
									break;
			
								}else if(creature.GetComponent<Animal_Section_Crab>().death[4] >0){
									creature.GetComponent<Animal_Section_Crab>().counter[i-1] =0;
									
								}
							}
						}
						
						//counter end
						
						creature.GetComponent<Animal_Section_Crab>().shift_Values_death(4);
			

						
					}



					//Bogue ================================================================
					if (creature.gameObject.name == "Bogue_Counter") {
						
						
						for (int i =0; i< creature.GetComponent<Animal_Section_Bogue>().death[6]; i++) {
							
							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}
						
						
						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
							creature.GetComponent<Animal_Section_Bogue>().death[6];
						
						death[6] =creature.GetComponent<Animal_Section_Bogue>().death[6];
						
						//counter modify
						for (int i =0; i<=3;i++){
							if(i==0 && creature.GetComponent<Animal_Section_Crab>().counter[0]>=death[6]){
								creature.GetComponent<Animal_Section_Crab>().counter[i] = creature.GetComponent<Animal_Section_Crab>().counter[i] - death[6];
								break;
							}else if (i!=0){
								
								creature.GetComponent<Animal_Section_Crab>().death[6] = creature.GetComponent<Animal_Section_Crab>().death[6]-
									creature.GetComponent<Animal_Section_Crab>().counter[i-1];
								if(creature.GetComponent<Animal_Section_Crab>().death[6] ==0){
									creature.GetComponent<Animal_Section_Crab>().counter[i-1] = creature.GetComponent<Animal_Section_Crab>().death[6];
									
									break;
									
								}else if(creature.GetComponent<Animal_Section_Crab>().death[6] >0){
									creature.GetComponent<Animal_Section_Crab>().counter[i-1] =0;
									
								}
							}
						}
						
						//counter end
						
						creature.GetComponent<Animal_Section_Crab>().shift_Values_death(6);
						
						
						
					}

			    }
			}

	
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
					
					food = copepod_class.pop;
					pops = creature.GetComponent<Animal_parents> ().pop; //population to feed

					if (pops<= food && pops > 0 && food >0) {
						Debug.Log("feed normal");
							if(copepod_class.pop > pops){

								for (int i =0; i<pops; i++) {
									
								lastindex = copepod_class.alive.Count - 1;
									if(lastindex>=0){
									GameObject.Destroy (copepod_class.alive [lastindex]);
									copepod_class.alive.RemoveAt (lastindex);
									}
								}
					
								copepod_class.pop =  food - pops;

							//-----------------------------NEW--------------------------------------------
							//food_counter = food - pops;

							if(copepod_class.counter[0]>=pops){

								copepod_class.counter[0] = copepod_class.counter[0] - food_counter;


							}else if (copepod_class.counter[0]<pops){
							
								copepod_class.counter[1] =copepod_class.counter[1] - (pops - copepod_class.counter[0]);

								copepod_class.counter[0] = 0;

							}

							for (int i =4; i>=0;i--){


								death_counter = copepod_class.death[i];
								food_counter = food_counter - death_counter ;

								if(food_counter ==0){
									copepod_class.death[i] = 0;
									break;
									
								} else	if(food_counter <0){
									copepod_class.death[i] = food_counter *-1;
									break;
								}
								
								if(copepod_class.death[i] <0){
									copepod_class.death[i] =	copepod_class.death[i] *-1;
								}
	
							}
						}

							}else	if (pops > food && pops >0 && food >0) {
						Debug.Log("feed with few sources");

						copepod_class.pop = food - pops;
						
						for (int i =0; i<pops-food; i++) {

				
							if(creature.GetComponent<Animal_parents> ().alive.Count >0){
								lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
								if(lastindex>=0){
								Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
								creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
								}
							}

							
							if(copepod_class.alive.Count >0){
								GameObject.Destroy (copepod_class.alive [0]);
								copepod_class.alive.RemoveAt (0);

						}

						}

						copepod_class.pop = 0;
						copepod_class.counter[0] = 0;
						copepod_class.counter[1] = 0;
					//	Copepod_details.GetComponent<Animal_Section_Copepod> ().zeroDeath(	Copepod_details.GetComponent<Animal_Section_Copepod> ().death_limit);
							copepod_class.zeroDeath();
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
							GameObject.Destroy (shrimp_class.alive [lastindex]);
							shrimp_class.alive.RemoveAt (lastindex);
						}
						//creature.GetComponent<Animal_Section_Shrimp> ().zeroDeath(creature.GetComponent<Animal_Section_Shrimp> ().death_limit);
							creature.GetComponent<Animal_Section_Shrimp> ().zeroDeath();

						//creature.GetComponent<Animal_Section_Shrimp> ().zeroCounter(creature.GetComponent<Animal_Section_Shrimp> ().feed_ratio);
							creature.GetComponent<Animal_Section_Shrimp> ().zeroCounter();
						creature.GetComponent<Animal_parents> ().pop = 0;
					}
					
					}


				//JELLYFISH ================================================================================================

				if (creature.gameObject.name == "Jellyfish_Counter") {
					
					food = copepod_class.pop +shrimp_class.pop + bogue_class.pop;
					pops = creature.GetComponent<Animal_parents> ().pop; //population to feed
	//				eating_counter = creature.GetComponent<Animal_Section_Jellyfish> ().Feed_items();
						Debug.Log ("eating_counter " + eating_counter);

					if(eating_counter == 10)
						Debug.Log("invalid results");

					if(eating_counter == 7){

						Debug.Log("zero");
						
						for (int i =0; i<pops; i++) {
							
							lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (jellyfish_class.alive [lastindex]);
							jellyfish_class.alive.RemoveAt (lastindex);
						}
					//	Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().zeroDeath(Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().death_limit);
							jellyfish_class.zeroDeath();

						//	Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().zeroCounter(Jellyfish_details.GetComponent<Animal_Section_Jellyfish> ().repro_ratio);
							jellyfish_class.zeroCounter();
								jellyfish_class.pop = 0;
						

						
					}else if (eating_counter <=3){
							Debug.Log("eating ");
					for(int i =0; i <=eating_counter;i++){
						if(i == 0 ){

							if(eating_counter==1 || eating_counter ==2 || eating_counter ==3 || (eating_counter ==0 && 
								jellyfish_class.pop == shrimp_class.pop) ){
										Debug.Log("eating in 0");
										for (int j =0; j<shrimp_class.pop; j++) {
											
											lastindex = shrimp_class.alive.Count - 1;
											
											if(lastindex <= -1)
												break;
											
											Destroy (shrimp_class.alive [lastindex]);
											shrimp_class.alive.RemoveAt (lastindex);
											
										}

									//	Shrimp_details.GetComponent<Animal_Section_Shrimp> ().zeroDeath(Shrimp_details.GetComponent<Animal_Section_Shrimp> ().death_limit);
										shrimp_class.zeroDeath();

										//Shrimp_details.GetComponent<Animal_Section_Shrimp> ().zeroCounter(Shrimp_details.GetComponent<Animal_Section_Shrimp> ().repro_ratio);
										shrimp_class.zeroCounter();

										food_counter =  jellyfish_class.pop - shrimp_class.pop  ;
										shrimp_class.pop = 0;
									


									} else if (eating_counter ==0 && jellyfish_class.pop < shrimp_class.pop){
										food_counter =  shrimp_class.pop -jellyfish_class.pop  ;


										for (int j =0; j<food_counter; j++) {
											
											lastindex = shrimp_class.alive.Count - 1;
											
											if(lastindex <= -1)
												break;
											
											Destroy (shrimp_class.alive [lastindex]);
											shrimp_class.alive.RemoveAt (lastindex);
											
										}


									shrimp_class.reduce_Death(food_counter, shrimp_class.death_limit);
									shrimp_class.reduce_Count(food_counter, shrimp_class.repro_ratio);
									shrimp_class.pop = food_counter;
								}


						}
						if(i == 1){
									Debug.Log(" i = 1");
									Debug.Log("food counter " + food_counter);
									Debug.Log("copeopd pop " + copepod_class.pop);
							if( eating_counter ==2 || eating_counter ==3 || (eating_counter ==1 && food_counter == copepod_class.pop) ){
										Debug.Log("eating in 1 eqaul or smaller");
										
										for (int j =0; j<copepod_class.pop; j++) {
											
											lastindex = copepod_class.alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (copepod_class.alive [lastindex]);
											copepod_class.alive.RemoveAt (lastindex);
										}



										//Copepod_details.GetComponent<Animal_Section_Copepod> ().zeroDeath(Copepod_details.GetComponent<Animal_Section_Copepod> ().death_limit);
										copepod_class.zeroDeath();

										//Copepod_details.GetComponent<Animal_Section_Copepod> ().zeroCounter(Copepod_details.GetComponent<Animal_Section_Copepod> ().repro_ratio);
										copepod_class.zeroCounter();

										food_counter = food_counter - copepod_class.pop;
										copepod_class.pop = 0;

							} else if (eating_counter ==1 &&food_counter < shrimp_class.pop){
										Debug.Log("eating 1 remover larger");
										food_counter = shrimp_class.pop -food_counter  ;
									

										for (int j =0; j<food_counter; j++) {
											
											lastindex = copepod_class.alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (copepod_class.alive [lastindex]);
											copepod_class.alive.RemoveAt (lastindex);
										}
									//	food_counter =  Copepod_details.GetComponent<Animal_parents> ().pop -Jellyfish_details.GetComponent<Animal_parents> ().pop  ;
										
										copepod_class.reduce_Death(food_counter, copepod_class.death_limit);
										copepod_class.reduce_Count(food_counter, copepod_class.repro_ratio);
										copepod_class.pop = food_counter;
								}

							}

							if(i == 2){
			//Bogue_details.GetComponent<Animal_Section_Copepod> ().zeroDeath(Bogue_details.GetComponent<Animal_Section_Copepod> ().death_limit);
							//	Bogue_details.GetComponent<Animal_Section_Copepod> ().zeroCounter(Bogue_details.GetComponent<Animal_Section_Copepod> ().repro_ratio);
								//Bogue_details.GetComponent<Animal_parents> ().pop = Shrimp_details.GetComponent<Animal_parents> ().pop - pops;
								

									if(  eating_counter ==3 || (eating_counter ==2 && food_counter == bogue_class.pop) ){

										for (int j =0; j<bogue_class.pop; j++) {
											
											lastindex = Bogue.GetComponent<Animal_parents> ().alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (bogue_class.alive [lastindex]);
											bogue_class.alive.RemoveAt (lastindex);
										}



									//	Bogue_details.GetComponent<Animal_Section_Bogue> ().zeroDeath(Bogue_details.GetComponent<Animal_Section_Bogue> ().death_limit);
										bogue_class.zeroDeath();

									//	Bogue_details.GetComponent<Animal_Section_Bogue> ().zeroCounter(Bogue_details.GetComponent<Animal_Section_Bogue> ().repro_ratio);
										bogue_class.zeroCounter();

										food_counter = food_counter - bogue_class.pop;
										bogue_class.pop = 0;
										
									} else if (eating_counter ==2 &&food_counter < shrimp_class.pop){
										
										food_counter = bogue_class.pop -food_counter  ;


										for (int j =0; j<food_counter; j++) {
											
											lastindex = Bogue.GetComponent<Animal_parents> ().alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (bogue_class.alive [lastindex]);
											bogue_class.alive.RemoveAt (lastindex);
										}
										//	food_counter =  Copepod_details.GetComponent<Animal_parents> ().pop -Jellyfish_details.GetComponent<Animal_parents> ().pop  ;
										
										bogue_class.reduce_Death(food_counter, bogue_class.death_limit);
										bogue_class.reduce_Count(food_counter, bogue_class.repro_ratio);
										bogue_class.pop = food_counter;
									}
	
							}

							if(i == 3){
								
								
								for (int j =0; j<food_counter; j++) {
									
									lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
									Destroy (jellyfish_class.alive [lastindex]);
									jellyfish_class.alive.RemoveAt (lastindex);
								}
									jellyfish_class.reduce_Death(food_counter, jellyfish_class.death_limit);
									jellyfish_class.reduce_Count(food_counter, jellyfish_class.repro_ratio);
									jellyfish_class.pop = food_counter;
								
								
							}
							
							

					}

				}
			}
					//Crab ================================================================================================

					if (creature.gameObject.name == "Crab_Counter") {
						
						food = seaurchin_class.pop;
						pops = creature.GetComponent<Animal_parents> ().pop; //population to feed
						
						if (pops<= food && pops > 0 && food >0) {
							Debug.Log("feed normal");
							if(seaurchin_class.pop > pops){
								
								for (int i =0; i<pops; i++) {
									
									lastindex = seaurchin_class.alive.Count - 1;
									Destroy (seaurchin_class.alive [lastindex]);
									seaurchin_class.alive.RemoveAt (lastindex);
								}
								
								seaurchin_class.pop =  food - pops;
								
								//-----------------------------NEW--------------------------------------------
								//food_counter = food - pops;
								
								if(seaurchin_class.counter[0]>=pops){
									
									seaurchin_class.counter[0] = seaurchin_class.counter[0] - food_counter;
									
									
								}else if (seaurchin_class.counter[0]<pops){
									
									seaurchin_class.counter[1] =seaurchin_class.counter[1] -(pops - seaurchin_class.counter[0]);
									
									seaurchin_class.counter[0] = 0;
									
								}
								
								for (int i =3; i>=0;i--){
									
									
									death_counter = seaurchin_class.death[i];
									food_counter = food_counter - death_counter ;
									
									if(food_counter ==0){
										seaurchin_class.death[i] = 0;
										break;
										
									} else	if(food_counter <0){
										seaurchin_class.death[i] = food_counter *-1;
										break;
									}
									
									if(seaurchin_class.death[i] <0){
										seaurchin_class.death[i] =	seaurchin_class.death[i] *-1;
									}
									
								}
							}
							
						}else	if (pops > food && pops >0 && food >0) {
							Debug.Log("feed with few sources");
							
							seaurchin_class.pop = food - pops;
							
							for (int i =0; i<pops-food; i++) {
								
								
								if(creature.GetComponent<Animal_parents> ().alive.Count >0){
									lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
									if(lastindex>=0){
										Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
										creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
									}
								}
								
								
								if(seaurchin_class.alive.Count >0){
									Destroy (seaurchin_class.alive [0]);
									seaurchin_class.alive.RemoveAt (0);
									
								}
								
							}
							
							seaurchin_class.pop = 0;
							seaurchin_class.counter[0] = 0;
							seaurchin_class.counter[1] = 0;


						//	SeaUrchin_details.GetComponent<Animal_Section_Copepod> ().zeroDeath(	SeaUrchin_details.GetComponent<Animal_Section_SeaUrchin> ().death_limit);
							seaurchin_class.zeroDeath();

							food_counter = food - pops;
							for(int i =0; i <=2; i++){
								
								creature.GetComponent<Animal_Section_Crab> ().counter[i] = creature.GetComponent<Animal_Section_Crab> ().counter[i] -
									food_counter;
								
								if(creature.GetComponent<Animal_Section_Crab> ().counter[i]<0)
									creature.GetComponent<Animal_Section_Crab> ().counter[i] = creature.GetComponent<Animal_Section_Crab> ().counter[i]*-1;
								
								food_counter = food_counter - 	creature.GetComponent<Animal_Section_Crab> ().counter[i];
								
								
								
								
							}
							creature.GetComponent<Animal_parents> ().pop = food;
							creature.GetComponent<Animal_Section_Crab> ().counter[0] = creature.GetComponent<Animal_parents> ().pop;
							creature.GetComponent<Animal_Section_Crab> ().counter[1] = 0;
							creature.GetComponent<Animal_Section_Crab> ().counter[2] = 0;
							
							
							Debug.Log("pops " + pops);
							Debug.Log("food "+food);
							creature.GetComponent<Animal_Section_Crab>().reduce_Death(pops-food,creature.GetComponent<Animal_Section_Crab>().death_limit );
							
							
							
						}else if(food <=0 && pops>0){
							Debug.Log("zero");
							
							for (int i =0; i<pops; i++) {
								
								lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
								Debug.Log("zero2");
								if(lastindex>=0){
								Destroy (crab_class.alive [lastindex]);
								crab_class.alive.RemoveAt (lastindex);
									Debug.Log("zero3");
								}
							}
							Debug.Log("zero4");
						//	creature.GetComponent<Animal_Section_Crab> ().zeroDeath(creature.GetComponent<Animal_Section_Crab> ().death_limit);
							creature.GetComponent<Animal_Section_Crab> ().zeroDeath();

							//creature.GetComponent<Animal_Section_Crab> ().zeroCounter(creature.GetComponent<Animal_Section_Crab> ().feed_ratio);
							creature.GetComponent<Animal_Section_Crab> ().zeroCounter();

							creature.GetComponent<Animal_parents> ().pop = 0;
						}
						
					}



					//JELLYFISH ================================================================================================
					
					if (creature.gameObject.name == "Bogue_Counter") {
						
						food = copepod_class.pop +shrimp_class.pop +bogue_class.pop;
						pops = creature.GetComponent<Animal_parents> ().pop; //population to feed
				//		eating_counter = creature.GetComponent<Animal_Section_Bogue> ().Feed_items();
						Debug.Log ("eating_counter " + eating_counter);
						
						if(eating_counter == 10)
							Debug.Log("invalid results");
						
						if(eating_counter == 7){
							
							Debug.Log("zero");
							
							for (int i =0; i<pops; i++) {
								
								lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
								Destroy (bogue_class.alive [lastindex]);
								bogue_class.alive.RemoveAt (lastindex);
							}
						//	Bogue_details.GetComponent<Animal_Section_Bogue> ().zeroDeath(Bogue_details.GetComponent<Animal_Section_Bogue> ().death_limit);
							bogue_class.zeroDeath();

						//	Bogue_details.GetComponent<Animal_Section_Bogue> ().zeroCounter(Bogue_details.GetComponent<Animal_Section_Bogue> ().repro_ratio);
							bogue_class.zeroCounter();

							bogue_class.pop = 0;
							
							
							
						}else if (eating_counter <=3){
							Debug.Log("eating ");
							for(int i =0; i <=eating_counter;i++){
								if(i == 0 ){
									
									if(eating_counter==1 || eating_counter ==2 ||  (eating_counter ==0 && bogue_class.pop == copepod_class.pop) ){
										Debug.Log("eating in 0");
										for (int j =0; j<copepod_class.pop; j++) {
											
											lastindex = copepod_class.alive.Count - 1;
											
											if(lastindex <= -1)
												break;
											
											Destroy (copepod_class.alive [lastindex]);
											copepod_class.alive.RemoveAt (lastindex);
											
										}
										
									//	Copepod_details.GetComponent<Animal_Section_Copepod> ().zeroDeath(Copepod_details.GetComponent<Animal_Section_Shrimp> ().death_limit);
										copepod_class.zeroDeath();

									//	Copepod_details.GetComponent<Animal_Section_Copepod> ().zeroCounter(Copepod_details.GetComponent<Animal_Section_Shrimp> ().repro_ratio);
										copepod_class.zeroCounter();

										food_counter =  bogue_class.pop - copepod_class.pop  ;
										copepod_class.pop = 0;
										
										
										
									} else if (eating_counter ==0 && bogue_class.pop < copepod_class.pop){
										food_counter =  copepod_class.pop - bogue_class.pop  ;
										
										
										for (int j =0; j<food_counter; j++) {
											
											lastindex = copepod_class.alive.Count - 1;
											
											if(lastindex <= -1)
												break;
											
											Destroy (copepod_class.alive [lastindex]);
											copepod_class.alive.RemoveAt (lastindex);
											
										}
										copepod_class.reduce_Death(food_counter, copepod_class.death_limit);
										copepod_class.reduce_Count(food_counter, copepod_class.repro_ratio);
										copepod_class.pop = food_counter;
									}
									
									
								}
								if(i == 1){
									Debug.Log(" i = 1");
									Debug.Log("food counter " + food_counter);
									Debug.Log("shrimp pop " + shrimp_class.pop);
									if( eating_counter ==2 ||(eating_counter ==1 && food_counter == shrimp_class.pop) ){
										Debug.Log("eating in 1 eqaul or smaller");
										
										for (int j =0; j<shrimp_class.pop; j++) {
											
											lastindex = shrimp_class.alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (shrimp_class.alive [lastindex]);
											shrimp_class.alive.RemoveAt (lastindex);
										}

										
									//	Shrimp_details.GetComponent<Animal_Section_Shrimp> ().zeroDeath(Shrimp_details.GetComponent<Animal_Section_Shrimp> ().death_limit);
										shrimp_class.zeroDeath();

										//Shrimp_details.GetComponent<Animal_Section_Shrimp> ().zeroCounter(Shrimp_details.GetComponent<Animal_Section_Shrimp> ().repro_ratio);
									
										shrimp_class.zeroCounter();

										food_counter = food_counter - shrimp_class.pop;
										shrimp_class.pop = 0;
										
									} else if (eating_counter ==1 &&food_counter < shrimp_class.pop){
										Debug.Log("eating 1 remover larger");
										food_counter = shrimp_class.pop -food_counter  ;
										
										
										for (int j =0; j<food_counter; j++) {
											
											lastindex = shrimp_class.alive.Count - 1;
											if(lastindex <= -1)
												break;
											Destroy (shrimp_class.alive [lastindex]);
											shrimp_class.alive.RemoveAt (lastindex);
										}
										//	food_counter =  Copepod_details.GetComponent<Animal_parents> ().pop -Jellyfish_details.GetComponent<Animal_parents> ().pop  ;
										
										shrimp_class.reduce_Death(food_counter, shrimp_class.death_limit);
										shrimp_class.reduce_Count(food_counter, shrimp_class.repro_ratio);
										shrimp_class.pop = food_counter;
									}
									
								}

								
								if(i == 2){
									
									
									for (int j =0; j<food_counter; j++) {
										
										lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;

										Destroy (Bogue.GetComponent<Animal_parents> ().alive [lastindex]);
										bogue_class.alive.RemoveAt (lastindex);
									}
									bogue_class.reduce_Death(food_counter, bogue_class.death_limit);
									bogue_class.reduce_Count(food_counter, bogue_class.repro_ratio);
									bogue_class.pop = food_counter;
									
									
								}
								
								
								
							}
							
						}
					}



		}
	}
			//REPRODUCTION CYCLE ----------------------------------------------------------------------------------------------------------------------

			foreach (GameObject creature in creatures) {
				if(creature.GetComponent<Animal_parents>().pop !=0){

					if (creature.gameObject.name == "Bogue_Counter") {
						if (creature.GetComponent<Animal_parents> ().pop > 0) {
							
							for (int i =0; i<creature.GetComponent<Animal_Section_Bogue>().counter[2]; i++) {
								GameObject new_creat = Instantiate (Bogue, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
								creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
								
							}
							
							creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
								creature.GetComponent<Animal_Section_Crab> ().counter[2];
							
							prev_count[0] = creature.GetComponent<Animal_Section_Bogue> ().counter[0];
							prev_count[1] = creature.GetComponent<Animal_Section_Bogue> ().counter[1];
							prev_count[2] = creature.GetComponent<Animal_Section_Bogue> ().counter[2];
							//prev_count[3] = creature.GetComponent<Animal_Section_Bogue> ().counter[3];
							creature.GetComponent<Animal_Section_Bogue> ().counter[0] = prev_count[2] * 2;
							creature.GetComponent<Animal_Section_Bogue> ().counter[1] = prev_count[0];
							creature.GetComponent<Animal_Section_Bogue> ().counter[2] = prev_count[1];
							//creature.GetComponent<Animal_Section_Bogue> ().counter[3] = prev_count[2];
							creature.GetComponent<Animal_Section_Bogue> ().death[0] = prev_count[2] ;
						}
						
					}

					
					if (creature.gameObject.name == "Crab_Counter") {
						if (creature.GetComponent<Animal_parents> ().pop > 0) {
							
							for (int i =0; i<creature.GetComponent<Animal_Section_Crab>().counter[1]; i++) {
								GameObject new_creat = Instantiate (Crab, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
								creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
								
							}
							
							creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
								creature.GetComponent<Animal_Section_Crab> ().counter[2];
							
							prev_count[0] = creature.GetComponent<Animal_Section_Crab> ().counter[0];
							prev_count[1] = creature.GetComponent<Animal_Section_Crab> ().counter[1];
						//	prev_count[2] = creature.GetComponent<Animal_Section_Crab> ().counter[2];
							
							creature.GetComponent<Animal_Section_Crab> ().counter[0] = prev_count[1] * 2;
							creature.GetComponent<Animal_Section_Crab> ().counter[1] = prev_count[0];
							//creature.GetComponent<Animal_Section_Crab> ().counter[2] = prev_count[1];
							creature.GetComponent<Animal_Section_Crab> ().death[0] = prev_count[1] ;
						}
						
					}



				if (creature.gameObject.name == "Jellyfish_Counter") {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {
						
						for (int i =0; i<creature.GetComponent<Animal_Section_Jellyfish>().counter[2]; i++) {
							GameObject new_creat = Instantiate (Jellyfish, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
							creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
							
						}
						
						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
							creature.GetComponent<Animal_Section_Jellyfish> ().counter[3];
						
						prev_count[0] = creature.GetComponent<Animal_Section_Jellyfish> ().counter[0];
						prev_count[1] = creature.GetComponent<Animal_Section_Jellyfish> ().counter[1];
						prev_count[2] = creature.GetComponent<Animal_Section_Jellyfish> ().counter[2];
					//	prev_count[3] = creature.GetComponent<Animal_Section_Jellyfish> ().counter[3];
						
						creature.GetComponent<Animal_Section_Jellyfish> ().counter[0] = prev_count[2] * 2;
						creature.GetComponent<Animal_Section_Jellyfish> ().counter[1] = prev_count[0];
						creature.GetComponent<Animal_Section_Jellyfish> ().counter[2] = prev_count[1];
						//creature.GetComponent<Animal_Section_Jellyfish> ().counter[3] = prev_count[2];

						creature.GetComponent<Animal_Section_Jellyfish> ().death[0] = prev_count[2] ;
					}
					
				}








				if (creature.gameObject.name == "Shrimp_Counter") {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {
						
						for (int i =0; i<creature.GetComponent<Animal_Section_Shrimp>().counter[1]; i++) {
							GameObject new_creat = Instantiate (Shrimp, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
							creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
							
						}

						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
						creature.GetComponent<Animal_Section_Shrimp> ().counter[1];
						
						prev_count[0] = creature.GetComponent<Animal_Section_Shrimp> ().counter[0];
						prev_count[1] = creature.GetComponent<Animal_Section_Shrimp> ().counter[1];
					//	prev_count[2] = creature.GetComponent<Animal_Section_Shrimp> ().counter[2];

						creature.GetComponent<Animal_Section_Shrimp> ().counter[0] = prev_count[1] * 2;
						creature.GetComponent<Animal_Section_Shrimp> ().counter[1] = prev_count[0];
						//creature.GetComponent<Animal_Section_Shrimp> ().counter[2] = prev_count[1];
						creature.GetComponent<Animal_Section_Shrimp> ().death[0] = prev_count[1] ;
					}
					
				}
				



				if (creature.gameObject.name == "SeaUrchin_Counter") {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {
						
						for (int i =0; i<creature.GetComponent<Animal_Section_SeaUrchin>().counter[0]; i++) {
							GameObject new_creat = Instantiate (SeaUrchin, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
							creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
							
						}
						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
							creature.GetComponent<Animal_Section_SeaUrchin> ().counter[0];
						
						prev_count[0] = creature.GetComponent<Animal_Section_SeaUrchin> ().counter[0];
					//	prev_count[1] = creature.GetComponent<Animal_Section_SeaUrchin> ().counter[1];
						
						creature.GetComponent<Animal_Section_SeaUrchin> ().counter[0] = prev_count[0] * 2;
					//	creature.GetComponent<Animal_Section_SeaUrchin> ().counter[1] = prev_count[0];
						creature.GetComponent<Animal_Section_SeaUrchin> ().death[0] = prev_count[0] ;
					}
					
				}
				

				if (creature.gameObject.name == "Copepod_Counter" ) {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {

						for (int i =0; i<creature.GetComponent<Animal_Section_Copepod>().counter[0]; i++) {
							GameObject new_creat = Instantiate (Copepod, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
							creature.GetComponent<Animal_parents> ().alive.Add (new_creat);
			
						}

						creature.GetComponent<Animal_Section_Copepod>().death[0] = creature.GetComponent<Animal_Section_Copepod>().counter[0];
						creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop +
							creature.GetComponent<Animal_Section_Copepod> ().counter[0];

						prev_count[0] = creature.GetComponent<Animal_Section_Copepod> ().counter[0];
						//prev_count[1] = creature.GetComponent<Animal_Section_Copepod> ().counter[1];

						creature.GetComponent<Animal_Section_Copepod> ().counter[0] = prev_count[0] * 2;
					//	creature.GetComponent<Animal_Section_Copepod> ().counter[1] = prev_count[0];
						creature.GetComponent<Animal_Section_Copepod> ().death[0] = prev_count[0] ;

					}

				}

			}
			}



			//------------------------UPDATES OF DOUBLING -------------------------
			if ((tiers[0,0] == true && tiers[0,1] == true) || (tiers[1,0] == true && tiers[1,1] == true)||
			       (tiers[2,0] == true && tiers[2,1] == true) || (tiers[3,0] == true && tiers[3,1] == true)||
			       (tiers[4,0] == true && tiers[4,1] == true)) {
				tiers [0, 1] = false;
				tiers [0, 0] = false;

				Debug.Log("in second part, area 1");
				copepod_class.death [0] += temp_double_pop[0];
				copepod_class.counter [0] += temp_double_pop[0];
				copepod_class.pop +=temp_double_pop[0];

				seaurchin_class.death [0] += temp_double_pop[1];
				seaurchin_class.counter [0] += temp_double_pop[1];
				seaurchin_class.pop +=temp_double_pop[1];



			}
			if ( (tiers[1,0] == true && tiers[1,1] == true)||(tiers[2,0] == true && tiers[2,1] == true) 
			    ||(tiers[3,0] == true && tiers[3,1] == true)||(tiers[4,0] == true && tiers[4,1] == true)) {
				tiers [1, 1] = false;
				tiers [1, 0] = false;
				Debug.Log("in second part, area 2");
				copepod_class.death [0] += temp_double_pop[0];
				copepod_class.counter [0] += temp_double_pop[0];
				copepod_class.pop +=temp_double_pop[0];
				
				seaurchin_class.death [0] += temp_double_pop[1];
				seaurchin_class.counter [0] += temp_double_pop[1];
				seaurchin_class.pop +=temp_double_pop[1];


				shrimp_class.death [0] += temp_double_pop[2];
				shrimp_class.counter [0] += temp_double_pop[2];
				shrimp_class.pop +=temp_double_pop[2];
				
				crab_class.death [0] += temp_double_pop[3];
				crab_class.counter [0] += temp_double_pop[3];
				crab_class.pop +=temp_double_pop[3];

				bogue_class.death [0] += temp_double_pop[4];
				bogue_class.counter [0] += temp_double_pop[4];
				bogue_class.pop +=temp_double_pop[4];


			}


			timer = 0;


			
		}


	}
}

