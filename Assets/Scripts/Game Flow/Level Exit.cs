using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Interactables
{
    public class LevelExit : MonoBehaviour
    {
        private IEnumerator LoalNextLevel()
        {
            ScenePersist.Instance.ResetScenePersist();

            yield return new WaitForSeconds(1.5f);
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                //load the main menu in the future
                SceneManager.LoadScene(0);
            }
            else if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            StartCoroutine(LoalNextLevel());
        }
    }
}
