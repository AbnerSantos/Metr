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
