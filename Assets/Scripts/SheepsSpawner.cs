using UnityEngine;

public class SheepsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sheep;
    [SerializeField] private float sheepNumber;

    private void Awake()
    {
        for (int i = 0; i < sheepNumber; i++)
        {
            Instantiate(sheep, new Vector3(Random.Range(-20f, 20f), 0.25f, Random.Range(-20f, 20f)),
                Quaternion.identity);
        }
    }
}