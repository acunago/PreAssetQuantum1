using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TameAI : MonoBehaviour {

	public string AITag = "Respawn";
	public int TameDistance = 6;

	private RaycastHit hit;
	Image CrosshairImage;

	void Start () {
		//Find our crosshair game object
		if (GameObject.Find("Crosshair") != null){
			CrosshairImage = GameObject.Find("Crosshair").GetComponent<Image>();
		}
	}

	void Update() {

		//Draw a ray foward from our player at a distance according to the TameDistance
		if (Physics.Raycast(transform.position, transform.forward, out hit, TameDistance))
		{
			if (hit.collider.CompareTag(AITag)){
				
				//Color our crosshair red to indicate a valid target
				if (CrosshairImage != null){
					CrosshairImage.color = Color.green;
				}

				if(Input.GetKeyDown(KeyCode.F))
				{
					//Check to see if the object we have hit contains an Emerald AI component
					if (hit.collider.gameObject.GetComponent<Emerald_AI>() != null){

						//Get a reference to the Emerald AI object that was hit
						Emerald_AI EmeraldAIRef = hit.collider.gameObject.GetComponent<Emerald_AI>();

						//Check to see if our hit Emerald AI's behavior is not aggressive or companion so we can tame it
						if (EmeraldAIRef.BehaviorRef != Emerald_AI.CurrentBehavior.Aggressive && EmeraldAIRef.BehaviorRef != Emerald_AI.CurrentBehavior.Companion){
							EmeraldAIRef.SetFollowerCompanion(transform.parent);
						}
					}
				}
			}
			else{
				//Color our crosshair white because there is no target
				if (CrosshairImage != null){
					CrosshairImage.color = Color.white;
				}
			}
		}
		else{
			//Color our crosshair white because there is no target
			if (CrosshairImage != null){
				CrosshairImage.color = Color.white;
			}
		}
	}
}
