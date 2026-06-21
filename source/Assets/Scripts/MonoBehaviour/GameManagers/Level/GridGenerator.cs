using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject dirtPrefab;
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private GameObject dirtWithGrassPrefab;
    [SerializeField] private GameObject _dirtBackground; 
    [SerializeField] private GameObject _stoneBackground; 

    public int initX = 0;
    public int width = 20;
    public int height = 3;
    public int stoneDepth = -3;

    public int reliefAmplitude = 1;
    public BlockTypeData dirtGrassBlockData;

    private void Start()
    {
        int colums = width - initX;

        int[] surfaceY = new int[colums];
        int[] stoneY = new int[colums];

        int prevSurfaceY = height - 1;
        int prevStoneY = stoneDepth;

        for (int x = 0; x < colums; x++)
        {
            prevSurfaceY = Mathf.Clamp(prevSurfaceY + Random.Range(-reliefAmplitude, reliefAmplitude + 1), 
                height - 1 - reliefAmplitude, height - 1 + reliefAmplitude);
            surfaceY[x] = prevSurfaceY;

            prevStoneY = Mathf.Clamp(prevStoneY + Random.Range(-reliefAmplitude, reliefAmplitude + 1),
                stoneDepth - reliefAmplitude, stoneDepth + reliefAmplitude);
            stoneY[x] = prevStoneY;
        }


        foreach (Transform t in transform)
            Destroy(t.gameObject);

        Sprite[] grassSprites = dirtGrassBlockData.possibleSprites;

        for (int x = initX; x < width; x++ )
        {
            int i = x - initX;

            for (int y = -10; y <= surfaceY[i]; y++ )
            {
                if (y > surfaceY[i]) continue;

                GameObject prefab;
                if (y == surfaceY[i])
                    prefab = dirtWithGrassPrefab;
                else if (y >= stoneY[i])
                {
                    prefab = dirtPrefab;
                    Instantiate(_dirtBackground, new Vector3(x * 2.5f, y * 2.5f, 1), Quaternion.identity, transform);
                }
                else
                {
                    prefab = stonePrefab;
                    Instantiate(_stoneBackground, new Vector3(x * 2.5f, y * 2.5f, 1), Quaternion.identity, transform);
                }

                GameObject blockObj = Instantiate(prefab, new Vector3(x * 2.5f, y * 2.5f, 0), Quaternion.identity, transform);
                
                if (y == surfaceY[i])
                {
                    BlockBehaviour block = blockObj.GetComponent<BlockBehaviour>();
                    if (block != null && grassSprites != null && grassSprites.Length >= 3)
                    {
                        bool hasLeft = (i > 0) && (y >= stoneY[i-1] && y <= surfaceY[i-1]);
                        bool hasRight = (i < colums - 1) && (y >= stoneY[i+1] && y <= surfaceY[i+1]);

                        Sprite chosen;
                        if (!hasLeft && hasRight)
                            chosen = grassSprites[0];
                        else if (hasLeft && !hasRight)
                            chosen = grassSprites[2];
                        else 
                            chosen = grassSprites[1];

                        block.SetSprite(chosen);
                    }
                }
            }
        }
    }
}
