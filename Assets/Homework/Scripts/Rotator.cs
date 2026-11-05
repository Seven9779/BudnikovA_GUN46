using System.Collections;
using UnityEngine;

namespace Game.Gameplay
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] Vector3 _rotate;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _delayRotate = 1f;
        
        private Rigidbody _rb;

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
                
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    targetRotation,
                    _speed * Time.deltaTime
                );

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