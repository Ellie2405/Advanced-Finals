using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] Vector2 areaSize;
    [SerializeField] Vector2 offset;
    [SerializeField] int scale;
    [SerializeField] GameObject blockPrefab;
    [SerializeField] bool randomizeOffset;


    // Start is called before the first frame update
    void Start()
    {
        if (randomizeOffset)
        {
            GetRandomOffset();
        }
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        float blockHeight;
        for (int i = 0; i < areaSize.x; i++)
        {
            for (float j = 0; j < areaSize.y; j++)
            {
                blockHeight = Mathf.PerlinNoise((i + offset.x) / areaSize.x * scale, (j + offset.y) / areaSize.y * scale);
                //Debug.Log(i + " " + j + " " + blockHeight);
                Instantiate(blockPrefab, new Vector3(i, blockHeight * 10, j), Quaternion.identity);
            }
        }
    }

    void GetRandomOffset()
    {
        offset = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
    }
}
