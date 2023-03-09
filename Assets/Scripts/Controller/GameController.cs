using UnityEngine;

public class GameController  : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PoolBall _poolBall;
    [SerializeField] private GameObject _losseMenu;
    private SceneController _sceneController;
    private void Awake()
    {
        _sceneController = GetComponent<SceneController>();
    }
    public void ReturnBall() // ������� ����� � �������� �����.
    {
        if(_playerController.Open == false)
        {
            _playerController.IsDraging = false;
            foreach (var item in _poolBall.PoolBalls)
            {
                item.transform.position = new Vector2(0, 0);
                if (item.activeSelf)
                {
                    item.SetActive(false);
                }
            }
            _playerController.Open = false;
            foreach (var item in _poolBall.PoolRigidBody)
            {
                item.velocity = item.velocity * 0;
            }
        }
      
    }
    public void ReloadLvl() //������������ ������
    {
        _sceneController.ReloadGameScene();
    }
    public void SpeedBallPlus()// �������� �������� ��� �������.
    {
        int plusSpeed = 2;
        foreach (var item in _poolBall.PoolRigidBody)
        {
            item.velocity  = item.velocity * plusSpeed;
        }
    }
    public  void NextLevel()
    {
        _sceneController.ReloadGameScene();// ������ ����� ������������ ������, ����� ����������� ������� �� ��������� �������.
    }
    public void LoseMenu()
    {
        if(_playerController.CountBall <=0)
        {
            _losseMenu.SetActive(true);
        }
    }
}
