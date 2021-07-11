using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    public PlayerMowement movement;
    public float levelRestartDeley = 2f;

    public void EndGame()
    {
        movement.enabled = false;
        Invoke(nameof(RestartLevel), levelRestartDeley);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
