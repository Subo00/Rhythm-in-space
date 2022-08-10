using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private string chanalTag;
    [SerializeField] private string enemyType;
    private MusicManager MusicManager;
    private ObjectPooler spawnerPool;
    private AudioSource AudioSource;

    void OnEnable()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();
        
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
        AudioSource.Play(); 
        float xPos = Random.Range(-4.0f, 4.0f);
        Vector3 pos = new Vector3(xPos, 6, 0);
        float randomNumber = Random.Range(0.0f, 1.0f);
        
        spawnerPool.SpawnFromPool(enemyType, pos, Quaternion.identity );    
    }
}
