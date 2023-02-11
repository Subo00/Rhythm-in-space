using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private string chanalTag;
    [SerializeField] private string enemyType;
    private MusicManager musicManager;
    private ObjectPooler spawnerPool;
    private AudioSource audioSource;
    private static float XposLeft = -3.4f;
    private static float Ypos = 8.0f;

    void OnEnable()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        
        var tempMusic = GameObject.Find("MusicManager");
        musicManager = tempMusic.GetComponent<MusicManager>();
        
        var temp = GameObject.Find("Spawner Pool");
        spawnerPool = temp.GetComponent<ObjectPooler>();

        musicManager.GetChanal(chanalTag).Subject += Spawn;
    }

    void OnDisable()
    {
        musicManager.GetChanal(chanalTag).Subject -= Spawn;
    }

    private void Spawn()
    {
        audioSource.Play(); 
        float xPos = Random.Range(XposLeft, XposLeft * (-1f));
        Vector3 pos = new Vector3(xPos, Ypos, 0);
        float randomNumber = Random.Range(0.0f, 1.0f);
        
        spawnerPool.SpawnFromPool(enemyType, pos, new  Quaternion(-180, 0, 0, 1));    
    }
}
