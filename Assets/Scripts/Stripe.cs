using UnityEngine;
using UnityEngine.Tilemaps;

public class Stripe : MonoBehaviour
{
    [SerializeField] private Color red;
    [SerializeField] private Color blue;
    [SerializeField] private Color green;
    [SerializeField] private Color yellow;
    [SerializeField] private Tilemap tilemap;
    private Travel travel;
    private void Start()
    {
        travel = GetComponent<Travel>();
    }
    private void Update()
    {
        Color color = Color.white;
        if (travel.currentStation == "Red")
        {
            color = red;
        }
        else if (travel.currentStation == "Blue")
        {
            color = blue;
        }
        else if (travel.currentStation == "Green")
        {
            color = green;
        }
        else if (travel.currentStation == "Yellow")
        {
            color = yellow;
        }
        tilemap.color = color;
    }
};