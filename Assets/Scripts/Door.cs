using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	private Travel travel;
	private BoxCollider2D boxCollider2D;

	void Start () {
		travel = FindObjectOfType<Travel>();
		boxCollider2D = GetComponent<BoxCollider2D>();
	}
	
	void Update () {
		if (!travel.isStopped)
		{
			boxCollider2D.enabled = false;
		}		
		else
		{
			boxCollider2D.enabled = true;
		}
	}
}
