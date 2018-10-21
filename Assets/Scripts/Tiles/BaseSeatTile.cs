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
	[SerializeField] private int seatSize;
	private int currentVacantGap;
	public SeatType.seatType type;

	private void Awake()
	{
		currentVacantGap = seatSize;
	}

	public virtual void MovePassenger(Passenger passenger)
	{
		this.passenger = passenger.gameObject;
		passenger.currentSeat.currentVacantGap += passenger.size;
		passenger.currentSeat = this;
		currentVacantGap -= passenger.size;
		passenger.SnapToSeat();

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
			case SeatType.seatType.wheelchair:
				passenger.CurrentState = Passenger.State.StandingUp;
				break;
			default:
				break;
		}
	}

	public bool IsAvailable(Passenger passenger)
	{
		if(passenger.size <= currentVacantGap)
			return true;
		else
			return false;
	}	

}
