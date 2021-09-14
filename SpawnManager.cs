using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnZombieRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpwanZombies(int zombiesint)
    {
      
        for (int k = 0; k < zombiesint; k++)
        {
            int i = Random.Range(0, zombiePrefabs.Length);
            Vector3 zomPos = new Vector3(Random.Range(-150, 150), -8.1f, Random.Range(80, 220));
     
            Instantiate(zombiePrefabs[i], zomPos, Quaternion.identity);
       
        }
    }

    IEnumerator SpawnZombieRoutine()
    {
        yield return new WaitForSeconds(2f);
        SpwanZombies(5);

        yield return new WaitForSeconds(10f);
        SpwanZombies(5);

    }
}
