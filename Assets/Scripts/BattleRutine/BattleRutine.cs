using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleRutine : MonoBehaviour
{
    [SerializeField] List<Transform> _spawnPoints;
    private IDataSource _source;
    private SectorData _sectorData;

    private void Start()
    {
        _source = new DataSource();
        _sectorData = _source.GetSectorData(Global.CurrentSectorID);
        foreach(EntitySpawner spawner in _sectorData.Monsters)
        {
            if (_spawnPoints.Count == 0)
                break;
            var numberSpawned = 0;
            if (spawner.MaxSpawn == 0)
                numberSpawned = 1;
            else
                numberSpawned = Random.Range(spawner.MinSpawn, spawner.MaxSpawn + 1);
            
            for (int i = 0; i < numberSpawned; i++)
            {
                if (_spawnPoints.Count == 0)
                    break;
                var spawnPointIndex = Random.Range(0, _spawnPoints.Count);
                var spawnPoint = _spawnPoints[spawnPointIndex];
                var avatar = AvatarFactory.CreateMob(spawner.EntityType);
                avatar.transform.position = spawnPoint.position;
                _spawnPoints.Remove(spawnPoint);
            }

        }
    }
    public void FinishBattle()
    {
        SceneManager.LoadScene(Global.CurrentMapName);
    }
}
