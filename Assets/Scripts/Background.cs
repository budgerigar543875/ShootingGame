using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    const float LINE_SCROLL_SPEED = 0.5f;

    static Background instance = null;

    [SerializeField] Material sky;
    [SerializeField] float skyRotationSpeed;
    [SerializeField] LineRenderer line;
    float offsetX;
    List<LineRenderer> verticalLines;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Color silver = new Color(192f / 255f, 192f / 255f, 192f / 255f);
        verticalLines = new List<LineRenderer>();
        for (int i = 0; i < 30; i++)
        {
            LineRenderer vertical = Instantiate(line);
            vertical.startWidth = 0.1f;
            vertical.endWidth = vertical.startWidth;
            vertical.startColor = silver;
            vertical.endColor = vertical.startColor;
            vertical.positionCount = 2;
            vertical.transform.SetParent(transform, false);
            verticalLines.Add(vertical);
        }
        offsetX = 0;
        float y = -216;
        for (int i = 1; i < 12; i++)
        {
            LineRenderer horizontal = Instantiate(line);
            horizontal.startWidth = 0.1f + i / 30;
            horizontal.endWidth = horizontal.startWidth;
            horizontal.startColor = Color.gray;
            horizontal.endColor = horizontal.startColor;
            horizontal.positionCount = 2;
            horizontal.transform.SetParent(transform, false);
            horizontal.SetPosition(0, new Vector3(-600f / 36f, y / 36f, 0f));
            horizontal.SetPosition(1, new Vector3(600f / 36f, y / 36f, 0f));
            y -= i * 2;
        }
    }

    private void FixedUpdate()
    {
        float rotation = (sky.GetFloat("_Rotation") + skyRotationSpeed) % 360f;
        sky.SetFloat("_Rotation", rotation);

        offsetX = (offsetX + LINE_SCROLL_SPEED) % 40f;
        for (int i = 0; i < 30; i++)
        {
            LineRenderer lr = verticalLines[i];
            lr.SetPosition(0, new Vector3(((i + 1) * 40f - offsetX - 600f) / 36f, -6f, 0f)); ;
            lr.SetPosition(1, new Vector3(((i + 1) * 240f - offsetX * 6f - 3000f - 600f) / 36f, -10f, 0f));
        }
    }
}
