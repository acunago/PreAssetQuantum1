using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCompanion : MonoBehaviour {

	public int TotalAllowedCompanions = 1;
	public GameObject CompanionAIObject;

	int CurrentCompanions;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)){
			if (CurrentCompanions < TotalAllowedCompanions){
				//Spawn our AI using the Emerald Object Pool system
				GameObject SpawnedAI = EmeraldObjectPool.Spawn(CompanionAIObject, transform.position+transform.forward*5+(Random.insideUnitSphere*2), Quaternion.identity);

				//Set an event on the created AI to remove the AI on death
				SpawnedAI.GetComponent<Emerald_AI>().DeathEvent.AddListener(() => {RemoveAI();});

				//Add the spawned AI to the total amount of currently spawn AI
				CurrentCompanions++;
			}
		}
	}

	public void RemoveAI (){
		CurrentCompanions--;
	}
}
