using System.Collections;
using UnityEngine;


public class enemy2 : MonoBehaviour, enemyParent
{
    float bulletSpeed = 1.0f;
    [SerializeField] GameObject cannon;
    float shootInterval = 4.0f;
    int hp = 1;
    IEnumerator shootToPlayer()
    {
        while (true)
        {
            GameObject bullet = BulletObjectPool.Instance.GetPooledEnemyBullet();
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().setMove1(bulletSpeed, controlCatMove.Instance.transform.position - cannon.transform.position, Vector3.zero, 0);
            bullet.transform.position = cannon.transform.position;
            yield return new WaitForSeconds(shootInterval);
        }
    }
    // Start is called before the first frame update
    public void startShooting()
    {
        StartCoroutine(shootToPlayer());
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
            Destroy(this.gameObject);
        }
    }
}
