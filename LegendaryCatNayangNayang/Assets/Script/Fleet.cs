using System.Collections;
using UnityEngine;

public class Fleet : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    [SerializeField] float zlimit = 26;
    public bool isSummonedbyBoss = false;
    // Start is called before the first frame update
    IEnumerator movefleet()
    {
        while (this.transform.position.z >= zlimit)
        {
            this.transform.position += Vector3.back * movespeed;
            yield return null;
        }
        foreach (Transform ship in this.transform)
        {
            enemyParent e = ship.GetComponent<enemyParent>();
            e.startShooting();
        }
        yield return null;
    }
    void Start()
    {
        StartCoroutine(movefleet());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount == 0)
        {
            if (!isSummonedbyBoss)
            {
                if (gameplayManager.Instance.bosspoint <= 0)
                    FleetSpawner.Instance.spawnBoss();
                else
                    FleetSpawner.Instance.spawnfleet();
            }
            Destroy(this.gameObject);
        }
    }
}
