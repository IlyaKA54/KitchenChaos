using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void LoadScene(int scene)
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
