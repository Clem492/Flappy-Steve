
using System.Collections;
using UnityEngine;

public class SpawnerObstacle : MonoBehaviour
{
    [SerializeField] GameObject LavePrefab;
    [SerializeField] GameObject Player;
    public bool restartScreen;
    public float cooldawn;
    private void Start()
    {
        
        StartCoroutine(Spawn());
        cooldawn = Player.GetComponent<Score>().cooldawn;
    }

    private void Update()
    {
        cooldawn = Player.GetComponent<Score>().cooldawn;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(cooldawn);
        instatiateLavePrefab();
        
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
