using System.Collections;
using UnityEngine;

public class enemy3 : MonoBehaviour, enemyParent
{
    float timeBeforeCharge = 3.0f;
    float speedBeforeCharge = 0.3f;
    [SerializeField] float speedAfterCharge = 1.5f;
    [SerializeField] Rigidbody rb;
    int hp = 2;
    IEnumerator charge()
    {
        rb.velocity = Vector3.back * speedBeforeCharge;
        yield return new WaitForSeconds(timeBeforeCharge);
        rb.velocity = Vector3.back * speedAfterCharge;
    }
    // Start is called before the first frame update
    public void startShooting()
    {
        StartCoroutine(charge());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < -20)
        {
            Destroy(this.gameObject);
        }
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
            gameplayManager.Instance.point += 200;
            gameplayManager.Instance.bosspoint -= 100;
            Destroy(this.gameObject);
        }
    }
}
