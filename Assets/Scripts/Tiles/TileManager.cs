using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    Vector3 spawnPosition;
    private float tileHeight;
    private float screenHeight;
    private float screenWidth; // mấy cái biến screen này em có thể tạo class khác để chứa cho clean nhé,
                               // với cái này hình như có API lấy luôn được anh cmt ở dưới
    private float randomX;
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
        screenHeight = Camera.main.orthographicSize * 2; //=Screen.height;
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect * 2; //=Screen.width;

        tileHeight = screenHeight / 4;
        spawnPosition = new Vector3(transform.position.x, screenHeight / 4, transform.position.z);
        InitializeTiles();
    }

    // that's ok
    private void InitializeTiles()
    {
        GameObject tmp = ObjectPool.instance.GetPoolObject();
        randomX = Random.Range(-screenWidth / 3, screenWidth / 3);
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
            randomX = Random.Range(- screenWidth / 3, screenWidth / 3);
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
                Debug.Log("i = " + i + "tile index = " + data.tileIndex);
                spawnPosition = new Vector3(randomX, spawnPosition.y - tileHeight, transform.position.z);
                //Debug.Log(data.tileIndex);
            }
        }
    }

    public void SpawnNewTiles(int tilePosition)
    {
        if (tilePosition == 2)
        {
            randomX = Random.Range(-screenWidth / 3, screenWidth / 3);
            GameObject tmp = ObjectPool.instance.GetPoolObject();
            if (tmp != null)
            {
                TileSO data = tileSOs[3];
                TileBase tile = tmp.GetComponent<TileBase>();
                
                tile.Initialize(data);
                tmp.transform.position = spawnPosition;
                tmp.transform.rotation = Quaternion.identity;
                tmp.SetActive(true);
                tile.ResetTileValue();
                activeTiles.Add(tmp);
                spawnPosition = new Vector3(transform.position.x, spawnPosition.y - tileHeight, transform.position.z);
            }
        } else
        {
            for (int i = 2; i <= tilePosition; i++)
            {
                randomX = Random.Range(-screenWidth / 3, screenWidth / 3);
                GameObject tmp = ObjectPool.instance.GetPoolObject();
                if (tmp != null)
                {
                    TileSO data = tileSOs[i];
                    TileBase tile = tmp.GetComponent<TileBase>();
                    
                    tile.Initialize(data);
                    tmp.transform.position = spawnPosition;
                    tmp.transform.rotation = Quaternion.identity;
                    tmp.SetActive(true);
                    tile.ResetTileValue();
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
            Debug.Log("i = " + i + " tileindex = " +tileBase.GetTileInDex());
            if (tileBase.GetTileInDex() < tilePosition)
            {
                tile.SetActive(false);
                activeTiles.RemoveAt(i);
                i--;
                Debug.Log("just removed: " + tileBase.GetTileInDex());
            }
            else if (tileBase.GetTileInDex() > tilePosition)
            {
                Debug.Log("before process " + tileBase.GetTileInDex());
                tileBase.SetTileInDex(tilePosition);
                Debug.Log("after process " + tileBase.GetTileInDex());
            }
        }
    }



    public void OnMoveWhenChange(int tilePosition)
    {
        Vector3 smoothedCameraMoving = Vector3.Lerp(Camera.main.transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - tileHeight * (tilePosition - 1), Camera.main.transform.position.z), 1f);
        Camera.main.transform.position = smoothedCameraMoving;
    }

    
}
