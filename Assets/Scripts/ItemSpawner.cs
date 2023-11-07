using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject energy;
    [SerializeField] GameObject missile;
    [SerializeField] GameObject laser;
    int timer;
    bool isActive;
    int spawnTiming;

    private void Awake()
    {
        timer = 0;
        isActive = false;
        spawnTiming = ConstValues.FRAME_RATE * 30;
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
        if (timer % spawnTiming == 0)
        {
            Spawn(energy);
        }
        else if (timer % spawnTiming == 300)
        {
            Spawn(missile);
        }
        else if (timer % spawnTiming == 600)
        {
            Spawn(laser);
        }
    }

    private void Spawn(GameObject obj)
    {
        Instantiate(obj, new Vector3(650 / 36f, (-300 + Random.Range(0, 600)) / 36f, 0f), transform.rotation);
    }
}
