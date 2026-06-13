using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject dirtPrefab;
    public GameObject stonePrefab;
    public int initX = 0;
    public int width = 20;
    public int height = 3;
    public int stoneDepth = -3;

    private void Start()
    {
        foreach (Transform t in transform)
            Destroy(t.gameObject);

        for (int x = initX; x < width; x++ )
        {
            for (int y = stoneDepth - 5; y < height; y++ )
            {
                //if (y > stoneDepth) continue;

                GameObject prefab = (y >= stoneDepth) ? dirtPrefab : stonePrefab;
                Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }
    }
}
