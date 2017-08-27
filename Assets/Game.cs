using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	public GameObject part;
	private int spread = 5;
	private int max = 500;

	void Update() {
		float t = 1/Time.deltaTime;
		if (t < 10) {
			max--;
		} else {
			max++;
		}
	}

	void OnGUI() {
		GUI.Box(new Rect(0,0,100,25), max.ToString());
	}

	public void Explode(GameObject go, Vector3 loc) {
		int cubes = GameObject.FindGameObjectsWithTag("Cube").Length;

		if (cubes > max) {
			DestroyObject(go);
			return;
		}

		for (int i = 0; i <= spread; i++) {
			float rand = Random.Range(4, 90);
			GameObject instance = Instantiate(part, loc, transform.rotation) as GameObject;
			instance.GetComponent<Cube>().game = this;

			Rigidbody[] ArrayRigs = instance.GetComponentsInChildren<Rigidbody>();
			foreach (var item in ArrayRigs) {
				Rigidbody rb = item.GetComponent<Rigidbody>();
				rb.AddExplosionForce(2000.0f, new Vector3(loc.x + rand, loc.y - rand), 50f, 1f);
			}

			DestroyObject(go);
			DestroyObject(instance, Random.Range(.5f, 5f));
		}
	}
}