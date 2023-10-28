using System.Collections;
using UnityEngine;

public class enemy1 : MonoBehaviour, enemyParent
{
    float bulletSpeed = 0.7f;
    [SerializeField] GameObject cannon1;
    [SerializeField] GameObject cannon2;
    float shootInterval = 3.0f;
    int hp = 1;
    IEnumerator shootToPlayer()
    {
        while (true)
        {
            GameObject bullet = BulletObjectPool.Instance.GetPooledEnemyBullet();
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().setMove1(bulletSpeed, controlCatMove.Instance.transform.position - cannon1.transform.position, Vector3.zero, 0);
            bullet.transform.position = cannon1.transform.position;
            bullet = BulletObjectPool.Instance.GetPooledEnemyBullet();
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().setMove1(bulletSpeed, controlCatMove.Instance.transform.position - cannon2.transform.position, Vector3.zero, 0);
            bullet.transform.position = cannon2.transform.position;
            Debug.Log("Shoot!");
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
        if (hp <= 0)
        {
            gameplayManager.Instance.point += 100;
            gameplayManager.Instance.bosspoint -= 100;
            Destroy(this.gameObject);
        }
    }
}
