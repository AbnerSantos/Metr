using UnityEngine;
using UnityEngine.Tilemaps;

public class PassengerManager : MonoBehaviour
{
    public static PassengerManager instance;
    //[SerializeField] Tilemap indicators;
    //[SerializeField] Tile available, unavailable;
    [SerializeField] LayerMask mask;
    private Passenger currentSelectedPassenger;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(this);
    }

    private void Update()
    {
        Collider2D overlappedObject;

        if(Input.GetMouseButton(0))
        {
            overlappedObject = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), mask);
            if(currentSelectedPassenger != null)
                currentSelectedPassenger.isPassengerSelected = false;
            currentSelectedPassenger = overlappedObject.GetComponent<Passenger>();
            currentSelectedPassenger.isPassengerSelected = true;
        }
    }

    public void ShowNearbySeatInfo(Passenger passenger)
    {
       
    }

    public void HideNearbySeatInfo(Passenger passenger)
    {
		
    }
}