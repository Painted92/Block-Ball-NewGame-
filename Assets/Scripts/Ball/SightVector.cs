using UnityEngine;

public class SightVector : MonoBehaviour
{
    [SerializeField] private int dotsNumber = 10; // Количество точек в прицеле
    [SerializeField] private GameObject dotsParent; // Родительский объект для точек
    [SerializeField] private GameObject dotPrefab; // Префаб точки
    [SerializeField] private float dotSpacing = 0.1f;
    [SerializeField] [Range(0.001f, 0.3f)] private float dotMinScale = 0.01f; // Минимальный размер точки 
    [SerializeField] [Range(0.001f, 1f)] private float dotMaxScale = 0.3f; // Максимальный размер точки

    private Transform[] dotsList; // Лист точек
    private float max_y;
    private float scaleFactor;
    private Vector2 position;
    private float time;

    private void Start()
    {
        SightHide();
        CreateDots();
    }

    private void CreateDots()
    {
        dotsList = new Transform[dotsNumber];
        float scale = dotMaxScale;
        scaleFactor = scale / dotsNumber;

        for (int i = 0; i < dotsNumber; i++)
        {
            GameObject dotObject = Instantiate(dotPrefab, dotsParent.transform);
            Transform dotTransform = dotObject.transform;
            dotsList[i] = dotTransform;

            dotTransform.localScale = Vector3.one * scale;
            if (scale > dotMinScale)
                scale -= scaleFactor;
        }
    }

    public void VectorDot(Vector2 dotPos, Vector2 force)
    {
        time = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            position.x = (dotPos.x + force.x * time);
            position.y = (dotPos.y + force.y * time);
            dotsList[i].position = position;
            time += dotSpacing;
            max_y = position.y;
        }
    }

    public void SightShow()
    {
        dotsParent.SetActive(true);
    }

    public void SightHide()
    {
        dotsParent.SetActive(false);
    }
}