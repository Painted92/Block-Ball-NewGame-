using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
   public void ReloadGameScene()// ������������ �����
    {
        SceneManager.LoadScene("GameScene");
    }
}
