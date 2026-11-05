using System.Collections;
using UnityEngine;

namespace Game.Gameplay
{
    public class Player : MonoBehaviour
    {
        private bool _ready;
        private Rigidbody _ballRb;

        [SerializeField] private Rigidbody _ballPrefabRb;
        [SerializeField] private float _startVelocity;
        [SerializeField] private float _lifetime;

        [SerializeField] private float _respawnDelay;


        private void Start()
        {
            Spawn();
        }

        private void Update()
        {
            if (!_ready) return;
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(Reloader());
                _ballRb.isKinematic = false;
                _ballRb.transform.parent = null;
                _ballRb.velocity = transform.forward * _startVelocity;
                Destroy(_ballRb.gameObject, _lifetime);
            }
        }

        private IEnumerator Reloader()
        {
            _ready = false;
            yield return new WaitForSeconds(_respawnDelay);
            Spawn();
        }

        private void Spawn()
        {
            _ballRb = Instantiate(_ballPrefabRb, transform.position, Quaternion.identity);
            _ballRb.transform.SetParent(transform, true);
            _ballRb.isKinematic = true;
            _ready = true;
        }
    }
}