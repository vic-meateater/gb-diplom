using UnityEngine;

namespace CompleteProject
{

    public class HPBottle : MonoBehaviour
    {

        [SerializeField] private int _addHPValue;
        private PlayerHealth _player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerHealth>())
            {
                _player = other.GetComponent<PlayerHealth>();
                _player.AddHealth(_addHPValue);
                Destroy(gameObject);
            }
        }
    }
}