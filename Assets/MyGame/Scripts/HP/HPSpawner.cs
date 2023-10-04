using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class HPSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] itemsToSpawn; // Массив предметов для инстанциирования
        [SerializeField] private float spawnChance = 0.15f; // Шанс инстанциирования предмета (15%)

        public void SpawnRandomItem()
        {
            // Проверяем, есть ли предметы для инстанциирования
            if (itemsToSpawn.Length == 0)
            {
                Debug.LogWarning("No items to spawn.");
                return;
            }

            // Генерируем случайное число между 0 и 1
            float randomValue = Random.value;

            // Если случайное значение меньше или равно шансу, инстанциируем предмет
            if (randomValue <= spawnChance)
            {
                // Генерируем случайный индекс из массива
                int randomIndex = Random.Range(0, itemsToSpawn.Length);

                // Создаем предмет на указанной точке
                GameObject item = Instantiate(itemsToSpawn[randomIndex], transform.position, Quaternion.identity);

                // Вы можете добавить дополнительные действия или настройки для инстанциированного предмета здесь, если это необходимо.
            }
        }
    }
}
