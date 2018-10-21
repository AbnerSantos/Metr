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
    public bool isPassengerSelected = true;
    [SerializeField] LayerMask mask;
    SpriteRenderer sRender;
    public int size;
    [SerializeField] Sprite sittingDown, standingUp, sharingTile;
    public enum State { SittingDown, StandingUp , SharingSlot }
    public enum FacingDirection { Up, Down, Left, Right }
    private State currentState;
    public State CurrentState
    {
        get { return currentState; }
        set
        {
            switch(value)
            {
                case State.StandingUp:
                    sRender.sprite = standingUp;
                    break;
                case State.SharingSlot:
                    sRender.sprite = sharingTile;
                    break;
                case State.SittingDown:
                    sRender.sprite = sittingDown;
                    break;
                default:
                    break;
            }
        }
    }
    
    private FacingDirection currentDirection;
    public FacingDirection CurrentDirection
    {
        get { return currentDirection; }
        set
        {
            Debug.Log(value);
            currentDirection = value;
            switch(value)
            {
                case FacingDirection.Down:
                    this.transform.eulerAngles = new Vector3(0, 0, 180); 
                    break;
                case FacingDirection.Up:
                    this.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case FacingDirection.Left:
                    this.transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                case FacingDirection.Right:
                    this.transform.eulerAngles = new Vector3(0, 0, 270);
                    break;
                default:
                    break;
             }
            
        }
    }
    private FacingDirection tempDirection;

    public PassengerState.passengerState state = PassengerState.passengerState.waitingForUnderground;
    public PassengerState.station station;
    [SerializeField] Travel underground;

    private RaycastHit2D rayHit;
    private Vector2 direction;

    private void Awake()
    {
        currentState = State.StandingUp;
        sRender = GetComponent<SpriteRenderer>();
    }
    
    public void SnapToSeat()
    {
        if(currentSeat.type == SeatType.seatType.fat)
        {
            Vector3 adjustVector;

            if(currentSeat.transform.rotation == Quaternion.Euler(0, 0, 90))
                adjustVector = Vector3.up;
            else if(currentSeat.transform.rotation == Quaternion.Euler(0, 0, 270))
                adjustVector = Vector3.down;
            else if(currentSeat.transform.rotation == Quaternion.Euler(0, 0, 180))
                adjustVector = Vector3.left;
            else
                adjustVector = Vector3.right;

            if(type == SeatType.seatType.fat)
                transform.position = currentSeat.transform.position + adjustVector/2;
            else if(currentSeat.slot1 == null)
            {
                currentSeat.slot1 = this;
                transform.position = currentSeat.transform.position + adjustVector;
            }
            else if(currentSeat.slot2 == null)
            {
                currentSeat.slot2 = this;
                transform.position = currentSeat.transform.position;
            }
        }
        else if(currentSeat.type == SeatType.seatType.wheelchair)
        {

            if(type == SeatType.seatType.wheelchair || type == SeatType.seatType.fat) 
                transform.position = currentSeat.transform.position;
            else if(currentSeat.slot1 == null)
            {
                currentSeat.slot1 = this;
                transform.position = currentSeat.transform.position + Vector3.left/2;
            }
            else if(currentSeat.slot2 == null)
            {
                currentSeat.slot2 = this;
                transform.position = currentSeat.transform.position + Vector3.right/2;
            }
        }
        else
        {
            transform.position = currentSeat.transform.position;

        }

    }

    private void Update()
    {
        if(isPassengerSelected)
        {
            RaycastHit2D rayHit;
            Vector2 direction;

            if(Input.GetKeyDown(KeyCode.A))
            {
                if(currentState == State.StandingUp)
                    tempDirection = FacingDirection.Left;
                direction = Vector2.left;
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                if(currentState == State.StandingUp)
                    tempDirection = FacingDirection.Right;
                direction = Vector2.right;
            }
            else if(Input.GetKeyDown(KeyCode.W))
            {
                if(currentState == State.StandingUp)
                    tempDirection = FacingDirection.Up;
                direction = Vector2.up;
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                if(currentState == State.StandingUp)
                    tempDirection = FacingDirection.Down;
                direction = Vector2.down;
            }
            else
                direction = Vector2.zero;

            if(direction != Vector2.zero)
            {
                rayHit = Physics2D.Raycast((Vector2)this.transform.position + direction, direction, 0.5f, mask);
                Debug.DrawRay((Vector2)this.transform.position + direction, direction, Color.red, 1f);
                if(rayHit.collider != null && rayHit.transform.GetComponent<BaseSeatTile>().IsAvailable(this))
                {
                    rayHit = Physics2D.Raycast((Vector2)this.transform.position + direction, direction, 0.5f, mask);
                    Debug.DrawRay((Vector2)this.transform.position + direction, direction, Color.red, 1f);
                    if(rayHit.collider != null && rayHit.transform.GetComponent<BaseSeatTile>().IsAvailable(this))
                    {
                        Debug.Log("Hit");
                        CurrentDirection = tempDirection;
                        rayHit.transform.GetComponent<BaseSeatTile>().MovePassenger(this);
                    }
                }
            }

        }
        
        if(!underground.isStopped)
        {
            if(currentSeat.type == SeatType.seatType.station)
                state = PassengerState.passengerState.lostUnderground;
            else
                state = PassengerState.passengerState.hasAlreadyEntered;
        }
        //PassengerManager.instance.ShowNearbySeatInfo(this);
    }
}