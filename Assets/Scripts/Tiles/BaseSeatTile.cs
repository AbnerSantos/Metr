using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SeatType{
	public enum seatType{
		common,
		fat,
		preferred,
		wheelchair,
		stand
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Passenger")
		{
			TryMovePassenger(other.gameObject.GetComponent<Passenger>());
			Debug.Log("Will try to move.");
		}
	}

	protected virtual void TryMovePassenger(Passenger passenger)
	{
		if(IsAvailable(passenger))
		{
			passenger.currentSeat.currentVacantGap += passenger.size;
			passenger.currentSeat = this;
			currentVacantGap -= passenger.size;
			passenger.SnapToSeat();
		}
		else
			passenger.SnapToSeat();
	}

	public bool IsAvailable(Passenger passenger)
	{
		if(passenger.size <= currentVacantGap &&
		 Vector2.Distance((Vector2)passenger.currentSeat.transform.position, (Vector2)this.transform.position) <= 1f)
			return true;
		else
			return false;
	}	

}
