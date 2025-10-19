using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject background;
    public float spawnDist = 30f;
    public float backGroundWidth = 40f;

    //test this
    private float nextSpawnX = 35f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraTransform.position.x + spawnDist > nextSpawnX)
        {
            SpawnBackGround();
        }

        foreach(GameObject obj in BackGroundPooling.SharedInstance.pooledObjects)
        {
            if(obj.activeInHierarchy && obj.transform.position.x < cameraTransform.position.x - 50f)
            {
                obj.SetActive(false);
            }
        }
    }

    void SpawnBackGround()
    {
        GameObject backGround = BackGroundPooling.SharedInstance.GetPooledObject();

        if(backGround != null)
        {
            backGround.transform.position = new Vector3(nextSpawnX, 1.6f, 0f);
            backGround.SetActive(true);

            nextSpawnX += backGroundWidth;
        }
    }
}
