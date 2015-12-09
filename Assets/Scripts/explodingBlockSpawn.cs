using UnityEngine;
using System.Collections;

public class explodingBlockSpawn : MonoBehaviour
{

    void Start()
    {

        if (explspwn == null)
        {
            explspwn = GameObject.FindGameObjectWithTag("EXPLSPWN").GetComponent<explodingBlockSpawn>();
        }

    }


    public static explodingBlockSpawn explspwn;

    public GameObject blockPrefab;        //prefab set in inspector
    Transform[] blockSpawnPoint;          //spawnpoint array
    public float blockSpawnDelay;         //spawning delay

    public IEnumerator StartSpawn()
    {
        blockSpawnPoint = GetComponentsInChildren<Transform>();

        yield return new WaitForSeconds(blockSpawnDelay); //spawn delay

        for (int i = 0; i < blockSpawnPoint.Length; i++) //loop as many times as array length
        {
            if (i > 0)//ignore pos 0
            {
                //Debug.Log("TEST "+ i );
                var spawnpoint = blockSpawnPoint[i];
                GameObject.Instantiate(blockPrefab, spawnpoint.position, spawnpoint.rotation); //instantiate collectable on spawnpoint
            }

        }

    }
    public static void Spawn(explodingBlockSpawn spawn) //public accessible void that starts spawning
    {
        explspwn.StartCoroutine(explspwn.StartSpawn());
    }
}