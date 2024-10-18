using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    Vector3 spawnPosition;
    private float tileHeight;
    private float screenHeight;
    private float screenWidth; // mấy cái biến screen này em có thể tạo class khác để chứa cho clean nhé,
                               // với cái này hình như có API lấy luôn được anh cmt ở dưới
    private float randomX;

    public float cameraMoveSpeed = 0.1f; // Tốc độ di chuyển camera
    private Vector3 targetPosition; // Vị trí mục tiêu cho camera
    //private int currentTilePosition;
    [SerializeField] Player player;
    //[SerializeField] float speedMove = 5f;

    [SerializeField] List<TileSO> tileSOs;

    private List<GameObject> activeTiles = new List<GameObject>();

    public List<TileSO> GetListTileSOs()
    {
        return tileSOs;
    }
    void Start()
    {

        targetPosition = Camera.main.transform.position;
        // Lấy giá trị từ Screen.height và Screen.width
        screenHeight = Screen.height;
        screenWidth = Screen.width;

        // Chuyển đổi từ screen space sang world space
        Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, Camera.main.nearClipPlane));
        Vector3 bottomLeftCorner = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        // Khoảng cách chiều cao và chiều rộng trong world space
        float worldHeight = topRightCorner.y - bottomLeftCorner.y;
        float worldWidth = topRightCorner.x - bottomLeftCorner.x;

        Debug.Log(worldHeight + " and " + worldWidth);

        tileHeight = worldHeight / 4;
        spawnPosition = new Vector3(transform.position.x, worldHeight / 4, transform.position.z);
        InitializeTiles();
    }

    //private void Update()
    //{
    //    Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);
    //}
    // that's ok
    private void InitializeTiles()
    {
        GameObject tmp = ObjectPool.instance.GetPoolObject();

        float leftLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + (transform.localScale.x / 2);
        float rightLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - (transform.localScale.x / 2);

        randomX = Random.Range(leftLimit, rightLimit);
        if (tmp != null)
        {
            TileSO data = tileSOs[0];
            TileBase tile = tmp.GetComponent<TileBase>();
            tile.Initialize(data);
            tmp.transform.position = spawnPosition;
            tmp.transform.rotation = Quaternion.identity;
            tmp.SetActive(true);
            activeTiles.Add(tmp);
            spawnPosition = new Vector3(randomX, spawnPosition.y - tileHeight, transform.position.z);
        }
        for (int i = 2; i <= 3; i++)
        {
            randomX = Random.Range(leftLimit, rightLimit);
            tmp = ObjectPool.instance.GetPoolObject();
            if (tmp != null)
            {
                TileSO data = tileSOs[i];
                TileBase tile = tmp.GetComponent<TileBase>();
                tile.Initialize(data);
                tmp.transform.position = spawnPosition;
                tmp.transform.rotation = Quaternion.identity;
                tmp.SetActive(true);
                activeTiles.Add(tmp);
                //Debug.Log("i = " + i + "tile index = " + data.tileIndex);
                spawnPosition = new Vector3(randomX, spawnPosition.y - tileHeight, transform.position.z);
                //Debug.Log(data.tileIndex);
            }
        }
    }

    public void SpawnNewTiles(int tilePosition)
    {
        float leftLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + (transform.localScale.x / 2);
        float rightLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - (transform.localScale.x / 2);
        if (tilePosition == 2)
        {
            randomX = Random.Range(leftLimit, rightLimit);
            GameObject tmp = ObjectPool.instance.GetPoolObject();
            if (tmp != null)
            {
                TileSO data = tileSOs[3];
                TileBase tile = tmp.GetComponent<TileBase>();
                //PerfectPoint perfectPoint = tmp.GetComponentInChildren<PerfectPoint>();

                tile.Initialize(data);
                tmp.transform.position = spawnPosition;
                tmp.transform.rotation = Quaternion.identity;

                tmp.SetActive(true);

                tile.ResetTileValue();
                //perfectPoint.ResetPerfectPoint();

                activeTiles.Add(tmp);

                spawnPosition = new Vector3(transform.position.x, spawnPosition.y - tileHeight, transform.position.z);
            }
        } else
        {
            for (int i = 2; i <= tilePosition; i++)
            {
                randomX = Random.Range(leftLimit, rightLimit);
                GameObject tmp = ObjectPool.instance.GetPoolObject();
                if (tmp != null)
                {
                    TileSO data = tileSOs[i];
                    TileBase tile = tmp.GetComponent<TileBase>();
                    //PerfectPoint perfectPoint = tmp.GetComponentInChildren<PerfectPoint>();

                    tile.Initialize(data);
                    tmp.transform.position = spawnPosition;
                    tmp.transform.rotation = Quaternion.identity;

                    tmp.SetActive(true);
                    tile.ResetTileValue();
                    //perfectPoint.ResetPerfectPoint();

                    activeTiles.Add(tmp);

                    spawnPosition = new Vector3(transform.position.x, spawnPosition.y - tileHeight, transform.position.z);
                }
            }
        }
    }

    public void ProcessTilesAfterPlayerJump(int tilePosition)
    {
        //
        Debug.Log("tilePosition = " + tilePosition);
        for (int i = 0; i < activeTiles.Count; i++)
        {
            GameObject tile = activeTiles[i];
            TileBase tileBase = tile.GetComponent<TileBase>();
            //Debug.Log("i = " + i + " tileindex = " +tileBase.GetTileInDex());

            if (tileBase.GetTileInDex() < tilePosition)
            {
                tile.SetActive(false);
                activeTiles.RemoveAt(i);
                i--;
                //Debug.Log("just removed: " + tileBase.GetTileInDex());
            }
            else if (tileBase.GetTileInDex() > tilePosition)
            {
                //Debug.Log("before process " + tileBase.GetTileInDex());
                tileBase.SetTileInDex(tilePosition);
                //Debug.Log("after process " + tileBase.GetTileInDex());
            }
        }
    }



    public void OnMoveWhenChange(int tilePosition)
    {
        Time.timeScale = 0;
        StartCoroutine(MoveCameraToPosition(tilePosition));
        Time.timeScale = 1;
    }

    private IEnumerator MoveCameraToPosition(int tilePosition)
    {
        Vector3 targetPosition = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y - tileHeight * (tilePosition - 1),
            Camera.main.transform.position.z
        );

        float elapsedTime = 0f;
        float duration = 0.5f; // Thời gian di chuyển của camera, có thể điều chỉnh

        Vector3 startingPosition = Camera.main.transform.position;

        while (elapsedTime < duration)
        {
            Camera.main.transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null; // Chờ đến frame tiếp theo
        }

        Camera.main.transform.position = targetPosition; // Đảm bảo camera đến đúng vị trí cuối
    }



}
