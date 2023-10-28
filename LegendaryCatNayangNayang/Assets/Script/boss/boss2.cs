using System.Collections;
using UnityEngine;

public class boss2 : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    [SerializeField] float zlimit = 18;
    [SerializeField] float bulletSpeed = 3f;
    GameObject boss_F;
    bool stopmove = false;
    int hp = 30;
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
    void circle()
    {
        float angle = 0f + Random.Range(0f, 50f);
        for (int i = 0; i < 12; i++)
        {
            float dirx = this.transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);
            float dirz = this.transform.position.z + Mathf.Sin((angle * Mathf.PI) / 180f);
            Vector3 movedir = (new Vector3(dirx, 0, dirz) - this.transform.position);
            Vector3 spawnPos = this.transform.position;
            GameObject enemyObject = BulletObjectPool.Instance.GetPooledEnemyBullet();
            if (enemyObject != null)
            {
                enemyObject.transform.LookAt(movedir);
                enemyObject.transform.position = spawnPos;
                enemyObject.SetActive(true);
                enemyObject.GetComponent<Bullet>().setMove1(bulletSpeed, movedir, Vector3.zero, 0);
            }
            angle += 360 / 12;
        }
    }
    IEnumerator bossSkill()
    {
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                circle();
                yield return new WaitForSeconds(0.3f);
            }
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
            gameplayManager.Instance.point += 800;
            controlCatMove.Instance.powerBulletNumber++;
            Destroy(this.gameObject);
        }
    }
}
