using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject spikePrefab;
    public GameObject collectiblePrefab;
    public GameObject portalPrefab;

    // Define the level data as a string array
    string[] levelData = new string[]
    {
        "----------",
        "----------",
        "----------",
        "----------",
        "----------------------------#",
        "############################################################################################################################################################################################"
    };

    void Start()
    {
        GenerateLevel(levelData);
    }

    void GenerateLevel(string[] levelData)
    {
        float spacing = 1.0f; // Adjust this value based on the size of your prefabs

        for (int y = 0; y < levelData.Length; y++)
        {
            string row = levelData[y];
            for (int x = 0; x < row.Length; x++)
            {
                Vector2 position = new Vector2(x * spacing, -y * spacing); // Adjust y to keep level in a single horizontal strip
                char element = row[x];

                switch (element)
                {
                    case '#':
                        Instantiate(groundPrefab, position, Quaternion.identity);
                        break;
                    case '^':
                        Instantiate(spikePrefab, position, Quaternion.identity);
                        break;
                    case 'o':
                        Instantiate(collectiblePrefab, position, Quaternion.identity);
                        break;
                    case 'P':
                        Instantiate(portalPrefab, position, Quaternion.identity);
                        break;
                    case '-':
                    default:
                        // Empty space, no need to instantiate anything
                        break;
                }
            }
        }
    }
}