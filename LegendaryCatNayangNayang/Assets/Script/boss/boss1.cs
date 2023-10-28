using System.Collections;
using UnityEngine;

public class boss1 : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    [SerializeField] float zlimit = 18;
    [SerializeField] float bulletSpeed = 3f;
    GameObject boss_F;
    int hp = 30;
    bool stopmove = false;
    IEnumerator moveboss()
    {
        while (this.transform.position.z >= zlimit)
        {
            this.transform.position += Vector3.back * movespeed;
            yield return null;
        }
        StartCoroutine(bossSkill());
        while (true)
        {
            if (stopmove)
            {

            }
            else
            {
                while (this.transform.position.x < 15)
                {
                    this.transform.position += Vector3.right * movespeed;
                    yield return null;
                }
                while (this.transform.position.x > -15)
                {
                    this.transform.position -= Vector3.right * movespeed;
                    yield return null;
                }
            }
        }
    }
    public IEnumerator ShootBackAndForth(float moveSpeed, int bulletsInOneVolley, int interval, float angle_increment, int totalBackandForth)
    {
        float angle = -90f - (bulletsInOneVolley * angle_increment / 2);
        for (int k = 0; k < totalBackandForth; k++)
        {
            for (int i = 0; i < bulletsInOneVolley; i++)
            {
                float dirx = this.transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);
                float diry = this.transform.position.y + Mathf.Sin((angle * Mathf.PI) / 180f);
                Vector3 movedir = (new Vector3(dirx, diry, 0) - this.transform.position);
                Vector3 spawnPos = this.transform.position;
                GameObject enemyObject = BulletObjectPool.Instance.GetPooledEnemyBullet();
                if (enemyObject != null)
                {
                    enemyObject.transform.position = spawnPos;
                    enemyObject.SetActive(true);
                    Bullet enemy = enemyObject.GetComponent<Bullet>();
                    enemy.setMove1(moveSpeed, movedir, Vector3.zero, 0);
                }
                angle += angle_increment;
                for (int j = 0; j < interval; j++)
                {
                    yield return null;
                }
            }
            for (int i = 0; i < bulletsInOneVolley; i++)
            {
                float dirx = this.transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);
                float diry = this.transform.position.y + Mathf.Sin((angle * Mathf.PI) / 180f);
                Vector3 movedir = (new Vector3(dirx, diry, 0) - this.transform.position);
                Vector3 spawnPos = this.transform.position;
                GameObject enemyObject = BulletObjectPool.Instance.GetPooledEnemyBullet();
                if (enemyObject != null)
                {
                    enemyObject.transform.position = spawnPos;
                    enemyObject.SetActive(true);
                    Bullet enemy = enemyObject.GetComponent<Bullet>();
                    enemy.setMove1(moveSpeed, movedir, Vector3.zero, 0);
                }
                angle -= angle_increment;
                for (int j = 0; j < interval; j++)
                {
                    yield return null;
                }
            }
        }
        stopmove = false;
    }
    IEnumerator bossSkill()
    {
        while (true)
        {
            stopmove = true;
            StartCoroutine(ShootBackAndForth(0.5f, 5, 5, 100, 5));
            yield return new WaitForSeconds(6);
            if (boss_F == null)
                boss_F = FleetSpawner.Instance.spawnfleet();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveboss());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            hp--;
        }
        if (other.tag == "PowerBullet")
        {
            hp -= 30;
        }
        if (hp < 0)
        {
            gameplayManager.Instance.point += 500;
            controlCatMove.Instance.powerBulletNumber++;
            Destroy(this.gameObject);
        }
    }
}
