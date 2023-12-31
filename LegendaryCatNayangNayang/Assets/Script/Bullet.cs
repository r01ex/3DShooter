using UnityEngine;

public class Bullet : MonoBehaviour
{
    int moveType;
    Vector3 moveDirection;
    Vector3 accelDirection;
    float moveSpeed;
    float accelAmount;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void setMove1(float moveSpeed, Vector3 moveDirection, Vector3 accelDirection, float accelAmount)
    {
        this.moveSpeed = moveSpeed;
        this.moveDirection = moveDirection;
        this.accelDirection = accelDirection;
        this.accelAmount = accelAmount;
        rb.velocity = moveDirection * moveSpeed;
    }
    void move1()
    {
        rb.velocity += accelDirection * accelAmount * Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        switch (moveType)
        {
            case 1:
                move1();
                break;
        }
        if (this.transform.position.z > 70 || this.transform.position.z < -20)
        {
            DestroySelf();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }
    public void DestroySelf()
    {
        this.transform.rotation = Quaternion.identity;
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        //  this.gameObject.GetComponent<Animator>().Play("BulletFly");
    }
}
