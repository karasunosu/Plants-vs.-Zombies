using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] int starCost;
    
    public int GetStarCost()
    {
        return starCost;
    }
}
