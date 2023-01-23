using System.Collections;
using UnityEngine;

namespace StickMaster_Test
{
    public class Rotation : MonoBehaviour
    {
        [Header("RoatationSpeed")]
        [SerializeField] private float Speed;

        private void OnEnable()
        {
            StartCoroutine(Rotation_Object());
        }

        /// <summary>
        /// Roastion Animation Play.
        /// </summary>
        /// <returns></returns>
        private IEnumerator Rotation_Object()
        {
            yield return new WaitForEndOfFrame();
            transform.Rotate(new Vector3(0, Speed, 0) * Time.deltaTime);
            StartCoroutine(Rotation_Object());
        }

    }
}