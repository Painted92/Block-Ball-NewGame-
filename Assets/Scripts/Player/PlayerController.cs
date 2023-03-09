using UnityEngine;
using TMPro;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private SightVector _sightVector; // Класс прицела.
    [SerializeField] private PoolBall _poolBall; // класс пула шарок
    [SerializeField] private float _ballSpeed = 10.0f; // скоость задающаяся шарам 
    [SerializeField] private float _time; // вреия для отработки корутины
    [SerializeField] private TMP_Text _countBallText; // текст коичества шаров игрока
    [SerializeField] private int _countBall = 15; // количество шаров игрока (наминальное)
    [SerializeField] private GameController _gameController;
    private bool _Open = true; // флаг нажатия и отпускания кнопки 

    private Vector2 direction; // вектор для передачи из прицела шарам
    private bool isDraging; // флаг прицела

    public int CountBall { get => _countBall; set => _countBall = value; }
    public bool Open { get => _Open; set => _Open = value; }
    public bool IsDraging { get => isDraging; set => isDraging = value; }

    void Update()
    {
        BallOpenFlag();
        InputGo();
        CountballText();
    }

    private void CountballText() // передача в такс количества наминальных шаров у игрока
    {
        _countBallText.text = $"x {CountBall}";
    }

    private void InputGo() // метод нажатия кнопок
    {
        if (!Open) return;
        
            if (Input.GetMouseButtonDown(0)) // не стал работать через touc систему что бы избавится от лишних проверок.
            {
                StopCoroutine(BallPush());
                IsDraging = true;
                _sightVector.SightShow();
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsDraging = false;
                _sightVector.SightHide();
                if (direction.y >= 0)
                {
                    StartCoroutine(BallPush());
                }
            }
            if (IsDraging)
            {
                OnDrag();
            }
        
    }

    private  void OnDrag() // считывания нажаия на экран и передача направления движения пальца по экрану, отобажение прицела
    {
        Vector2 _clickPosition;
        _clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (_clickPosition - (Vector2)transform.position).normalized;

        if (direction.y >= 0)
        {
            _sightVector.VectorDot(transform.position, direction * _ballSpeed / 5);
            _sightVector.SightShow();
        }
        else
        {
            _sightVector.SightHide();
        }
    }

    IEnumerator BallPush() // корутина для выпуска шаров, чо бы выходили один за одним 
    {
        for (int i = 1; (CountBall + 1) != i; i++)
        
            if (!IsDraging)
            { 
                    _poolBall.PoolBalls[i].SetActive(true);
                    _poolBall.PoolVector[i].ball_direction = direction;
                    _poolBall.PoolRigidBody[i].velocity = direction * _ballSpeed;
                yield return new WaitForSeconds(_time);
            }
        
    }

     public  void BallOpenFlag() // проверка активных шаров на сцене для активации флага следующего выпуска шаров
    {
        
        foreach (var item in _poolBall.PoolBalls)
        {
            if(item.activeSelf)
            {
                Open = false;
                break;
            }
            else
            {
                Open = true;
            }

        }
    }

    public void AddBall() // дабавить шар
    {
        CountBall++;

    }

    public void RemoveBall() // удалить шар
    {
        CountBall--;
    }

    public void Stop() //остановка карутины
    {
        StopCoroutine(StopPush());
        StartCoroutine(StopPush());
    }

    IEnumerator StopPush() // карутина откючает шары на сцене.
    {
        yield return new WaitForSeconds(0.05f);
        foreach (GameObject itemBall in _poolBall.PoolBalls)
        {
            itemBall.SetActive(false);
        }
     
    }

   
}