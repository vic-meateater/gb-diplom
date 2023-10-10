using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        private int _playersCount;

        void Start ()
        {
                var go = GameObject.FindGameObjectWithTag("Player");
                playerHealth = go.GetComponent<PlayerHealth>();
                InvokeRepeating("Spawn", spawnTime, spawnTime);
            
        }


        private void Spawn()
        {
            _playersCount = GameObject.FindGameObjectsWithTag("Player").Length;
            if (_playersCount < 2)
            {
                if (playerHealth.currentHealth <= 0f)
                {
                    return;
                }
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }
    }
}