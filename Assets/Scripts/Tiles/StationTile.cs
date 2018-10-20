using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTile : BaseSeatTile{
    [SerializeField] GameObject putometro;
    private Putometro putometroScript;
    [SerializeField] IndividualPutometro passengerPutometro;

    void Update(){
        if(passenger != null){
            passengerPutometro = putometro.GetComponent<IndividualPutometro>();
            putometro = GameObject.FindGameObjectWithTag("Putometro");
            putometroScript = putometro.GetComponent<Putometro>();

            putometroScript.UpdatePutometer(passenger.GetComponent<IndividualPutometro>());
            Destroy(passenger);
        }
    }
}