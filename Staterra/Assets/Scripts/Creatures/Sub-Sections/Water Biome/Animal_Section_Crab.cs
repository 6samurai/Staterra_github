using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Crab : Animal_parents {
	


	public int count_stage1 = 0;
	public int count_stage2 = 0;
	public int count_stage3 = 0;

	
	//public int count_pop = 0;

	public Animal_Section_Crab(){



		base.power=10f ;
		base.defence=162f;
		base.command_pnts = 5;
		base.repro_ratio = 2;
		base.feed_ratio = 1;
		base.death_limit = 5;
		count_stage1 = 0;
		count_stage2 = 0;
	//	count_pop = 0;
	}



}