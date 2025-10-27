using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject platform;
    public float spawnDist = 40f;
    public float platformWidth = 40f;
    public float nextWidth;

    private float nextSpawnX = 45f; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTransform.position.x + spawnDist > nextSpawnX)
        {
            spawnPlatform();
        }

        foreach (GameObject obj in BackGroundPooling.SharedInstance.pooledObjects)
        {
            if (obj.activeInHierarchy && obj.transform.position.x < cameraTransform.position.x - 50f)
            {
                obj.SetActive(false);
            }
        }
    }

    void spawnPlatform()
    {
        GameObject platform = PlatformPooling.SharedInstance.GetPooledObject();

        nextWidth = Random.Range(40, 50);

        if (platform != null)
        {
            platform.transform.position = new Vector3(nextSpawnX, -6.7f, 0f);
            platform.SetActive(true);

            nextSpawnX += nextWidth;
        }
    }
}
