using UnityEngine;
using UnityEngine.Tilemaps;

public class PassengerManager : MonoBehaviour
{
    public static PassengerManager instance;
    [SerializeField] Tilemap indicators;
    [SerializeField] Tile available, unavailable;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(this);
    }
    public void ShowNearbySeatInfo(Passenger passenger)
    {
       
    }

    public void HideNearbySeatInfo(Passenger passenger)
    {
		
    }
}