using UnityEngine;

public class Loader : MonoBehaviour {

    [SerializeField] protected GameObject gameManager;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }
}
