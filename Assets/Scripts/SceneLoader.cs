using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void loadMainScene()
   {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
   }

   public void loadStartScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
