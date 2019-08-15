using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] blocks;

    private void Start()
    {
        InstantiateBlock();
    }

    public void InstantiateBlock()
    {
        GameObject blockToSpawn = blocks[Random.Range(0, 2)];
        Instantiate(blockToSpawn, blockToSpawn.transform.position, Quaternion.identity);
    }
}
