#if UNITY_EDITOR
using UnityEngine;

[ExecuteInEditMode]

public class CustomTerrain : MonoBehaviour
{
    //PERLIN NOISE ----------------------
    public float perlinXScale = 0.01f;
    public float perlinYScale = 0.01f;
    public int perlinXOffset = 0;
    public int perlinYOffset = 0;
    public int perlinOctaves = 3;
    public float perlinPersistence = 8;
    public float perlinHeightScale = 0.09f;

    //TERRAIN DATA ----------------------
    private Terrain _terrain;
    private TerrainData _terrainData;
    public bool resetTerrain = true;

    private void OnEnable()
    {
        _terrain = GetComponent<Terrain>();
        _terrainData = Terrain.activeTerrain.terrainData;
    }

    public void SinglePerlin()
    {
        float[,] heightMap = GetHeightMap();

        for (int x = 0; x < _terrainData.heightmapResolution; x++)
            for (int y = 0; y < _terrainData.heightmapResolution; y++)
                heightMap[x, y] += FBM((x + perlinXOffset) * perlinXScale, (y + perlinYOffset) * perlinYScale, perlinOctaves, perlinPersistence) * perlinHeightScale;

        _terrainData.SetHeights(0, 0, heightMap);
    }

    public void ResetTerrain()
    {
        float[,] heightMap = new float[_terrainData.heightmapResolution, _terrainData.heightmapResolution];
        _terrainData.SetHeights(0, 0, heightMap);
    }

    private float[,] GetHeightMap()
    {
        if (resetTerrain)
            return new float[_terrainData.heightmapResolution, _terrainData.heightmapResolution];
        return _terrainData.GetHeights(0, 0, _terrainData.heightmapResolution, _terrainData.heightmapResolution);
    }

    private float FBM(float x, float z, int octaves, float persistence)
    {
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;

        for (int i = 0; i < octaves; i++)
        {
            total += Mathf.PerlinNoise(x * frequency, z * frequency) * amplitude;
            maxValue += amplitude;
            amplitude *= persistence;
            frequency *= 2;
        }

        return total / maxValue;
    }
}
#endif
