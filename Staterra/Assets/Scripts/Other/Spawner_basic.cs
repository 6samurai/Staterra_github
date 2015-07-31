using UnityEngine;
using System.Collections;

public class Spawner_basic : MonoBehaviour {
	public GameObject create_copepod;
	public GameObject create_seaurchin;
	public GameObject create_shrimp;
	public GameObject create_jellyfish;
	public GameObject create_crab;
	public GameObject create_bogue;
	public float timer2; // for feeding cycle
	public float timer_limit2;

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



	//public GameObject tier;



//	public Spawn_Kill_processv8 animal_cntrl = new Spawn_Kill_processv8();
	// Use this for initialization
	void Start () {
		timer_limit2 = 3f;
		//tier = GameObject.Find("Copepod_Counter").GetComponent<Animal_parents>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GameObject cntrl = GameObject.Find("Animal_Object_control");
		Spawn_Kill_processv9 tier = cntrl.GetComponent<Spawn_Kill_processv9>();

		timer2 = Time.deltaTime + timer2;
		if(Input.GetKeyUp(KeyCode.F1)){ // && timer>= Time.deltaTime + timer_limit){

			//tiers[0,0] = true;
			//active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(create_copepod, transform.position, transform.rotation) as GameObject;

			copepod_class.alive.Add(new_inst);

			copepod_class.pop ++;
			copepod_class.counter[0] ++;
			copepod_class.death[0]++;
			//Debug.Log ("Death");
		//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}

		if(Input.GetKeyUp(KeyCode.F2)){// && timer>= Time.deltaTime + timer_limit){
		//	tiers[0,0] = true;
		//	active = true;
			timer2 = 0;
			GameObject new_inst = Instantiate(create_seaurchin, transform.position, transform.rotation) as GameObject;
			
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
			GameObject new_inst = Instantiate(create_shrimp, transform.position, transform.rotation) as GameObject;
			
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
			GameObject new_inst = Instantiate(create_jellyfish, transform.position, transform.rotation) as GameObject;
			
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
			GameObject new_inst = Instantiate(create_crab, transform.position, transform.rotation) as GameObject;
			
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
			GameObject new_inst = Instantiate(create_bogue, transform.position, transform.rotation) as GameObject;
			
			bogue_class.alive.Add(new_inst);
			
			bogue_class.pop ++;
			bogue_class.counter[0] ++;
			bogue_class.death[0]++;
			//Debug.Log ("Death");
			//	Destroy(GameObject.FindGameObjectWithTag("Copepod"));
		}
	}
}
