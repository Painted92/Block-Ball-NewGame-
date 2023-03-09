using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBall : MonoBehaviour // Пул объектов 
{
    private List<GameObject> _poolBall = new List<GameObject>(); //Лист самих шаров, что бы не создавать каждый раз новые экземпляры, они создаются при старте игры, а после используются потсоянно
    private List<Rigidbody2D> _poolRigidBody = new List<Rigidbody2D>();// РБ шара
    private List<BallVector> _poolVector = new List<BallVector>();// Вектор движения Шара
    [SerializeField] private int _countBall;
    [SerializeField] GameObject _ballPrefab;

    public List<GameObject> PoolBalls { get => _poolBall; set => _poolBall = value; }
    public int CountBall { get => _countBall; set => _countBall = value; }
    public List<Rigidbody2D> PoolRigidBody { get => _poolRigidBody; set => _poolRigidBody = value; }
    public List<BallVector> PoolVector { get => _poolVector; set => _poolVector = value; }

    private void Awake() //Создаю и заполняю листы
    {
        for (int i = 0; i < CountBall; i++)
        {
            GameObject ball = Instantiate(_ballPrefab, transform.position, Quaternion.identity);
            ball.transform.SetParent(transform);
            PoolBalls.Add(ball);
            PoolRigidBody.Add(ball.GetComponent<Rigidbody2D>());
            PoolVector.Add(ball.GetComponent<BallVector>());

        }
        foreach(GameObject ballObj in PoolBalls)// выключаю все объекты на сцене
        {
            ballObj.SetActive(false);
        }
    }
}
