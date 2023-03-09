using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBall : MonoBehaviour // ��� �������� 
{
    private List<GameObject> _poolBall = new List<GameObject>(); //���� ����� �����, ��� �� �� ��������� ������ ��� ����� ����������, ��� ��������� ��� ������ ����, � ����� ������������ ���������
    private List<Rigidbody2D> _poolRigidBody = new List<Rigidbody2D>();// �� ����
    private List<BallVector> _poolVector = new List<BallVector>();// ������ �������� ����
    [SerializeField] private int _countBall;
    [SerializeField] GameObject _ballPrefab;

    public List<GameObject> PoolBalls { get => _poolBall; set => _poolBall = value; }
    public int CountBall { get => _countBall; set => _countBall = value; }
    public List<Rigidbody2D> PoolRigidBody { get => _poolRigidBody; set => _poolRigidBody = value; }
    public List<BallVector> PoolVector { get => _poolVector; set => _poolVector = value; }

    private void Awake() //������ � �������� �����
    {
        for (int i = 0; i < CountBall; i++)
        {
            GameObject ball = Instantiate(_ballPrefab, transform.position, Quaternion.identity);
            ball.transform.SetParent(transform);
            PoolBalls.Add(ball);
            PoolRigidBody.Add(ball.GetComponent<Rigidbody2D>());
            PoolVector.Add(ball.GetComponent<BallVector>());

        }
        foreach(GameObject ballObj in PoolBalls)// �������� ��� ������� �� �����
        {
            ballObj.SetActive(false);
        }
    }
}
