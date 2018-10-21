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
		seat = GetComponent<BaseSeatTile>();
		
		for(int i = 0; i < passengerSlots.Length; i++)
		{
			pIndex = Random.Range(0, (passengers.Length - 1));
			Instantiate(passengers[pIndex], passengerSlots[i].transform.position, Quaternion.identity);
			pg = passengers[pIndex].GetComponent<Passenger>();
			seat.MovePassenger(pg);
		}
	}

}	
