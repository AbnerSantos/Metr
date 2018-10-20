using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSeatTile : MonoBehaviour
{

	[SerializeField] private int seatSize;
	private int currentVacantGap;

	private void Awake()
	{
		currentVacantGap = seatSize;
	}

	public virtual void MovePassenger(Passenger passenger)
	{
		passenger.currentSeat.currentVacantGap += passenger.size;
		passenger.currentSeat = this;
		currentVacantGap -= passenger.size;
		passenger.SnapToSeat();
	}

	public bool IsAvailable(Passenger passenger)
	{
		if(passenger.size <= currentVacantGap)
			return true;
		else
			return false;
	}	

}
