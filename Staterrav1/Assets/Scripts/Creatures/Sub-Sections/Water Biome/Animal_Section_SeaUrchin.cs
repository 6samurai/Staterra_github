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
		base.death_limit = 3;



	//	count_pop = 0;
	}



}