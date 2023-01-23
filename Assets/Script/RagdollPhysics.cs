using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StickMaster_Test
{
    public class RagdollPhysics : MonoBehaviour
    {
        [Header("Global Var")]
        [SerializeField] private Animator Player_Anim;
        [SerializeField] private BoxCollider Player_Col;
        [SerializeField] private CharacterController Player_Controller;
        [SerializeField] private Rigidbody Player_rigidbody;

        [Header("Local Var")]
        private Collider[] Ragdol_Col;
        private Rigidbody[] Ragdol_Rig;

        #region Unity Methods......................

        private void OnEnable()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GetRagdoll_Part();
            RagdollMode(0f, false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstical"))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                RagdollMode(0f, true);
                UIManager.Instance.StartCoroutine(UIManager.Instance.Game_Over(false));
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Finesh"))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                StartCoroutine(Controller(1f, true));
                UIManager.Instance.Effect.SetActive(true);
                UIManager.Instance.StartCoroutine(UIManager.Instance.Game_Over(true));
            }
        }

        #endregion

        #region Local Methods......................

        /// <summary>
        /// Get Ragdoll Colider.
        /// </summary>
        private void GetRagdoll_Part()
        {
            Ragdol_Col = this.gameObject.GetComponentsInChildren<Collider>();
            Ragdol_Rig = this.gameObject.GetComponentsInChildren<Rigidbody>();
        }

        /// <summary>
        /// RageDoll Apply.
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="IsActive"></param>
        private void RagdollMode(float Time, bool IsActive)
        {
            Player_Anim.enabled = !IsActive;

            //for colider
            foreach (Collider Col in Ragdol_Col)
            {
                Col.enabled = IsActive;
            }

            //for Rigidbody
            foreach (Rigidbody Col in Ragdol_Rig)
            {
                Col.isKinematic = !IsActive;
            }

            Player_Col.enabled = true;
            Player_rigidbody.isKinematic = IsActive;
            StartCoroutine(Controller(Time, IsActive));
        }

        private IEnumerator Controller(float time, bool Ison)
        {
            yield return new WaitForSeconds(time);
            Player_Controller.enabled = !Ison;
        }

        #endregion

    }
}