using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int stageNo;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject enemy4;
    int timer;
    bool isActive;

    public int StageNo
    {
        get => stageNo;
        set => stageNo = value;
    }

    private void Awake()
    {
        timer = 0;
        isActive = false;
    }

    public void StartSpawn()
    {
        isActive = true;
    }

    public void StopSpawn()
    {
        isActive = false;
    }

    private void FixedUpdate()
    {
        if (!isActive)
        {
            timer = 0;
            return;
        }
        timer++;
        int sec = timer / Application.targetFrameRate;
        if (sec < 6)
        {
            if (timer % 40 == 0)
            {
                EnemyBase e = Instantiate(enemy1, new Vector3(18f, Random.Range(-300f, 300f) / 36f, 0f), enemy1.transform.rotation).GetComponent<EnemyBase>();
                e.Energy *= stageNo;
            }
        }
        if (10 <= sec && sec < 16)
        {
            if (timer % 40 == 0)
            {
                EnemyBase e = Instantiate(enemy2, new Vector3(18f, Random.Range(-300f, 300f) / 36f, 0f), enemy2.transform.rotation).GetComponent<EnemyBase>();
                e.Energy *= stageNo;
            }
        }
        if (20 <= sec && sec < 26)
        {
            if (timer % 40 == 0)
            {
                EnemyBase e = Instantiate(enemy3, new Vector3(18f, Random.Range(-300f, 0f) / 36f, 0f), enemy3.transform.rotation).GetComponent<EnemyBase>();
                e.Energy *= stageNo;
            }
        }
        if (30 <= sec && sec < 46)
        {
            if (timer % 120 == 0)
            {
                EnemyBase e = Instantiate(enemy4, new Vector3(18f, Random.Range(-168f, 360f) / 36f, 0f), enemy4.transform.rotation).GetComponent<EnemyBase>();
                e.Energy *= stageNo;
            }
        }
        if (50 <= sec && sec < 66)
        {
            if (timer % 40 == 0)
            {
                EnemyBase e = Instantiate(enemy1, new Vector3(18f, Random.Range(-300f, 300f) / 36f, 0f), enemy1.transform.rotation).GetComponent<EnemyBase>();
                e.Velocity = new Vector3(-15f, 4f, 0f);
                e.Energy *= stageNo;
                e = Instantiate(enemy1, new Vector3(18f, Random.Range(0f, 300f) / 36f, 0f), enemy1.transform.rotation).GetComponent<EnemyBase>();
                e.Velocity = new Vector3(-15f, -4f, 0f);
                e.Energy *= stageNo;
            }
        }
        if (70 <= sec && sec < 86)
        {
            if (timer % 40 == 0)
            {
                EnemyBase e = Instantiate(enemy2, new Vector3(18f, Random.Range(0f, 300f) / 36f, 0f), enemy2.transform.rotation).GetComponent<EnemyBase>();
                e.Energy *= stageNo;
            }
            if (timer % 90 == 0)
            {
                EnemyBase e = Instantiate(enemy4, new Vector3(18f, Random.Range(-300f, 0f) / 36f, 0f), enemy4.transform.rotation).GetComponent<EnemyBase>();
                e.Energy *= stageNo;
            }
        }
        if (90 <= sec && sec < 106)
        {
            if (timer % 20 == 0)
            {
                EnemyBase e = Instantiate(enemy1, new Vector3(18f, 0, 0f), enemy1.transform.rotation).GetComponent<EnemyBase>();
                e.Velocity = new Vector3(-30f, Random.Range(0f, 11f) - 5f, 0f);
                e.Energy *= stageNo;
            }
            if (timer % 40 == 0)
            {
                EnemyBase e = Instantiate(enemy3, new Vector3(18f, Random.Range(60f, 360f) / 36f, 0f), enemy3.transform.rotation).GetComponent<EnemyBase>();
                e.Velocity = new Vector3(-30f, -(Random.Range(0f, 12f) + 4f), 0f);
                e.Energy *= stageNo;
            }
        }
    }
}
