using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class HPSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] itemsToSpawn; // ������ ��������� ��� ����������������
        [SerializeField] private float spawnChance = 0.15f; // ���� ���������������� �������� (15%)

        public void SpawnRandomItem()
        {
            // ���������, ���� �� �������� ��� ����������������
            if (itemsToSpawn.Length == 0)
            {
                Debug.LogWarning("No items to spawn.");
                return;
            }

            // ���������� ��������� ����� ����� 0 � 1
            float randomValue = Random.value;

            // ���� ��������� �������� ������ ��� ����� �����, ������������� �������
            if (randomValue <= spawnChance)
            {
                // ���������� ��������� ������ �� �������
                int randomIndex = Random.Range(0, itemsToSpawn.Length);

                // ������� ������� �� ��������� �����
                GameObject item = Instantiate(itemsToSpawn[randomIndex], transform.position, Quaternion.identity);

                // �� ������ �������� �������������� �������� ��� ��������� ��� ������������������ �������� �����, ���� ��� ����������.
            }
        }
    }
}
