using UnityEngine;
using TMPro;
public class DorOpen : BallEvent
{
    [SerializeField] private PoolBall _poolBall;
    [SerializeField] private TMP_Text _lvlCountText;
    [SerializeField] private GameObject _winMenu;
    public override void Activate(Collider2D other)//��������� ���������� ������
    {
        other.gameObject.SetActive(false);
        OffBall();
        _winMenu.SetActive(true);
        _lvlCountText.text = $"Level:{_lvlCount}";
    }
    private void OffBall() // ��������� ���� �������� � �������� �� � ��������� ����������.
    {
        _lvlCount++;
        foreach (var item in _poolBall.PoolBalls)
        {
            item.SetActive(false);
            item.transform.position = new Vector2(0, 0);
        }
        
    }
}
