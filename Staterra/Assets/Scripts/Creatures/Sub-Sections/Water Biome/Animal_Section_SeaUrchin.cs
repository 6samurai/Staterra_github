using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_SeaUrchin : Animal_parents {
	
//	public int []  counter = new int[2];
//	public int [] death = new int[5];

	public int count_stage1 = 0;
	public int count_stage2 = 0;
	//public int count_pop = 0;

		public Animal_Section_SeaUrchin(){



		base.power=0 ;
		base.defence=96f;
		base.command_pnts = 2;
		base.repro_ratio = 1;
		base.feed_ratio = 1;
		base.death_limit = 2;



	//	count_pop = 0;
	}

	public void Death_Cycle(){
		int lastindex = 0;
		for (int i =0; i< death[2]; i++) {
			
			lastindex = alive.Count - 1;
			GameObject.Destroy (alive [lastindex]);
			alive.RemoveAt (lastindex);
		}
		pop = pop  - death[2];
		
		
		death[3] = death[2];
		
		//counter modify
		for (int i =0; i<=1;i++){
			if(i==0 && counter[0]>=death[2]){
				counter[i] = counter[i] - death[2];
				break;
			}else if (i!=0){
				
				death[2] = death[3]-counter[i-1];
				if(death[3] ==0){
					counter[i-1] = death[3];
					
					break;
					
					
				}else if(death[3] >0){
					counter[i-1] =0;
					
				}
			}
		}
		
		
		shift_Values_death(3);
		
		
		
		
	}


}