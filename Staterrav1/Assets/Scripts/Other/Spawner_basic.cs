using UnityEngine;
using System.Collections;

public class Spawner_basic : Spawn_Kill_processv8 {
	public GameObject create_copepod;
	public GameObject create_seaurchin;
	public GameObject create_shrimp;
	public GameObject create_jellyfish;
	public GameObject create_crab;
	public GameObject create_bogue;
	public float timer2; // for feeding cycle
	public float timer_limit2;



	//public Spawn_Kill_processv8 animal_cntrl = new Spawn_Kill_processv8();
	// Use this for initialization
	void Start () {
		timer_limit2 = 3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer2 = Time.deltaTime + timer2;
		if(Input.GetKeyUp(KeyCode.F1)){ // && timer>= Time.deltaTime + timer_limit){

			//tiers[0,0] = true;
			//active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(create_copepod, transform.position, transform.rotation) as GameObject;

			GameObject.Find("Copepod_Counter").GetComponent<Animal_parents>().alive.Add(new_inst);

			GameObject.Find("Copepod_Counter").GetComponent<Animal_parents>().pop ++;
			GameObject.Find("Copepod_Counter").GetComponent<Animal_Section_Copepod>().counter[0] ++;
			GameObject.Find("Copepod_Counter").GetComponent<Animal_Section_Copepod>().death[0]++;
			//Debug.Log ("Death");
		//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}

		if(Input.GetKeyUp(KeyCode.F2)){// && timer>= Time.deltaTime + timer_limit){
		//	tiers[0,0] = true;
		//	active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(create_seaurchin, transform.position, transform.rotation) as GameObject;
			
			GameObject.Find("SeaUrchin_Counter").GetComponent<Animal_parents>().alive.Add(new_inst);
			
			GameObject.Find("SeaUrchin_Counter").GetComponent<Animal_parents>().pop ++;
			GameObject.Find("SeaUrchin_Counter").GetComponent<Animal_Section_SeaUrchin>().counter[0] ++;
			GameObject.Find("SeaUrchin_Counter").GetComponent<Animal_Section_SeaUrchin>().death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}

		if(Input.GetKeyUp(KeyCode.F3) ){//&& timer>= Time.deltaTime + timer_limit){

			tiers[0,0] = false;

		active = true;

			timer2 = 0;
			GameObject new_inst = Instantiate(create_shrimp, transform.position, transform.rotation) as GameObject;
			
			GameObject.Find("Shrimp_Counter").GetComponent<Animal_parents>().alive.Add(new_inst);
			
			GameObject.Find("Shrimp_Counter").GetComponent<Animal_parents>().pop ++;
			GameObject.Find("Shrimp_Counter").GetComponent<Animal_Section_Shrimp>().counter[0] ++;
			GameObject.Find("Shrimp_Counter").GetComponent<Animal_Section_Shrimp>().death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
		if(Input.GetKeyUp(KeyCode.F4)){// && timer>= Time.deltaTime + timer_limit){

			tiers[1,0] = false;
			active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(create_jellyfish, transform.position, transform.rotation) as GameObject;
			
			GameObject.Find("Jellyfish_Counter").GetComponent<Animal_parents>().alive.Add(new_inst);
			
			GameObject.Find("Jellyfish_Counter").GetComponent<Animal_parents>().pop ++;
			GameObject.Find("Jellyfish_Counter").GetComponent<Animal_Section_Jellyfish>().counter[0] ++;
			GameObject.Find("Jellyfish_Counter").GetComponent<Animal_Section_Jellyfish>().death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}


		if(Input.GetKeyUp(KeyCode.F5)){// && timer>= Time.deltaTime + timer_limit){

			tiers[0,0] = false;
			active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(create_crab, transform.position, transform.rotation) as GameObject;
			
			GameObject.Find("Crab_Counter").GetComponent<Animal_parents>().alive.Add(new_inst);
			
			GameObject.Find("Crab_Counter").GetComponent<Animal_parents>().pop ++;
			GameObject.Find("Crab_Counter").GetComponent<Animal_Section_Crab>().counter[0] ++;
			GameObject.Find("Crab_Counter").GetComponent<Animal_Section_Crab>().death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
		if(Input.GetKeyUp(KeyCode.F6)){// && timer>= Time.deltaTime + timer_limit){


			tiers[0,0] = false;
			active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(create_bogue, transform.position, transform.rotation) as GameObject;
			
			GameObject.Find("Bogue_Counter").GetComponent<Animal_parents>().alive.Add(new_inst);
			
			GameObject.Find("Bogue_Counter").GetComponent<Animal_parents>().pop ++;
			GameObject.Find("Bogue_Counter").GetComponent<Animal_Section_Bogue>().counter[0] ++;
			GameObject.Find("Bogue_Counter").GetComponent<Animal_Section_Bogue>().death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
	}
}
