using UnityEngine;
using Random = UnityEngine.Random;

public class HPSpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _HPBottle;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _maxHpPotsOnLevel = 4;
    private GameObject _HPBottleCount;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _spawnTime, _spawnTime);
    }

    private void Spawn()
    {
        var hpSpawnedCount = GameObject.FindGameObjectsWithTag("HPPots").Length;
        if (hpSpawnedCount < _maxHpPotsOnLevel)
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
            Instantiate(_HPBottle, _spawnPoints[spawnPointIndex].position, _spawnPoints[spawnPointIndex].rotation);
        }
    }
}
