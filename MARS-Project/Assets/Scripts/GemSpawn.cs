using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    public GameObject GemPrefab;
    public Bounds SpawnVolume;
    public float heightOffset = 1.0f;

    // Update is called once per frame
    private void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            Vector3 randPos;
            randPos.y = transform.position.y + SpawnVolume.extents.y;
            randPos.x = transform.position.x + Random.Range(-SpawnVolume.extents.x * 0.5f, SpawnVolume.extents.x * 0.5f);
            randPos.z = transform.position.z + Random.Range(-SpawnVolume.extents.z * 0.5f, SpawnVolume.extents.z * 0.5f);

            RaycastHit hitInfo;
            if (Physics.Raycast(randPos, Vector3.down, out hitInfo))
            {
                Instantiate(GemPrefab,
                            new Vector3(hitInfo.point.x, hitInfo.point.y + heightOffset, hitInfo.point.z),
                            Quaternion.identity);

            }
        }
        //Instantiate(GemPrefab, );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, SpawnVolume.extents);
    }
}
