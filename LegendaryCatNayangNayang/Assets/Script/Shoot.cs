using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float shootInterval;
    public int bulletType = 1;
    public bool isShooting = false;

    // Start is called before the first frame update
    public IEnumerator Shootbullet()
    {
        while (true)
        {
            if (bulletType == 1 && isShooting)
            {
                GameObject bullet = BulletObjectPool.Instance.GetPooledPlayerBullet();
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().setMove1(bulletSpeed, Vector3.forward, Vector3.zero, 0);
                bullet.transform.position = gameObject.transform.position;
            }

            yield return new WaitForSeconds(shootInterval);
        }

    }
    private void Start()
    {
        StartCoroutine(Shootbullet());
    }
}
