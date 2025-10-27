using System.Collections;
using UnityEngine;

public class spawnManager_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemyprefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);

            GameObject enemy = Instantiate(Enemyprefab, position, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
