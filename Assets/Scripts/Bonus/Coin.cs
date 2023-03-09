using TMPro;
using UnityEngine;

public class Coin : BallEvent
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _lvlCountTextWinMenu;
    public override void Activate(Collider2D other) // ���������� ������������ ������ 
    {
        CoinCounter();
        gameObject.SetActive(false);
    }

    private void CoinCounter() //���������� ����� � ����� ��� � �����
    {
       _coinCount++;
        _coinText.text = $"X{_coinCount}";
        _lvlCountTextWinMenu.text = $"X{_coinCount}";
    }
}
