using UnityEngine;

public class TileBase : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    CapsuleCollider2D capsuleCollider2D;
    [SerializeField] float moveSpeed = 5f;
    private Vector2 direction = Vector2.right;
    private Vector3 leftEdge;
    private Vector3 rightEdge;

    private TileSO tileSO;

    private int tileIndex;
    private int colliderCount = 0;
    private bool isStayWithPlayer = false;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite breakingSprite;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //SetStartPosition();
    }
    public void Initialize(TileSO data)
    {
        tileSO = data;
        tileIndex = tileSO.tileIndex;
    }

    public int GetTileInDex() { return tileIndex; }
    public int GetScore()
    {
        return tileSO.scoreValue;
    }
    
    public void SetTileInDex(int index) { tileIndex = index; }
    public BoxCollider2D GetBoxCollider2D() { return boxCollider2D; }
    public CapsuleCollider2D GetCapsuleCollider2D() {return capsuleCollider2D; }

    public TileSO GetTileSO() { return tileSO; }
    

    public void ResetTileValue()
    {
        boxCollider2D.enabled = true;
        capsuleCollider2D.enabled = true;
        colliderCount = 0;
        isStayWithPlayer = false;
        spriteRenderer.sprite = defaultSprite;
    }
    private void Update()
    {
        if (tileSO.tileIndex != 0)
        {
            OnMove();
        }
        //RemoveTilesOutsideScreen();
    }

    void OnMove()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        leftEdge = Camera.main.WorldToViewportPoint(new Vector3((transform.position.x - transform.localScale.x / 2 ), transform.position.y, transform.position.z));
        rightEdge = Camera.main.WorldToViewportPoint(new Vector3((transform.position.x + transform.localScale.x / 2), transform.position.y, transform.position.z));

        float buffer = 0.05f;

        if (leftEdge.x <= 0 || rightEdge.x >= 1 )
        {
            direction *= -1;

            if(isStayWithPlayer) ProcessColliderCouting();

            Vector3 clampedPosition = transform.position;
            float minX = Camera.main.ViewportToWorldPoint(new Vector3(buffer, 0, 0)).x;
            float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1 - buffer, 0, 0)).x;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
            transform.position = clampedPosition;
        }
    }

    
        

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            //Debug.Log("Trigger exit");
            boxCollider2D.enabled = false;
            capsuleCollider2D.enabled = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            isStayWithPlayer = true;
        }

        // process collider of tile 
        if (colliderCount == 2)
        {
            spriteRenderer.sprite = breakingSprite;
        }
        else if (colliderCount == 3)
        {
            collision.gameObject.transform.SetParent(null);
            gameObject.SetActive(false);
        }
    }

    private void ProcessColliderCouting()
    {
        colliderCount++;
    }

    private void  OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            other.transform.SetParent(this.transform);
            // jump once
            player.CanFly = true;
            player.SetIsFlying(false);
            Debug.Log(this.tileIndex);
            if (this.tileSO.tileIndex != 0)
            {
                TileManager.Instance.ProcessTilesAfterPlayerJump(this.tileIndex);   
                TileManager.Instance.SpawnNewTiles(this.tileIndex);
                TileManager.Instance.OnMoveWhenChange(this.tileIndex);

                // update score
                ScoreManager.Instance.UpdateScore(this.tileIndex - 1);
               
                this.tileIndex = 1;
                Debug.Log("after change + " + this.tileIndex);
            }

            

        }
    }

    
}
