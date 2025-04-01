using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // ��������A�C�e���̃��X�g
    public float spawnInterval = 5f; // �A�C�e���̃X�|�[���Ԋu
    public float spawnRangeX = 10f;  // X�����͈̔�
    public float spawnRangeZ = 10f;  // Z�����͈̔�
    public float spawnHeight = 10f;  // �A�C�e�����������鍂��

    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnRandomItem();
        }
    }

    void SpawnRandomItem()
    {
        if (itemPrefabs.Length == 0) return; // �A�C�e�����o�^����Ă��Ȃ��ꍇ�͏������Ȃ�

        // �����_���ȃA�C�e����I��
        GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

        // �����_���ȃX�|�[���ʒu��ݒ�
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            spawnHeight,
            Random.Range(-spawnRangeZ, spawnRangeZ)
        );

        // �A�C�e���𐶐�
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
    }
}
