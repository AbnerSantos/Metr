using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public BaseSeatTile currentSeat;
    public SeatType.seatType type; //passengerType
    [Range(0f, 5f)] public float stressingSpeed;
    public bool isPassengerSelected = true;
    [SerializeField] LayerMask mask;
    public int size;

    public void SnapToSeat()
    {
        transform.position = currentSeat.transform.position;
    }

    private void Update()
    {
        if(isPassengerSelected)
        {
            RaycastHit2D rayHit;
            Vector2 direction;

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
        }

        //PassengerManager.instance.ShowNearbySeatInfo(this);
    }

}
