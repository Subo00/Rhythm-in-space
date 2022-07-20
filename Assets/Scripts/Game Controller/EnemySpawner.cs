using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private MusicManager MusicManager;
    private ObjectPooler spawnerPool;
    private AudioSource AudioSource;

    void OnEnable()
    {
        AudioSource = GetComponent<AudioSource>();

        var tempMusic = GameObject.Find("MusicManager");
        MusicManager = tempMusic.GetComponent<MusicManager>();
        
        var temp = GameObject.Find("Spawner Pool");
        spawnerPool = temp.GetComponent<ObjectPooler>();

        MusicManager.chanals[1].Subject += Spawn;
    }

    void OnDisable()
    {
        MusicManager.chanals[1].Subject -= Spawn;
    }

    private void Spawn()
    {
        AudioSource.Play(); 
        float xPos = Random.Range(-4.0f, 4.0f);
        Vector3 pos = new Vector3(xPos, 6, 0);
        spawnerPool.SpawnFromPool("Basic", pos, Quaternion.identity );
    }
}
