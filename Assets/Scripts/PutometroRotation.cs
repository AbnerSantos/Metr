using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutometroRotation : MonoBehaviour {

    [SerializeField][Range(0f,100f)] float rotationPercentage;
    [SerializeField][Range(0f,180f)] float rotationAngle;
    [SerializeField] GameObject pointer;
    [SerializeField][Range(0f, 0.1f)] float pointerSpeed;

    void Update () {
        rotationAngle = rotationPercentage / (100f/180);
        pointer.transform.rotation = Quaternion.Lerp(pointer.transform.rotation, Quaternion.Euler(0f, 0f, rotationAngle), pointerSpeed);
    }       
}
