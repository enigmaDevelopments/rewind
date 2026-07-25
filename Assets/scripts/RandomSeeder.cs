using UnityEngine;

public class RandomSeeder : MonoBehaviour
{
    void Awake()
    {
        Random.InitState(0);
    }
}
