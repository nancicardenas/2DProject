using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject ground;
    public float spawnDist = 30f;
    public float groundWidth = 40f;//18 before 

    private float nextSpawnX = 30f;
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

        //set any ground objects to false once they are off the camera 
        foreach(GameObject obj in GroundPooling.SharedInstance.pooledObjects)
        {
            if(obj.activeInHierarchy && obj.transform.position.x < cameraTransform.position.x - 10f)
            {
                obj.SetActive(false);
            }
        }
    }

    //spawns ground by using object pooling for game optimization 
    void SpawnGround()
    {
        GameObject ground = GroundPooling.SharedInstance.GetPooledObject();

        if (ground != null)
        {
            ground.transform.position = new Vector3(nextSpawnX, 2.39f, 0f);
            ground.SetActive(true);

            nextSpawnX += groundWidth;
        }
    }
}
