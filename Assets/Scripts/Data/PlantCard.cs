using UnityEngine;

[CreateAssetMenu(fileName = "new Plant Card", menuName = "Cards/Plant Card")]
public class PlantCard : ScriptableObject
{
    public Sprite sprite;
    public int sunCost;
    public int cooldown;
}
