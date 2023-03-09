using UnityEngine;

public class ClearBall : BallEvent
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameController _controller;
    public override void Activate(Collider2D other)// ���������� ������������ ������.
    {
        Clearball(other);
    }

    private void Clearball(Collider2D other) // �������� ����, � ����� ���� ��������� ���� ��� ��� ���������.
    {
        other.gameObject.SetActive(false);
        other.transform.position = new Vector2(0, 0);
        _playerController.RemoveBall();
        _controller.LoseMenu();
        gameObject.SetActive(false);
    }
}
