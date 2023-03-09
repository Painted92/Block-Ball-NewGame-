using UnityEngine;

public class ClearBall : BallEvent
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameController _controller;
    public override void Activate(Collider2D other)// –еализаци€ абстрактного метода.
    {
        Clearball(other);
    }

    private void Clearball(Collider2D other) // удаление м€ча, и вызов меню проигрыша если шар был последний.
    {
        other.gameObject.SetActive(false);
        other.transform.position = new Vector2(0, 0);
        _playerController.RemoveBall();
        _controller.LoseMenu();
        gameObject.SetActive(false);
    }
}
