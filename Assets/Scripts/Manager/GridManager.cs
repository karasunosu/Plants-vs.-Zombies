using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private float widthOffset, heightOffset;

    [SerializeField] private Transform gridOrigin;

    [SerializeField] Tile tile;
    Tile[,] grid;

    public static GridManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        grid = new Tile[width, height];

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Vector3 spawnPos = new Vector3(gridOrigin.position.x + (x * widthOffset), gridOrigin.position.y + (y * heightOffset), 0);
                
                Tile tileSpawned = Instantiate(tile, spawnPos, Quaternion.identity, transform);

                grid[x, y] = tileSpawned;
            }
        }
    }

    public Tile GetTileAtWorldPos(Vector3 worldPos)
    {
        int col = Mathf.RoundToInt((worldPos.x - gridOrigin.position.x) / widthOffset);

        int row = Mathf.RoundToInt((worldPos.y - gridOrigin.position.y) / heightOffset);

        if(col < 0 || col >= width || row < 0 || row >= height)
            return null;

        return grid[col, row];
    }
}
