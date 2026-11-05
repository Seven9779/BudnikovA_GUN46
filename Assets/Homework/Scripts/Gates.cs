using UnityEngine;

namespace Game.Gameplay
{
    public class Gates : MonoBehaviour
    {
        private Rigidbody _rb;
        private int _score;


        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Rigidbody>(out var rb))
            {
                Debug.Log("Rb not found");
            }

            else
            {
                _score++;
                Debug.Log($"Current Score: {_score}");
            }
        }
    }
}