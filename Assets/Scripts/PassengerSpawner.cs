using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
	[SerializeField] GameObject[] passengerSlots;
	[SerializeField] GameObject[] passengers;
	public BaseSeatTile seat;
	private int pIndex;
	private Passenger pg;
	void Start ()
	{	
		for(int i = 0; i < passengerSlots.Length; i++)
		{
			pIndex = Random.Range(0, (passengers.Length - 1));
			Debug.Log(pIndex);
			Instantiate(passengers[pIndex], passengerSlots[i].transform.position, Quaternion.identity);
			pg = passengers[pIndex].GetComponent<Passenger>();
			seat = passengerSlots[i].GetComponent<BaseSeatTile>();
			seat.MovePassenger(pg);
		}
	}

}	
