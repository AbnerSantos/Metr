using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PassengerState{

    public enum passengerState{
        hasAlreadyEntered,
        waitingForUnderground,
        lostUnderground
    };

    public enum station{
        Red,
        Yellow,
        Blue,
        Green
    };
}
public class Passenger : MonoBehaviour
{
    public BaseSeatTile currentSeat;
    public SeatType.seatType type; //passengerType
    [Range(0f, 5f)] public float stressingSpeed;
    public bool isPassengerSelected = true;
    [SerializeField] LayerMask mask;
    public int size;
    public PassengerState.passengerState state = PassengerState.passengerState.waitingForUnderground;
    public PassengerState.station station;
    [SerializeField] Travel underground;

    private RaycastHit2D rayHit;
    private Vector2 direction;

    public void SnapToSeat()
    {
        transform.position = currentSeat.transform.position;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            direction = Vector2.left;
        else if(Input.GetKeyDown(KeyCode.D))
            direction = Vector2.right;
        else if(Input.GetKeyDown(KeyCode.W))
            direction = Vector2.up;
        else if(Input.GetKeyDown(KeyCode.S))
            direction = Vector2.down;
        else
            direction = Vector2.zero;

        if(direction != Vector2.zero)
        {
            rayHit = Physics2D.Raycast((Vector2)this.transform.position + direction, direction, 0.5f, mask);
            Debug.DrawRay((Vector2)this.transform.position + direction, direction, Color.red, 1f);
            if(rayHit.collider != null && rayHit.transform.GetComponent<BaseSeatTile>().IsAvailable(this))
            {
                Debug.Log("Hit");
                rayHit.transform.GetComponent<BaseSeatTile>().MovePassenger(this);
            }
        }

        if(!underground.isStopped){
            if(currentSeat.type == SeatType.seatType.station)
                state = PassengerState.passengerState.lostUnderground;
            else
                state = PassengerState.passengerState.hasAlreadyEntered;
        }
        //PassengerManager.instance.ShowNearbySeatInfo(this);
    }

}
