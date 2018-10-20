using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putometro : MonoBehaviour {
    [SerializeField] float stressLimit;
    [SerializeField] float stress;
    private float percentage;
    private float rotationAngle;
    [SerializeField][Range(0f, 0.1f)] float pointerSpeed;
    [SerializeField] GameObject pointer;

    void Update () {
        percentage = (stress * 100) / stressLimit;
        rotationAngle = percentage / (100f/180);
        pointer.transform.rotation = Quaternion.Lerp(pointer.transform.rotation, Quaternion.Euler(0f, 0f, rotationAngle), pointerSpeed);
    }       

    public void UpdatePutometer(IndividualPutometro passenger){
        stress -= passenger.stress;
        if(stress < 0){
            Debug.Log("Game Over");
        }
    }
}
