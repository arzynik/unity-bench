using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	private int alive = 0;
	public Game game;

	// Use this for initialization
	void Start () {
		//Explode(transform.position);
		Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		GetComponent<Renderer>().material.color = newColor;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		alive++;
		transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
	}
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Cube" || alive < 50) {
			return;
		}
		game.Explode(gameObject, 
		col.contacts[0].point);
	}
}
