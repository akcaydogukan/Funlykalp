using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeSpawner : MonoBehaviour
{
    public GameObject snowflakePrefab; // Kar tanesi prefabı
    public float spawnInterval = 2f;   // Kar taneleri arasındaki süre (saniye)
    public int maxSnowflakes = 2;      // Oyunda aynı anda görünecek maksimum kar tanesi sayısı
    private float spawnTimer = 0f;

    // Rastgele spawn işleminin merkezi
    public Transform spawnCenter;

    private void Update()
    {
        // Belirli bir süre sonra kar tanesi oluştur
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnSnowflake();
            spawnTimer = 0f;
        }
    }

    private void SpawnSnowflake()
    {
        // Maksimum kar tanesi sayısını kontrol et
        if (GameObject.FindGameObjectsWithTag("Snowflake").Length >= maxSnowflakes)
        {
            return; // Maksimum kar tanesi sayısına ulaşıldıysa yeni oluşturma
        }

        // Rastgele bir açı seç
        float randomAngle = Random.Range(0f, 360f);

        // Rastgele bir mesafe seç
        float randomDistance = Random.Range(1f, 2f);

        // Spawn merkezi etrafında yeni bir pozisyon hesapla
        Vector2 spawnOffset = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right * randomDistance;
        Vector2 spawnPosition = (Vector2)spawnCenter.position + spawnOffset;

        // Kar tanesi oluştur
        Instantiate(snowflakePrefab, spawnPosition, Quaternion.identity);
    }
}