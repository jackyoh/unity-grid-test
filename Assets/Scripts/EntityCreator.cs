using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using UnityEngine.Tilemaps;

public class EntityCreator : MonoBehaviour {
    private EntityManager entityManager;
    public TileBase tileToPlace;
    private Tilemap tilemap;
    public GameObject gridInfoPrefab;

    void Start() {
        tilemap = GetComponent<Tilemap>();
        StartCoroutine(CheckInitialization());
    }

    IEnumerator CheckInitialization() {
        yield return new WaitForSeconds(0.5f);
        this.entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        for (int x = -6; x <= 7; x++) {
            for (int y = -10; y <= 12; y++) {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, tileToPlace);
                
                GameObject gridGameObject = Instantiate(gridInfoPrefab, tilemap.GetCellCenterWorld(tilePosition), Quaternion.identity);
                
                Vector2 newSize = new Vector2(0.5f, 0.4f);
                BoxCollider2D boxCollider2D = gridGameObject.AddComponent<BoxCollider2D>();
                boxCollider2D.isTrigger = true;
                boxCollider2D.size = newSize;

                gridGameObject.name = "A" + x + "," + y;

                Entity entity = this.entityManager.CreateEntity(typeof(CellInfo));
                CellInfo cellInfo = this.entityManager.GetComponentData<CellInfo>(entity);
                cellInfo.name = "A" + x + "," + y;
                cellInfo.x = x;
                cellInfo.y = y;
                entityManager.SetComponentData(entity, cellInfo);
            }
        }

        // To get entity size
        /*EntityQuery entityQuery = entityManager.CreateEntityQuery(typeof(CellInfo));
        NativeArray<Entity> entities = entityQuery.ToEntityArray(Allocator.TempJob);
        Debug.Log(entities.Length);*/

        /*EntityQuery query = entityManager.CreateEntityQuery(typeof(CellInfo));
        query.SetSharedComponentFilter(new CellInfo { 
            x = 1.0f,
            y = 2.0f
        });*/

        /*NativeArray<Entity> entities = query.ToEntityArray(Allocator.TempJob);
        if (entities.Length > 0) {
            Debug.Log(entities[0]);
            CellInfo result = entityManager.GetSharedComponentManaged<CellInfo>(entities[0]);
            Debug.Log(result.x);
            Debug.Log(result.y);
        }*/
    }
}

public struct CellInfo : IComponentData {
    public FixedString64Bytes name;
    public float x;
    public float y;
}
