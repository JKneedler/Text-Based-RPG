using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryFeed : MonoBehaviour {

	public Queue<string> feed = new Queue<string> ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			AddToFeed ("Yes");
		}
	}

	public void AddToFeed(string line){
		feed.Enqueue (line);
	}
}
