using UnityEngine;


public class WaveGrid : MonoBehaviour
{
    [Header("Grid Settings")]
    public GameObject cubePrefab;
    public int gridWidth = 20;
    public int gridDepth = 20;
    public float spacing = 1.1f;

    [Header("Wave Settings")]
    public float speed = 2f;
    public float amplitude = 0.5f;
    public float wavelength = 0.5f;

    private GameObject[,] cubes;


    void Start()
    {
        cubes = new GameObject[gridWidth, gridDepth];
        for (int x = 0; x < gridWidth; x++) {
            for (int z = 0; z < gridDepth; z++) {
                Vector3 pos = new Vector3((x * spacing)-(gridWidth/2 * spacing), 0.15f, (z * spacing)-(gridDepth/2 * spacing));
                cubes[x, z] = Instantiate(cubePrefab, pos, Quaternion.identity, transform);
            }
        }

        Vector3 wavePosition = new Vector3(14.55f, -0.15f, -14.55f);
        transform.position = wavePosition;
    }


    void Update() {
        for (int x = 0; x < gridWidth; x++) {
            for (int z = 0; z < gridDepth; z++) {
                float distance = Vector3.Distance(Vector3.zero, cubes[x, z].transform.position);
                float y = Mathf.Sin(distance * wavelength - Time.time * -speed) * amplitude;
                cubes[x, z].transform.localPosition = new Vector3(cubes[x, z].transform.localPosition.x, y, cubes[x, z].transform.localPosition.z);
            }
        }
    }
}