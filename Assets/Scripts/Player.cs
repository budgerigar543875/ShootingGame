using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject missile;
    [SerializeField] GameObject laser;
    [SerializeField] Text autoMissileText;
    [SerializeField] EnergyViewer energyViewer;
    [SerializeField] int maxEnergy;
    [SerializeField] int energy;

    enum Direction
    {
        Stop,
        Right,
        Left,
        Up,
        Down,
    }

    const float AREA_MIN_X = -15f;
    const float AREA_MAX_X = 11f;
    const float AREA_MIN_Y = -9f;
    const float AREA_MAX_Y = 9f;
    const float SPEED = 10f;
    const int MAX_INVINCIBLE_COUNT = 60;
    const int MAX_WEAPON_LEVEL = 8;

    Direction dir;
    Rigidbody2D body;
    bool isAuto;
    Coroutine autoShootCoroutine;
    int[] damageLayer;
    int invincibleCount;
    int weaponLevel;
    int numLaserBullets;
    Animator animator;
    CircleCollider2D _collider;
    bool canShoot;

    public bool IsAlive { get { return energy > 0; } }

    private void Awake()
    {
        dir = Direction.Stop;
        isAuto = false;
        autoShootCoroutine = null;
        damageLayer = new int[]  {
            LayerMask.NameToLayer("Enemy"),
            LayerMask.NameToLayer("EnemyMissile")
        };
        invincibleCount = 0;
        weaponLevel = 0;
        numLaserBullets = 0;
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _collider = GetComponent<CircleCollider2D>();
        canShoot = true;
    }

    void Start()
    {
        animator.SetBool("IsAlive", IsAlive);
        energyViewer.SetMaxEnergy(maxEnergy);
        energyViewer.SetEnergy(energy);
    }

    private void Update()
    {
        dir = Direction.Stop;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Direction.Right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Direction.Left;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Direction.Up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Direction.Down;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            isAuto = !isAuto;
            if (isAuto)
            {
                autoMissileText.color = Color.white;
                autoShootCoroutine = StartCoroutine(AutoShoot());
            }
            else
            {
                autoMissileText.color = Color.black;
                if (autoShootCoroutine != null)
                {
                    StopCoroutine(autoShootCoroutine);
                }
            }
        }
        if (!isAuto && canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        for (int i = 0; i <= weaponLevel; i++)
        {
            float y = (-weaponLevel * 6 + i * 12) / 36f - 0.9f;
            GameObject weapon;
            if (numLaserBullets > 0)
            {
                numLaserBullets--;
                weapon = laser;
            } else
            {
                weapon = missile;
            }
            Missile m = Instantiate(weapon, transform.position + new Vector3(2f, y, 0f), transform.rotation).GetComponent<Missile>();
            m.Velocity = new Vector3(m.Velocity.x, (i - weaponLevel / 2f) * 2, m.Velocity.z);
        }
    }

    private IEnumerator AutoShoot()
    {
        while (true)
        {
            if(canShoot)
            {
                Shoot();
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void FixedUpdate()
    {
        if(!IsAlive)
        {
            return;
        }
        float pos_x = transform.position.x;
        float pos_y = transform.position.y;
        float x = 0f;
        float y = 0f;
        if (pos_x > AREA_MIN_X && dir == Direction.Left)
        {
            x = -SPEED;
        }
        else if (pos_x < AREA_MAX_X && dir == Direction.Right)
        {
            x = SPEED;
        }
        if (pos_y < AREA_MAX_Y && dir == Direction.Up)
        {
            y = SPEED;
        }
        else if (pos_y > AREA_MIN_Y && dir == Direction.Down)
        {
            y = -SPEED;
        }
        body.velocity = new Vector2(x, y);
        if (invincibleCount > 0)
        {
            invincibleCount--;
            GetComponent<SpriteRenderer>().enabled = invincibleCount % 2 == 0;
        }
        else
        {
            animator.SetBool("GetDamage", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        int layer = obj.layer;
        if (damageLayer.Contains(layer))
        {
            if (invincibleCount <= 0)
            {
                energy--;
                energyViewer.SetEnergy(energy);
                animator.SetBool("GetDamage", true);
                animator.SetBool("IsAlive", IsAlive);
                if (IsAlive)
                {
                    invincibleCount = MAX_INVINCIBLE_COUNT;
                }
                else
                {
                    body.velocity = Vector2.zero;
                    _collider.enabled = false;
                    if (autoShootCoroutine != null)
                    {
                        StopCoroutine(autoShootCoroutine);
                    }
                }
            }
        }
        else if (layer == LayerMask.NameToLayer("Item"))
        {
            switch (obj.tag)
            {
                case "Energy":
                    energy = Math.Min(maxEnergy, energy + 1);
                    energyViewer.SetEnergy(energy);
                    break;
                case "Missile":
                    weaponLevel = Math.Min(MAX_WEAPON_LEVEL, weaponLevel + 1);
                    break;
                case "Laser":
                    numLaserBullets += 100;
                    break;
            }
            Destroy(obj);
        }
    }

    private void DefaultAnimationEnter()
    {
        canShoot = true;
        _collider.enabled = true;
    }

    private void HurtAnimationEnter()
    {
        canShoot = false;
        _collider.enabled = false;
    }

    private void DieAnimationEnter()
    {
        canShoot = false;
        _collider.enabled = false;
    }

    private void DieAnimationCompleted()
    {
        Destroy(gameObject);
    }
}
