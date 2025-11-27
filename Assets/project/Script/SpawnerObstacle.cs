
using System.Collections;
using UnityEngine;

public class SpawnerObstacle : MonoBehaviour
{
    [SerializeField] GameObject LavePrefab;
    public bool restartScreen;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        instatiateLavePrefab();
        yield return new WaitForSeconds(4);
        StartCoroutine(Spawn());
    }

    void instatiateLavePrefab()
    {
        if (!restartScreen)
        {
            Instantiate(LavePrefab, new Vector3(11, Random.Range(-2, 3.5f), 0), Quaternion.identity);
        }
        
    }
}
