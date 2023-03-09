using UnityEngine;
using UnityEngine.EventSystems;

public class GameController  : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PoolBall _poolBall;
    [SerializeField] private GameObject _losseMenu;
    private SceneController _sceneController;
    private int _plusSpeed = 1;
    private void Awake()
    {
        _sceneController = GetComponent<SceneController>();
    }

    public void OnPointerDown(PointerEventData eventData) // ���� ��� �� �� ������������ ���������� ������� � ����� ��������� ��������
    {
        eventData.useDragThreshold = false; // ����������� �������� ������� ����� ��������� ������
        ReturnBall();
        
    }
    public void ReturnBall() // ������� ����� � �������� �����.
    {
            foreach (var item in _poolBall.PoolBalls)
            {
                item.transform.position = new Vector2(0, 0);
                if (item.activeSelf)
                {
                    item.SetActive(false);
                }
            }
            foreach (var item in _poolBall.PoolRigidBody)
            {
                item.velocity = item.velocity * 0;
            }
            _playerController.Stop();
        
      
    }
    public void ReloadLvl() //������������ ������
    {
        _sceneController.ReloadGameScene();
    }
    public void SpeedBallPlus()// �������� �������� ��� �������.
    {
        
        if(_plusSpeed <=2)
        {
            _plusSpeed++;
            foreach (var item in _poolBall.PoolRigidBody)
            {
                item.velocity = item.velocity * _plusSpeed;
            }
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
