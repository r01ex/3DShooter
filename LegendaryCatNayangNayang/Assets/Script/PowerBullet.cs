using UnityEngine;

public class PowerBullet : MonoBehaviour
{
    [SerializeField] float powerShotSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.forward * powerShotSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            other.gameObject.GetComponent<Bullet>().DestroySelf();
        }
    }
}
