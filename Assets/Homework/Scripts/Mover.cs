using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Vector3 _start;
        [SerializeField] private Vector3 _end;

        [SerializeField] private float _delay;
        [SerializeField] private float _speed;

        private Rigidbody _rb;

        private bool _move;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private IEnumerator Start()
        {
            while (true)
            {
                Vector3 targetPosition = _move ? _start : _end;

               transform.position = Vector3.MoveTowards(
                    _rb.position,
                    targetPosition,
                    _speed * Time.deltaTime);

                if (Vector3.Distance(_rb.position, targetPosition) <= 0.1f)
                {
                    _move = !_move;
                    yield return new WaitForSeconds(_delay);
                }

                else
                {
                    yield return null;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_start, _end);
        }
    }
}