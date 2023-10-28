using UnityEngine;

public class gameplayManager : MonoBehaviour
{
    #region singleton
    public static gameplayManager Instance;
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
    public int point = 0;
    public int bosspoint = 1000;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
