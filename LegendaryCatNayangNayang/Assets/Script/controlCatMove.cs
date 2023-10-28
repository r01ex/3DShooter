using UnityEngine;
public class controlCatMove : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float slowSpeed;
    [SerializeField] Shoot shoot;
    Coroutine shootingCoroutine;
    public int powerBulletNumber = 1;
    public int hp = 3;
    [SerializeField] GameObject explosion;
    #region singleton
    public static controlCatMove Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    void FixedUpdate()
    {
        Vector3 vector3 = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vector3 += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            vector3 += Vector3.left;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vector3 += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vector3 += Vector3.back;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            shoot.isShooting = true;
            gameObject.transform.Translate(vector3 * slowSpeed);
        }
        else
        {
            shoot.isShooting = false;
            gameObject.transform.Translate(vector3 * Speed);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && powerBulletNumber > 0)
        {
            shoot.PowerShot();
            powerBulletNumber--;
        }
    }
    void die()
    {
        Debug.Log("dead");
        GameObject explode = Instantiate(explosion);
        explode.transform.position = this.transform.position;
        Time.timeScale = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            die();
        }
        if (other.tag == "EnemyBullet")
        {
            other.gameObject.GetComponent<Bullet>().DestroySelf();
            this.hp--;
        }
        if (hp < 0)
        {
            die();
        }
    }
}
