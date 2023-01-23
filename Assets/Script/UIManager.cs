using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StickMaster_Test
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("GameOver")]
        [SerializeField] private GameObject GameOver;

        [Header("Particals")]
        public GameObject Effect;

        #region Global Method...............

        /// <summary>
        /// Game Win/Lose Function.
        /// </summary>
        /// <param name="IsWin"></param>
        /// <returns></returns>
        public IEnumerator Game_Over(bool IsWin)
        {
            yield return new WaitForSeconds(2f);

            GameOver.SetActive(true);
            if (IsWin)
            {
                Effect.SetActive(false);
                GameOver.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
                GameOver.transform.GetChild(1).gameObject.SetActive(true);

        }

        /// <summary>
        /// Reload The GamePlay.
        /// </summary>
        public void GameRestart()
        {
            SceneManager.LoadScene("GamePlay");
        }

        #endregion

    }
}