using UnityEngine;
using System.Collections;
using System;

public class Spawn_Kill_process10 : MonoBehaviour {




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
	/*public GameObject Starfish;
	public GameObject Squid;
	public GameObject Octopus;
	public GameObject Seabass;
	public GameObject Turtle;
	public GameObject GulperShark;
	public GameObject Tuna;
	public GameObject Dolphin;
	public GameObject HammerheadShark;*/
	
	
/*	public GameObject copepod_spawn;
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
	public GameObject hammerhead_spawn;*/
	
	//for death distribution (if not fed)
	public int percent;
	public int percent2;
	public int num1;
	public int num2;
	
	int [] prev_count = new int[8]; // for reproduction
	
	int[] death = new int[17];
	
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
	public Animal_parents parents = new Animal_parents();
	
	
	public bool[,] tiers = new bool[5, 2];
	public bool [] tier_stage = new bool [4];
	public bool active = false;
	
	public int count =0 ;
	
	public int[] temp_double_pop = new int[13];
	public float timer2;
	public Vector3 pos;
	public Vector3 rotate;


	public void set_Active(){
		
		active = true;
		
	}
	void Awake(){
		for (int i =0; i <tier_stage.Length; i++) {
			
			tier_stage[i] = true;
			
		}
		copepod_class.creature_object = (Copepod) as GameObject;
		parents.creatures.Add (SeaUrchin);
		parents.creatures.Add (Shrimp);
		parents.creatures.Add (Crab);
		parents.creatures.Add (Bogue);
		//parents.creatures.Add (Copepod);
		parents.creatures.Add (Jellyfish);
		/*parents.creatures.Add (Copepod);
		parents.creatures.Add (Copepod);
		parents.creatures.Add (Copepod);
		parents.creatures.Add (Copepod);
		parents.creatures.Add (Copepod);
		parents.creatures.Add (Copepod);
		parents.creatures.Add (Copepod);
		parents.creatures.Add (Copepod);*/




		
		
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
		
		}
		
		if(Input.GetKeyUp(KeyCode.F2)){// && timer>= Time.deltaTime + timer_limit){
		
			timer2 = 0;
			GameObject new_inst = Instantiate(SeaUrchin, transform.position, transform.rotation) as GameObject;
			
			seaurchin_class.alive.Add(new_inst);
			
			seaurchin_class.pop ++;
			seaurchin_class.counter[0] ++;
			seaurchin_class.death[0]++;

		}
		
		if(Input.GetKeyUp(KeyCode.F3) ){//&& timer>= Time.deltaTime + timer_limit){

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

		}
		
		
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
						GameObject new_creat = Instantiate (Copepod, transform.position, transform.rotation) as GameObject;
						copepod_class.alive.Add (new_creat);
						
					}
					temp_double_pop[0] += copepod_class.pop;
					
				}
				
				if(seaurchin_class.pop!=0){
					for (int i =0; i<seaurchin_class.pop; i++) {
						GameObject new_creat = Instantiate (SeaUrchin, transform.position, transform.rotation) as GameObject;
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
						GameObject new_creat = Instantiate (Crab, transform.position, transform.rotation) as GameObject;
						crab_class.alive.Add (new_creat);
						
					}
					temp_double_pop[3] += crab_class.pop;
					
				}
				if(shrimp_class.pop!=0){
					for (int i =0; i<shrimp_class.pop; i++) {
						GameObject new_creat = Instantiate (Shrimp, transform.position, transform.rotation) as GameObject;
						shrimp_class.alive.Add (new_creat);
						
					}
					temp_double_pop[2] += shrimp_class.pop;
					
				}
				
				if(bogue_class.pop!=0){
					for (int i =0; i<bogue_class.pop; i++) {
						GameObject new_creat = Instantiate (Bogue, transform.position, transform.rotation) as GameObject;
						bogue_class.alive.Add (new_creat);
						
					}
					
					temp_double_pop[4] += bogue_class.pop;
					
				}
				
				
			}
			
		}
		
		
	}
	
	void Start () {
		
		
		
		timer_limit = 2f;
		
	
		plankton_class.pop = 100000000;
	}

	// Update is called once per frame
	void FixedUpdate () {

		Create_Creature ();
		
		timer = timer + Time.deltaTime;
		DebugStreamer.AddMessage(count);
		DebugStreamer.AddMessage(copepod_class.pop);
		//if (timer >= Time.deltaTime + timer_limit) {
		if (Input.GetKeyUp (KeyCode.Space)) {
			count++;
			
			if (active == true) {
				active = false;
			
				tierUpdates ();
				
				
			}

			creatures = GameObject.FindGameObjectsWithTag ("Creatures");
			
			//DEATH---------------------------------------------------------------------------------------------------------------------------------
			
			for (int i =0; i <15; i++) {
					Debug.Log ("after check");
				
				//copepod =========================================================================
				//	if(creature.GetComponent<Animal_parents>().pop !=0){
				if (i == 0 && copepod_class.pop != 0) {

					Debug.Log("death");
					Debug.Log("objects in array" + copepod_class.alive[0]);

					copepod_class.Death_Cycle (0);



				}

			}

			//Feeding---------------------------------------------------------------------------------------------------------------------------------
			for (int i =0; i <15; i++) {
				//	Debug.Log ("after check");
				
				//copepod =========================================================================
				//	if(creature.GetComponent<Animal_parents>().pop !=0){
				if (i == 0 && copepod_class.pop != 0) {
					Debug.Log("feed");
					copepod_class.Feeding_Cycle(plankton_class.pop);
					
					
					
				}
				
			}

			//Repro---------------------------------------------------------------------------------------------------------------------------------
			for (int i =0; i <15; i++) {

				//	Debug.Log ("after check");
				
				//copepod =========================================================================
				//	if(creature.GetComponent<Animal_parents>().pop !=0){
				if (i == 0 && copepod_class.pop != 0) {
					Debug.Log("repro");
					copepod_class.Repro_Cycle (pos,rotate);
					
					
					
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


		}

	
	}
}
