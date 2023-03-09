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
        CoinCount++;
        _coinText.text = $"X{CoinCount}";
        _lvlCountTextWinMenu.text = $"X{CoinCount}";
    }
}
