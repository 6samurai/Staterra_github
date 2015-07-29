using UnityEngine;
using System.Collections;
using System;



public class Animal_Section_Fighterplankton : Animal_parents {


	//public int pop = 0;
	public Animal_Section_Fighterplankton(){
		
		base.power=0 ;
		base.defence=0;
		base.command_pnts = 0;
		base.repro_ratio = 0;
		base.feed_ratio = 0;
		base.pop = 0;
	}
	
	public void increase_Defence_1(){
		
		base.defence = 1f;
		
		
	}
	
	
}