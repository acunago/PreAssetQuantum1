#pragma strict


function OnTriggerEnter (obj : Collider) {
	var thespikes = gameObject.FindWithTag("spikes");
	thespikes.animation.Play("spikes");
}