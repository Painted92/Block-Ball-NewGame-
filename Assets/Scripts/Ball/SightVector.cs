using UnityEngine;

public class SightVector : MonoBehaviour
{
	[SerializeField] private int dotsNumber;  //���������� ����� � �������
	[SerializeField] GameObject dotsParent; // ������������ ������ ��� �����
	[SerializeField] GameObject dotPrefab; // ������ �����
	[SerializeField] private float dotSpacing;
	[SerializeField] [Range(0.01f, 0.3f)] float dotMinScale;// ����������� ������ ����� 
	[SerializeField] [Range(0.01f, 1f)] float dotMaxScale;// ������������ ������ �����
	private float max_y;
	private	Transform[] dotsList; // ���� �����
    private	Vector2 position;
    private	float time;

	void Start()
	{
		SightHide();
		SizeDot();
	}

	void SizeDot() // ���� ������� �����
	{
		dotsList = new Transform[dotsNumber];

		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++)
		{
			dotsList[i] = Instantiate(dotPrefab, null).transform;
			dotsList[i].parent = dotsParent.transform;

			dotsList[i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
				scale -= scaleFactor;
		}
	}

	public void VectorDot(Vector2 dotPoss, Vector2 force) // ����� ������� �����������
	{
		time = dotSpacing;
		for (int i = 0; i < dotsNumber; i++)
		{
			position.x = (dotPoss.x + force.x * time);
			position.y = (dotPoss.y + force.y * time);
			dotsList[i].position = position;
			time += dotSpacing;
			max_y = position.y;
		}

	}

	public void SightShow() // ����� ������ �������
	{
		dotsParent.SetActive(true);
	}

	public void SightHide()// ����� ������� �������
	{
		dotsParent.SetActive(false);
	}
}