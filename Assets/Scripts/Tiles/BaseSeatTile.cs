using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SeatType{
	public enum seatType{
		common,
		fat,
		special,
		wheelchair,
		stand,
        station
	};
}
	
public class BaseSeatTile : MonoBehaviour
{
	public GameObject passenger;
	public bool isCrowded = false;
	public int seatSize;
	public int currentVacantGap;
	public SeatType.seatType type;
	public Passenger slot1 = null, slot2 = null;

	private void Awake()
	{
		currentVacantGap = seatSize;
	}

	public virtual void MovePassenger(Passenger passenger)
	{
		Debug.Log("Man");

		if(passenger.currentSeat.slot1 == passenger)
			passenger.currentSeat.slot1 = null;
		else if(passenger.currentSeat.slot2 == passenger)
			passenger.currentSeat.slot2 = null;

		if(passenger.currentSeat.type == SeatType.seatType.stand)
		{
			if(passenger.currentSeat.slot1 != null)
				passenger.currentSeat.slot1.transform.position = passenger.currentSeat.slot1.currentSeat.transform.position;
			else if(passenger.currentSeat.slot2 != null)
				passenger.currentSeat.slot2.transform.position = passenger.currentSeat.slot2.currentSeat.transform.position;
		}

		passenger.currentSeat.passenger = null;
		passenger.currentSeat.isCrowded = false;
		passenger.currentSeat.currentVacantGap += passenger.size;
		passenger.currentSeat = this;

		this.passenger = passenger.gameObject;
		currentVacantGap -= passenger.size;

		switch(type)
		{
			case SeatType.seatType.common:
			case SeatType.seatType.special:
			case SeatType.seatType.fat:
				passenger.transform.rotation = this.transform.rotation;
				passenger.CurrentState = Passenger.State.SittingDown;
				break;
			case SeatType.seatType.stand:
			case SeatType.seatType.station:
				passenger.CurrentState = Passenger.State.StandingUp;
				break;
			case SeatType.seatType.wheelchair:
				passenger.CurrentState = Passenger.State.StandingUp;
				if(passenger.type == SeatType.seatType.wheelchair)
					passenger.transform.rotation = Quaternion.identity;
				break;
			default:
				break;
		}

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
