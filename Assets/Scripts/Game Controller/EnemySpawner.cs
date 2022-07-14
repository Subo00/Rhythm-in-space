using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private string chanalTag;
    private MusicManager MusicManager;
    private ObjectPooler spawnerPool;

    void OnEnable()
    {
        var tempMusic = GameObject.Find("MusicManager");
        MusicManager = tempMusic.GetComponent<MusicManager>();
        
        var temp = GameObject.Find("Spawner Pool");
        spawnerPool = temp.GetComponent<ObjectPooler>();

        MusicManager.GetChanal(chanalTag).Subject += Spawn;
    }

    void OnDisable()
    {
        MusicManager.GetChanal(chanalTag).Subject -= Spawn;
    }

    private void Spawn()
    {
        float xPos = Random.Range(-4.0f, 4.0f);
        Vector3 pos = new Vector3(xPos, 6, 0);
        spawnerPool.SpawnFromPool("Basic", pos, Quaternion.identity );
    }
}
