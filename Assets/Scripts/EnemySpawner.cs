using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] EnemyData[] enemyTypes;
    [SerializeField] float spawnInterval = 1f;
    float timer;

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer > 0f) return;
        timer = spawnInterval;

        if (enemyPrefab == null || enemyTypes.Length <= 0) return;

        Vector3 pos = new Vector3(Random.Range(-8f, 8f), 6f, 0f);
        GameObject obj = Instantiate(enemyPrefab, pos, Quaternion.identity);
        // obj.Awake() was called with Instantiate, so EnemyData is not set yet in Enemy 
        EnemyData data = enemyTypes[Random.Range(0, enemyTypes.Length)];
        // Either we can call obj.Component.Init() our self made method
        // It will be executed after Awake, but before Start
        // Or we can use obj.Start() if EnemyData is not referenced in any way
        obj.GetComponent<Enemy>().Init(data);
    }
}