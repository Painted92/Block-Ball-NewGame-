using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
   public void ReloadGameScene()// Перезагрузка сцены
    {
        SceneManager.LoadScene("GameScene");
    }
}
