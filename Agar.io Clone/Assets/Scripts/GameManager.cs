using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [Header("FoodSetting")]
    [SerializeField] static float minX = -97f;
    [SerializeField] static float MaxX = 97f;
    [SerializeField] static float miny = 73f;
    [SerializeField] static float maxY = -73f;

    [SerializeField] private GameObject prefabFood;
    [SerializeField] private int countFood;

    [Space]
    [Header("PLayerSettings")]
    public GameObject player;
    public GameObject cameraP;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < countFood; i++)
        {
            Instantiate(prefabFood, RandomPosition(), Quaternion.identity);
        }
    }

    private Vector2 RandomPosition()
    {
        float posX = Random.Range(minX, MaxX);
        float posY = Random.Range(miny, maxY);
        return new Vector2(posX, posY);
    }

    public void SpawnPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(player.name, RandomPosition(), Quaternion.identity);
        cameraP.SetActive(true);
        cameraP.GetComponent<CameraController>().target = _player.transform;
        _player.GetComponent<SizeController>().enabled = true;
        _player.GetComponent<PlayerController>().enabled = true;
    }
}
