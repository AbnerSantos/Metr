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
	private void OnEnable()
	{
		for(int i = 0; i < passengerSlots.Length; i++)
		{
			pIndex = Random.Range(0, (passengers.Length - 1));
			Debug.Log(pIndex);
			GameObject passengerObject = Instantiate(passengers[pIndex], passengerSlots[i].transform.position, Quaternion.identity);
			pg = passengerObject.GetComponent<Passenger>();
			seat = passengerSlots[i].GetComponent<BaseSeatTile>();
			seat.MovePassenger(pg);
		}
	}

}	
