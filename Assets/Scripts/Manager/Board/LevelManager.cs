using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;

    [SerializeField] private Material breadMaterial;
    [SerializeField] private List<Material> commonPieceMaterial = new List<Material>();


    private Grid<SandwitchTile> grid;
    [SerializeField] private List<LevelData> levels = new List<LevelData>();


    public static int PiecesInGame = 0; // Da cambiare
    private int index;

    public int GridWidth { get => gridWidth; }
    public int GridHeight { get => gridHeight; }

    public Grid<SandwitchTile> Grid { get => grid; }
    public List<LevelData> BoardData { get => levels; }


    private void Awake()
    {
        index = 0;
        CreateLevel();
    }

    private void OnEnable()
    {
        OnTouchMoved.GetGrid += GetGrid;
        GameManager.OnLoadNextLevel += CreateLevel;
    }


    private void CreateLevel()
    {
        if (index == levels.Count) return; // trigger livello finito 

        grid = new Grid<SandwitchTile>(gridWidth, gridHeight, 1, transform.position, (int x, int y) => new SandwitchTile(x, y));
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                List<SwipableObject> piece = new List<SwipableObject>();

                if (levels[index].BreadPositions.Contains(new Vector2(i, j)))
                {

                    GameObject newPiece = Instantiate(levels[index].PieceToSpawn, new Vector3(i, 0f, j), Quaternion.identity);
                    newPiece.TryGetComponent(out SwipableObject swipableObject);

                    swipableObject.init(IngreditType.Bread, i, j);

                    Renderer renderer = newPiece.GetComponent<Renderer>();
                    renderer.material = breadMaterial;

                    piece.Add(swipableObject);

                    PiecesInGame+=1;

                }
                else if (levels[index].CommonPiece.Contains(new Vector2(i, j)))
                {
                    GameObject newPiece = Instantiate(levels[index].PieceToSpawn, new Vector3(i, 0f, j), Quaternion.identity);
                    newPiece.TryGetComponent(out SwipableObject swipableObject);

                    swipableObject.init(IngreditType.Piece, i, j);


                    ChangeColorForCommonPiece(newPiece);

                    piece.Add(swipableObject);

                    PiecesInGame+=1;

                }

                grid.GetGridObject(i, j).AddToStack(piece);
            }
        }
        index += 1;
        
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
        GameManager.OnLoadNextLevel -= CreateLevel;
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
