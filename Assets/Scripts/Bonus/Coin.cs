using TMPro;
using UnityEngine;

public class Coin : BallEvent
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _lvlCountTextWinMenu;
    public override void Activate(Collider2D other) // Реализация абстрактного метода 
    {
        CoinCounter();
        gameObject.SetActive(false);
    }

    private void CoinCounter() //Добавление коина и вывод его в текст
    {
        CoinCount++;
        _coinText.text = $"X{CoinCount}";
        _lvlCountTextWinMenu.text = $"X{CoinCount}";
    }
}
