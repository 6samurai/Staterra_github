﻿using UnityEngine;
using System.Collections;

public class Spawn_Kill_processv : MonoBehaviour {

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

	public GameObject copepod_spawn;
	public GameObject seaurchin_spawn;
	public GameObject shrimp_spawn;
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



	void Start () {
		timer_limit = 2f;

		Copepod_details = GameObject.Find ("Copepod_Counter");
		SeaUrchind_details = GameObject.Find ("SeaUrchin_Counter");
		Plankton_details = GameObject.Find ("Plankton");
		Shrimp_details = GameObject.Find ("Shrimp_Counter");
		Jellyfish_details = GameObject.Find ("Dummy");
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

		if (timer >= Time.deltaTime + timer_limit) {
			//basic resource (present in the game from start - created by system)
			plankton = GameObject.FindGameObjectWithTag ("Plankton");
			plankton.GetComponentInChildren<Animal_parents> ().pop = plankton.GetComponentInChildren<Animal_Section_Fighterplankton> ().pop + 10;
			
			creatures = GameObject.FindGameObjectsWithTag ("Creatures");
		
			//death 

			foreach (GameObject creature in creatures) {
				Debug.Log ("after check");
				
				if (creature.gameObject.name == "Copepod_Counter") {
					
				
						for (int i =0; i< creature.GetComponent<Animal_Section_Copepod>().death[4]; i++) {
							
							int lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}
						
				
					creature.GetComponent<Animal_parents> ().pop = creature.GetComponent<Animal_parents> ().pop  - 
						creature.GetComponent<Animal_Section_Copepod>().death[4];
					
					death[0] =creature.GetComponent<Animal_Section_Copepod>().death[0];
					death[1]= creature.GetComponent<Animal_Section_Copepod>().death[1];
					death[2]=creature.GetComponent<Animal_Section_Copepod>().death[2];
					death[3]=creature.GetComponent<Animal_Section_Copepod>().death[3];
					death[4] =creature.GetComponent<Animal_Section_Copepod>().death[4];

					//counter modify
					for (int i =0; i<=2;i++){
						if(i==0 && creature.GetComponent<Animal_Section_Copepod>().counter[0]>=creature.GetComponent<Animal_Section_Copepod>().death[4]){
							creature.GetComponent<Animal_Section_Copepod>().counter[i] = creature.GetComponent<Animal_Section_Copepod>().counter[i] -
								creature.GetComponent<Animal_Section_Copepod>().death[4];
							break;
						}else{
							
							creature.GetComponent<Animal_Section_Copepod>().death[4] -= creature.GetComponent<Animal_Section_Copepod>().counter[i-1];
							if(creature.GetComponent<Animal_Section_Copepod>().death[4] <=0){
								creature.GetComponent<Animal_Section_Copepod>().counter[i-1] = creature.GetComponent<Animal_Section_Copepod>().death[4];

								break;
						
							}
						}
					}
				/*	if(creature.GetComponent<Animal_Section_Copepod>().counter[0]>=creature.GetComponent<Animal_Section_Copepod>().death[4]){
						
						
						creature.GetComponent<Animal_Section_Copepod>().counter[0] = creature.GetComponent<Animal_Section_Copepod>().counter[1] -
							creature.GetComponent<Animal_Section_Copepod>().death[4];
						
					}else if (creature.GetComponent<Animal_Section_Copepod>().counter[1] + creature.GetComponent<Animal_Section_Copepod>().counter[0]
					          >=creature.GetComponent<Animal_Section_Copepod>().death[4]){
						
						creature.GetComponent<Animal_Section_Copepod>().counter[1] = creature.GetComponent<Animal_Section_Copepod>().counter[1]
						- (creature.GetComponent<Animal_Section_Copepod>().death[4] -creature.GetComponent<Animal_Section_Copepod>().counter[0] );
						
						creature.GetComponent<Animal_Section_Copepod>().counter[0] =0;
						
					}else if (creature.GetComponent<Animal_Section_Copepod>().counter[1] + creature.GetComponent<Animal_Section_Copepod>().counter[0]
					          <creature.GetComponent<Animal_Section_Copepod>().death[4]){
						
						creature.GetComponent<Animal_Section_Copepod>().counter[1] =0;
						creature.GetComponent<Animal_Section_Copepod>().counter[0] =0;
						
						
					}*/
					//counter end





					creature.GetComponent<Animal_Section_Copepod>().death[1]= death[0];
					creature.GetComponent<Animal_Section_Copepod>().death[2] =death[1];
					creature.GetComponent<Animal_Section_Copepod>().death[3] = death [2];
					creature.GetComponent<Animal_Section_Copepod>().death[4] =death[3];
					creature.GetComponent<Animal_Section_Copepod>().death[0] =0;


		
					
					
				}
			}


			Debug.Log ("before check");


			//feeding cycle
			foreach (GameObject creature in creatures) {
				Debug.Log ("after check");
			
				if (creature.gameObject.name == "Copepod_Counter") {
			 	
					Debug.Log ("copepod loop");

					food = plankton.GetComponentInChildren<Animal_parents> ().pop;
					pops = creature.GetComponent<Animal_parents> ().pop;
					if (pops <= food) {
						Debug.Log ("pop less or equal food");
						plankton.GetComponentInChildren<Animal_parents> ().pop = food - pops;
	
					} else if (food < pops) {
						Debug.Log ("food less pop");
						Debug.Log (pops - food);
		
						for (int i =0; i<	pops-food; i++) {

							int lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}

			
						creature.GetComponent<Animal_parents> ().pop = food;
						plankton.GetComponentInChildren<Animal_parents> ().pop = 0;

						//	percent = Random.Range(0,11);
						//	percent2 = 10 - percent;
						//	num1 = Mathf.RoundToInt((percent/10 ) * creature.GetComponent<Animal_Section_Copepod>().count_stage1);
						//		creature.GetComponent<Animal_Section_Copepod>().count_stage1 = num1;
						creature.GetComponent<Animal_Section_Copepod> ().counter[0] = creature.GetComponent<Animal_Section_Copepod> ().pop;

						//	num2 = Mathf.RoundToInt((percent2/10 ) * creature.GetComponent<Animal_Section_Copepod>().count_stage2);
						//	creature.GetComponent<Animal_Section_Copepod>().count_stage2 = num2;
						creature.GetComponent<Animal_Section_Copepod> ().counter[1] = 0;

					//	while (pops-food>0){

						if(creature.GetComponent<Animal_Section_Copepod> ().death[5]<= pops-food){



						}


						//}

					}

				}


				if (creature.gameObject.name == "SeaUrchin_Counter") {

					food = plankton.GetComponentInChildren<Animal_parents> ().pop;
					pops = creature.GetComponent<Animal_parents> ().pop;
					if (pops <= food) {
						Debug.Log ("pop less or equal food");
						plankton.GetComponentInChildren<Animal_parents> ().pop = food - pops;
						
					} else if (food < pops) {
						Debug.Log ("food less pop");
						Debug.Log (pops - food);
						
						for (int i =0; i<	pops-food; i++) {
							
							int lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
						}

						creature.GetComponent<Animal_parents> ().pop = food;
						plankton.GetComponentInChildren<Animal_parents> ().pop = 0;
						
						creature.GetComponent<Animal_Section_SeaUrchin> ().counter[0] = creature.GetComponent<Animal_parents> ().pop;
						creature.GetComponent<Animal_Section_SeaUrchin> ().counter[1] = 0;

					}

			
				}

				if (creature.gameObject.name == "Shrimp_Counter") {
					
					food = Copepod_details.GetComponentInChildren<Animal_parents> ().pop;

					pops = creature.GetComponent<Animal_parents> ().pop; //population to feed

					if (pops > food  ) {
						Debug.Log ("pop less or equal food");
						Copepod_details.GetComponent<Animal_parents> ().pop = food - pops;

						for (int i =0; i<pops-food; i++) {
							
							int lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
							Destroy (creature.GetComponent<Animal_parents> ().alive [lastindex]);
							creature.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);

							if(Copepod_details.GetComponentInChildren<Animal_parents> ().alive != null)
								Destroy (Copepod_details.GetComponent<Animal_parents> ().alive [0]);
							//Copepod_details.GetComponentInChildren<Animal_parents> ().pop = 0;


						}

						Copepod_details.GetComponentInChildren<Animal_parents> ().pop = 0;
						Copepod_details.GetComponentInChildren<Animal_Section_Copepod> ().counter[0] = 0;
						Copepod_details.GetComponentInChildren<Animal_Section_Copepod> ().counter[1] = 0;
						
										
						creature.GetComponent<Animal_Section_Shrimp> ().counter[0] = creature.GetComponent<Animal_parents> ().pop;
						creature.GetComponent<Animal_Section_Shrimp> ().counter[1] = 0;
						creature.GetComponent<Animal_Section_Shrimp> ().counter[2] = 0;
						
					} else {
					
					if (pops<= food) {

							if(Copepod_details.GetComponentInChildren<Animal_parents>().pop > pops){

								for (int i =0; i<food - pops; i++) {
									
									int lastindex = creature.GetComponent<Animal_parents> ().alive.Count - 1;
									Destroy (Copepod_details.GetComponent<Animal_parents> ().alive [lastindex]);
									Copepod_details.GetComponent<Animal_parents> ().alive.RemoveAt (lastindex);
								}
					
								Copepod_details.GetComponent<Animal_parents> ().pop =  food - pops;

							

						
						
					
							}
						
						}
					}
					
					
				}










			}

			//reproduction cycle

			foreach (GameObject creature in creatures) {

				if (creature.gameObject.name == "Shrimp_Counter") {
					if (creature.GetComponent<Animal_parents> ().pop > 0) {
						
						for (int i =0; i<creature.GetComponent<Animal_Section_Shrimp>().counter[2]; i++) {
							GameObject new_creat = Instantiate (Shrimp, copepod_spawn.transform.position, copepod_spawn.transform.rotation) as GameObject;
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
					}
					
				}
				

				if (creature.gameObject.name == "Copepod_Counter") {
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


					}

				}

			}
			timer = 0;
		}


	}
}

