using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualPutometro : MonoBehaviour {
    
    [SerializeField] Passenger passenger;
    private bool repeating = false;
    public float stress = 0f;
    [SerializeField][Range(0f, 500f)] float maxStress;
    [SerializeField][Range(0f, 5f)] float stressUp;
    [SerializeField][Range(0f, 5f)] float repeatCooldown;

    void IncreaseStress(){
        repeating = true;
        if(stress < maxStress){
            stress += passenger.stressingSpeed * stressUp;

            if(stress > maxStress)
                stress = maxStress;    
        }

        if(passenger.currentSeat.type == passenger.type){
            CancelInvoke();
            repeating = false;
        }

    }

    void Awake(){
        passenger = GetComponent<Passenger>();
    }

    void Update(){
        if(passenger.type != passenger.currentSeat.type && !repeating){
            if(passenger.type != SeatType.seatType.fat && passenger.currentSeat.type != SeatType.seatType.common){
                InvokeRepeating("IncreaseStress", 0f, repeatCooldown);
            }
        }
    }   
}