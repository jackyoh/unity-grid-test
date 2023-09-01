using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;

public class SquareAuthoring : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityQuery query = entityManager.CreateEntityQuery(typeof(CellInfo));
        NativeArray<Entity> entities = query.ToEntityArray(Allocator.TempJob);
        for (int i = 0; i < entities.Length; i++) {
            CellInfo cellInfo = entityManager.GetComponentData<CellInfo>(entities[i]);
            if (cellInfo.name == other.name) {
                Debug.Log("(" + cellInfo.x + "," + cellInfo.y + ")");
            }
        }

        /*EntityQuery query = entityManager.CreateEntityQuery(typeof(CellInfo));
        query.SetSharedComponentFilter(new CellInfo { 
            x = 1.0f,
            y = 2.0f
        });*/

        /*query.SetSharedComponentFilter(new CellInfo { 
            name = other.name
        });
        NativeArray<Entity> entities = query.ToEntityArray(Allocator.TempJob);
        Debug.Log(entities.Length);*/
        /*if (entities.Length > 0) {
            CellInfo result = entityManager.GetSharedComponentManaged<CellInfo>(entities[0]);
            Debug.Log("(" + result.x + "," + result.y + ")");

        }*/
    }
}
