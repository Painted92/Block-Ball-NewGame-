using UnityEngine;
using TMPro;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private SightParticles _sightVector; // ����� �������.
    [SerializeField] private PoolBall _poolBall; // ����� ���� �����
    [SerializeField] private float _ballSpeed = 10.0f; // ������� ���������� ����� 
    [SerializeField] private float _coroutineTime; // ����� ��� ��������� ��������
    [SerializeField] private TMP_Text _countBallText; // ����� ��������� ����� ������
    [SerializeField] private int _countBall = 15; // ���������� ����� ������ (�����������)
    [SerializeField] private GameController _gameController;
    private bool _Open = true; // ���� ������� � ���������� ������ 

    private Vector2 _ballVectorDirect; // ������ ��� �������� �� ������� �����
    private bool _isMoving; // ���� �������

    public int CountBall { get => _countBall; set => _countBall = value; }
    public bool Open { get => _Open; set => _Open = value; }
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }

    void Update()
    {
        BallOpenFlag();
        InputGo();
        CountballText();
    }

    private void CountballText() // �������� � ���� ���������� ����������� ����� � ������
    {
        _countBallText.text = $"x {CountBall}";
    }

    private void InputGo() // ����� ������� ������
    {
        if (!Open) return;
        
            if (Input.GetMouseButtonDown(0)) // �� ���� �������� ����� touc ������� ��� �� ��������� �� ������ ��������.
            {
                StopCoroutine(BallPush());
                IsMoving = true;
                _sightVector.SightShow();
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsMoving = false;
                _sightVector.SightHide();
                if (_ballVectorDirect.y >= 0)
                {
                    StartCoroutine(BallPush());
                }
            }
            if (IsMoving)
            {
                OnDrag();
            }
        
    }

    private  void OnDrag() // ���������� ������ �� ����� � �������� ����������� �������� ������ �� ������, ���������� �������
    {
        Vector2 _clickPosition;
        _clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _ballVectorDirect = (_clickPosition - (Vector2)transform.position).normalized;

        if (_ballVectorDirect.y >= 0)
        {
            _sightVector.VectorParticles(transform.position, _ballVectorDirect * _ballSpeed / 5);
            _sightVector.SightShow();
        }
        else
        {
            _sightVector.SightHide();
        }
    }

    IEnumerator BallPush() // �������� ��� ������� �����, �� �� �������� ���� �� ����� 
    {
        for (int i = 1; (CountBall + 1) != i; i++)
        
            if (!IsMoving)
            { 
                    _poolBall.PoolBalls[i].SetActive(true);
                    _poolBall.PoolVector[i].ball_direction = _ballVectorDirect;
                    _poolBall.PoolRigidBody[i].velocity = _ballVectorDirect * _ballSpeed;
                yield return new WaitForSeconds(_coroutineTime);
            }
        
    }

     public  void BallOpenFlag() // �������� �������� ����� �� ����� ��� ��������� ����� ���������� ������� �����
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

    public void AddBall() // �������� ���
    {
        CountBall++;

    }

    public void RemoveBall() // ������� ���
    {
        CountBall--;
    }

    public void Stop() //��������� ��������
    {
        StopCoroutine(StopPush());
        StartCoroutine(StopPush());
    }

    IEnumerator StopPush() // �������� �������� ���� �� �����.
    {
        yield return new WaitForSeconds(0.05f);
        foreach (GameObject itemBall in _poolBall.PoolBalls)
        {
            itemBall.SetActive(false);
        }
     
    }

   
}