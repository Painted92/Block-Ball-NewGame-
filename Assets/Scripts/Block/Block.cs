using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
	private int _hp;
    private TMP_Text _textBlock;
    private const string BALLTAG = "Ball";
    private ColorBlock _colorBlock;
    public int Hp { get => _hp; set => _hp = value; }

    private void Awake()
    {
        _colorBlock = GetComponent<ColorBlock>();
        _textBlock = GetComponentInChildren<TMP_Text>();
        Hp = Random.Range(9,100);
        _textBlock.text = Hp.ToString();
       
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag(BALLTAG))
        {
            Hp--;
            OnCountText();
            _colorBlock.RendColor();
            if(Hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnCountText()
    {
        _textBlock.text = Hp.ToString();
    }

    
}
