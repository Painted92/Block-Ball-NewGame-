using UnityEngine;
using TMPro;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private SightVector _sightVector; // ����� �������.
    [SerializeField] private PoolBall _poolBall; // ����� ���� �����
    [SerializeField] private float _ballSpeed = 10.0f; // ������� ���������� ����� 
    [SerializeField] private float _time; // ����� ��� ��������� ��������
    [SerializeField] private TMP_Text _countBallText; // ����� ��������� ����� ������
    [SerializeField] private int _countBall = 15; // ���������� ����� ������ (�����������)
    [SerializeField] private GameController _gameController;
    private bool _Open = true; // ���� ������� � ���������� ������ 

    private Vector2 direction; // ������ ��� �������� �� ������� �����
    private bool isDraging; // ���� �������

    public int CountBall { get => _countBall; set => _countBall = value; }
    public bool Open { get => _Open; set => _Open = value; }
    public bool IsDraging { get => isDraging; set => isDraging = value; }

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

    private  void OnDrag() // ���������� ������ �� ����� � �������� ����������� �������� ������ �� ������, ���������� �������
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

    IEnumerator BallPush() // �������� ��� ������� �����, �� �� �������� ���� �� ����� 
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