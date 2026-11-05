using System.Collections;
using UnityEngine;

namespace Game.Gameplay
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] Vector3 _rotate;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _delayRotate = 1f;
        
        private Rigidbody _rb;

        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        public IEnumerator Start()
        {
            
            bool rotateToPositive = true;

            Quaternion positiveRotation = Quaternion.Euler(_rotate);
            Quaternion negativeRotation = Quaternion.Euler(-_rotate);

            while (true)
            {
                Quaternion targetRotation = rotateToPositive
                    ? positiveRotation
                    : negativeRotation;
                
                _rb.MoveRotation(Quaternion.RotateTowards(
                    _rb.rotation,
                    targetRotation,
                    _speed * Time.fixedDeltaTime
                ));

                if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
                {
                    yield return new WaitForSeconds(_delayRotate);
                    rotateToPositive = !rotateToPositive;
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}