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

    public void OnPointerDown(PointerEventData eventData) // в≥зов что бы не обрабатывать глобальное нажатие и метод отработал коректно
    {
        eventData.useDragThreshold = false; // прекращение передачи нажати€ посло отработки метода
        ReturnBall();
        
    }
    public void ReturnBall() // ¬озврат м€чей в исходную точку.
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
    public void ReloadLvl() //ѕерезагрузка уровн€
    {
        _sceneController.ReloadGameScene();
    }
    public void SpeedBallPlus()// ƒобавл€ю скорость дл€ шариков.
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
        _sceneController.ReloadGameScene();// —ейчас стоит перезагрузка уровн€, нужно реализовать переход на следующий уровень.
    }
    public void LoseMenu()
    {
        if(_playerController.CountBall <=0)
        {
            _losseMenu.SetActive(true);
        }
    }

   
}
