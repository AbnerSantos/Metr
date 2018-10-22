using UnityEngine;
using UnityEngine.Tilemaps;

public class StationAnim : MonoBehaviour
{
    [SerializeField] private Transform warpStart;
    [SerializeField] private Transform warpEnd;
    [SerializeField] private Rigidbody2D stationRigidbody;
    private Travel travel;
    private bool canStop = false;
    private void Start()
    {
        travel = GetComponent<Travel>();
    }
    private void FixedUpdate()
    {
        if (!travel.isStopped)
        {
            PlayAnim();
        }
        if (stationRigidbody.position.x >= warpStart.position.x)
        {
            stationRigidbody.position = warpEnd.position;
            canStop = true;
        }
        else if (canStop && stationRigidbody.position.x >= 0f)
        {
            stationRigidbody.velocity = Vector2.zero;
            canStop = false;
            travel.isStopped = true;
        }
    }
    public void PlayAnim()
    {
        float velocity = Random.Range(travel.minRange, travel.maxRange);
        stationRigidbody.velocity = new Vector2(velocity, 0f);
    }
};