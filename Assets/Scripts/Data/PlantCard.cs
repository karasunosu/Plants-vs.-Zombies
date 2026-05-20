using UnityEngine;

[CreateAssetMenu(fileName = "new Plant Card", menuName = "Cards/Plant Card")]
public class PlantCard : ScriptableObject
{
    public Sprite cardImage;
    public int sunCost;
    public int cooldown;
}
