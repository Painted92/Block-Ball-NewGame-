using UnityEngine;

public abstract class BallEvent : MonoBehaviour // ����������� ����� ��� ���������� ������� � ����
{   
    private const string BALL = "Ball";
    private protected int _coinCount;
    private protected int _lvlCount = 1;

    public abstract void Activate(Collider2D other); // ����������� ����� ��� ������ ��� ������� � ������ ����.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(BALL))
        {
            Activate(other);
        }
    }
}
