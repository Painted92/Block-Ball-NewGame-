using UnityEngine;

public abstract class BallEvent : MonoBehaviour // ����������� ����� ��� ���������� ������� � ����
{   
    private const string BALL = "Ball";
    private int _coinCount;
    private int _lvlCount = 1;

    public int CoinCount { get => _coinCount; set => _coinCount = value; }
    public int LvlCount { get => _lvlCount; set => _lvlCount = value; }

    public abstract void Activate(Collider2D other); // ����������� ����� ��� ������ ��� ������� � ������ ����.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(BALL))
        {
            Activate(other);
        }
    }
}
