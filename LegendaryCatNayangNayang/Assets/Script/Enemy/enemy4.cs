using System.Collections;
using UnityEngine;

public class enemy4 : MonoBehaviour, enemyParent
{
    float moveSpeed = 1;
    int bulletNum = 10;
    float bulletSpeed = 3;
    float timeBeforeExplode = 3;
    [SerializeField] Rigidbody rb;
    int hp = 2;
    void explodeShoot()
    {
        float angle = 0f + Random.Range(0f, 50f);
        for (int i = 0; i < bulletNum; i++)
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
            angle += 360 / bulletNum;
        }
        Destroy(this.gameObject);
    }
    IEnumerator move()
    {
        rb.velocity = Vector3.back * moveSpeed;
        yield return new WaitForSeconds(timeBeforeExplode);
        explodeShoot();
    }
    public void startShooting()
    {
        StartCoroutine(move());
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
            gameplayManager.Instance.point += 150;
            gameplayManager.Instance.bosspoint -= 100;
            explodeShoot();
            Destroy(this.gameObject);
        }
    }

}
