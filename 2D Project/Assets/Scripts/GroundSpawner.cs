using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject ground;
    public float spawnDist = 10f;
    public float groundWidth = 2f;

    private float nextSpawnX = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraTransform.position.x + spawnDist > nextSpawnX)
        {
            SpawnGround();
            //ground.SetActive(false);
        }

        foreach(GameObject obj in ObjectPooling.SharedInstance.pooledObjects)
        {
            if(obj.activeInHierarchy && obj.transform.position.x < cameraTransform.position.x - 10f)
            {
                obj.SetActive(false);
            }
        }
    }

    void SpawnGround()
    {
        GameObject ground = ObjectPooling.SharedInstance.GetPooledObject();

        if (ground != null)
        {
            ground.transform.position = new Vector3(nextSpawnX, 2.39f, 0f);
            ground.SetActive(true);

            nextSpawnX += groundWidth;
        }
    }
}
