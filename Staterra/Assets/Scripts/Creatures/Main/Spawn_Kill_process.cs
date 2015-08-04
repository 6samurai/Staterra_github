using UnityEngine;
using System.Collections;
#if false
public class Spawn_Kill_process : MonoBehaviour {

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


	public GameObject copepod_spawn;
	public GameObject seaurchin_spawn;
	//private int 


	//for death distribution (if not fed)
	public int percent;
	public int percent2;
	public int num1;
	public int num2;

	int prev_count;//for reproduction
	int prev_count2;
	//public int count_copepod =0;
	// Use this for initialization


	void Start () {
		timer_limit = 2f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		timer = timer + Time.deltaTime;

		if (timer >= Time.deltaTime + timer_limit) {

		
			plankton = GameObject.FindGameObjectWithTag("Plankton");
			plankton.GetComponentInChildren<Animal_Section_Fighterplankton>().pop = plankton.GetComponentInChildren<Animal_Section_Fighterplankton>().pop+10;

			creatures = GameObject.FindGameObjectsWithTag("Creatures");

			Debug.Log("before check");
			foreach(GameObject creature in creatures){
				Debug.Log("after check");
			//	Debug.Log("creatre details " + creature);
				if(creature.gameObject.name == "Copepod_Counter"){
			 	//if(creature.transform.Find("Copepod") != null){
					Debug.Log("copepod loop");

					food = plankton.GetComponentInChildren<Animal_Section_Fighterplankton>().pop;
					pops = creature.GetComponent<Animal_Section_Copepod>().pop;
					if(pops <= food ){
						Debug.Log("pop less or equal food");
						plankton.GetComponentInChildren<Animal_Section_Fighterplankton>().pop = food - pops;
					//	creature.GetComponent<Animal_Section_Copepod>().count_pop = food;
						//	plankton.GetComponentInChildren<Animal_Section_Fighterplankton>().pop-
					//	creature.GetComponent<Animal_Section_Copepod>().count_pop;
					} else if (food<pops){
						Debug.Log("food less pop");
						Debug.Log(pops-food);
						//	foreach(GameObject creature in creatures){


						GameObject [] dead  = GameObject.FindGameObjectsWithTag("Copepod");
						for(int i =0;i<	pops-food;i++){

							
							Destroy(dead[i]);
							}

						//}
						creature.GetComponent<Animal_Section_Copepod>().pop = food;
						plankton.GetComponentInChildren<Animal_Section_Fighterplankton>().pop  = 0;

					//	percent = Random.Range(0,11);
					//	percent2 = 10 - percent;
					//	num1 = Mathf.RoundToInt((percent/10 ) * creature.GetComponent<Animal_Section_Copepod>().count_stage1);
				//		creature.GetComponent<Animal_Section_Copepod>().count_stage1 = num1;
						creature.GetComponent<Animal_Section_Copepod>().count_stage1 = creature.GetComponent<Animal_Section_Copepod>().pop;

					//	num2 = Mathf.RoundToInt((percent2/10 ) * creature.GetComponent<Animal_Section_Copepod>().count_stage2);
					//	creature.GetComponent<Animal_Section_Copepod>().count_stage2 = num2;
						creature.GetComponent<Animal_Section_Copepod>().count_stage2 = 0;

					}

				}


				if(creature.gameObject.name == "Copepod_Counter"){



				}

			

			}

			foreach(GameObject creature in creatures){

				if(creature.GetComponent<Animal_Section_Copepod>().pop ==0){


				}else{
					for(int i =0; i<creature.GetComponent<Animal_Section_Copepod>().count_stage2;i++){
						Instantiate(Copepod, copepod_spawn.transform.position, copepod_spawn.transform.rotation);
						
						
					}

					creature.GetComponent<Animal_Section_Copepod>().pop = creature.GetComponent<Animal_Section_Copepod>().pop +
						creature.GetComponent<Animal_Section_Copepod>().count_stage2;

					prev_count = creature.GetComponent<Animal_Section_Copepod>().count_stage1;
					prev_count2 = creature.GetComponent<Animal_Section_Copepod>().count_stage2;

					creature.GetComponent<Animal_Section_Copepod>().count_stage1 = prev_count2*2;
					creature.GetComponent<Animal_Section_Copepod>().count_stage2 = prev_count;
				}

			}




			timer = 0;

		}


	}
}

#endif