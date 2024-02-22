using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;

    [SerializeField] private Material breadMaterial;
    [SerializeField] private List<Material> commonPieceMaterial = new List<Material>();


    private Grid<SandwitchTile> grid;
    [SerializeField] private List<LevelData> levels = new List<LevelData>();



    public int GridWidth { get => gridWidth; }
    public int GridHeight { get => gridHeight; }

    public Grid<SandwitchTile> Grid { get => grid; }
    public List<LevelData> BoardData { get => levels; }


    private void Awake()
    {

        grid = new Grid<SandwitchTile>(gridWidth, gridHeight, 1, transform.position, (int x, int y) => new SandwitchTile(x, y));
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                List<GameObject> piece = new List<GameObject>();

                if (levels[0].BreadPositions.Contains(new Vector2(i, j)))
                {
                    GameObject newPiece = Instantiate(levels[0].PieceToSpawn, new Vector3(i , 0, j ), Quaternion.identity);
                    newPiece.TryGetComponent(out SwipableObject swipableObject);
                    swipableObject.init(IngreditType.Bread, j, i);


                    Renderer renderer = newPiece.GetComponent<Renderer>();
                    renderer.material = breadMaterial;

                    piece.Add(newPiece);


                }
                else if (levels[0].CommonPiece.Contains(new Vector2(i, j)))
                {
                    GameObject newPiece = Instantiate(levels[0].PieceToSpawn, new Vector3(i , 0, j), Quaternion.identity);
                    newPiece.TryGetComponent(out SwipableObject swipableObject);
                    swipableObject.init(IngreditType.Piece, j, i);
                    ChangeColorForCommonPiece(newPiece);
                    piece.Add(newPiece);

                }

                grid.GetGridObject(i, j).AddToStack(piece);
            }
        }

    }


    private void OnEnable()
    {
        OnTouchMoved.GetGrid += GetGrid;
    }

   
    private void ChangeColorForCommonPiece(GameObject piece)
    {
        Renderer renderer = piece.GetComponent<Renderer>();
        int index = Random.Range(0, commonPieceMaterial.Count);
        renderer.material = commonPieceMaterial[index];

    }



    private Grid<SandwitchTile> GetGrid() => grid;

    private void OnDisable()
    {
        OnTouchMoved.GetGrid -= GetGrid;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Vector3 pos0 = new Vector3(0,0,0);
        Vector3 pos1 = new Vector3(0,0,0);
        for (int i = 0; i < gridWidth + 1; i++)
        {
            pos0.x = i + transform.position.x;
            pos0.z = 0 + transform.position.z; 
            pos1.x = i + transform.position.x;
            pos1.z = gridHeight + transform.position.z;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(pos0, pos1);
        }

        for (int i = 0; i < gridHeight + 1; i++)
        {
            pos0.x = 0 + transform.position.x; 
            pos0.z = i + transform.position.z; 
            pos1.x = gridWidth + transform.position.x;
            pos1.z = i + transform.position.z; 
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(pos0, pos1);
        }

    }
}
