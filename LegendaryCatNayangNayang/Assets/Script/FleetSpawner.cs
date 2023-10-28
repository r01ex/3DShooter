using System.Collections.Generic;
using UnityEngine;

public class FleetSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> fleets = new List<GameObject>();
    public int currentLevel = 1;
    [SerializeField] int range1 = 4;
    [SerializeField] int range2 = 7;
    [SerializeField] int range3 = 9;
    [SerializeField] List<GameObject> bosses = new List<GameObject>();
    #region singleton
    public static FleetSpawner Instance;
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
    public GameObject spawnfleet()
    {
        int r = 0;
        if (currentLevel == 1)
        {
            r = Random.Range(0, range1);
        }
        else if (currentLevel == 2)
        {
            r = Random.Range(0, range2);
        }
        else if (currentLevel >= 3)
        {
            r = Random.Range(0, range3);
        }
        return Instantiate(fleets[r]);
    }
    public void spawnBoss()
    {
        if (currentLevel == 1)
        {
            Instantiate(bosses[0]);
        }
        else if (currentLevel == 2)
        {
            Instantiate(bosses[1]);
        }
        else if (currentLevel == 3)
        {
            Instantiate(bosses[2]);
        }
        currentLevel++;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnfleet();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
