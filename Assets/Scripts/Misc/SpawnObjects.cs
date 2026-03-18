using UnityEngine;
using System.Collections;


public class SpawnObjects : MonoBehaviour
{
    [Header("Spawning Properties")]
    public GameObject prefab;
    public float spawnInterval = 0.25f;
    public float lifeTime = 0.5f;

    [Header("Random Movement")]
    public float minX = -5f;
    public float maxX = 5f;
    public float fixedY = 6.25f;
    public float minZ = -5f;
    public float maxZ = 5f;


    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }


    void MoveToRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        transform.position = new Vector3(randomX, fixedY, randomZ);
    }


    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            MoveToRandomPosition();
            var clone = Instantiate(prefab, transform.position, Quaternion.identity, transform.parent);
            Destroy(clone, lifeTime);
        }
    }
}