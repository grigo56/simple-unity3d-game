using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		var position = Camera.main.WorldToViewportPoint(gameObject.transform.position);
		if (position.y > 1.5)
		{
			Destroy(gameObject);
		}
	}
}
