using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public BaseSeatTile currentSeat;
    public int size;

    public void SnapToSeat()
    {
        transform.position = currentSeat.transform.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }    
    }
}