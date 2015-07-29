using UnityEngine;
using System.Collections;
using System;


public class Animal_Section_Dolphin : Animal_parents {
	


	public int count_stage1 = 0;
	public int count_stage2 = 0;
	public int count_stage3 = 0;

	
	//public int count_pop = 0;

	public Animal_Section_Dolphin(){



		base.power=30 ;
		base.defence=40f;
		base.command_pnts = 2;
		base.repro_ratio = 4;
		base.feed_ratio = 1;
		count_stage1 = 0;
		count_stage2 = 0;
	//	count_pop = 0;
	}



}