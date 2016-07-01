using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
    private Vector3 _rotation;
    //Rotates the pick-up model
	void Update () {
        transform.Rotate (new Vector3 (60, 0, 60) * Time.deltaTime);
    }
    //Destroys the pick-up when colliding with Player
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
}