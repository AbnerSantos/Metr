using UnityEngine;
using UnityEngine.Tilemaps;

public class StationAnim : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Transform warpStart;
    [SerializeField] private Transform warpEnd;
    private Rigidbody2D stationRigidbody;
    private bool canStop = false;
    private void Start()
    {
        stationRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayAnim();
        }
        if (transform.position.x >= warpStart.position.x)
        {
            stationRigidbody.position = warpEnd.position;
            canStop = true;
        }
        else if (canStop && transform.position.x >= 0f)
        {
            stationRigidbody.velocity = Vector2.zero;
            canStop = false;
        }
    }
    public void PlayAnim()
    {
        stationRigidbody.velocity = new Vector2(velocity, 0f);
    }
};