using UnityEngine;


public class ColorBlock : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Block _block;
    private int _rColor = 5;
    private int _gColor = 10;
    private Color _colorBlock;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _block = GetComponent<Block>();
        _colorBlock = _spriteRenderer.color;
        StartColorRend();
    }

    public void RendColor()  // ����� ����� ��� ��������� ��� ������ ������ �������� ����� �� ���������� �����.
    {
        _colorBlock.r -= _rColor / 255f;
        _colorBlock.g += _gColor / 255f;
        _spriteRenderer.color = _colorBlock;
        if(_block.Hp <= 10)
        {
            _colorBlock = Color.gray;
        }
        
    }
    public void StartColorRend() //����� ��������� ���� ����� ��� ���������.
    {
        _colorBlock = Color.red;
        _spriteRenderer.color = _colorBlock;
    }
}

