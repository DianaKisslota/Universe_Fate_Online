using EasyRoads3Dv3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleRutine : MonoBehaviour
{
    [SerializeField] List<Transform> _spawnPoints;
    [SerializeField] Transform _character;
    [SerializeField] Transform _cameraHolder;

    [SerializeField] private int _cameraScrollSpeed = 10;
    [SerializeField] private int _cameraRotateSpeed = 50;
    [SerializeField] private float _frontFrontier = 1;
    [SerializeField] private float _backFrontier = -7;
    [SerializeField] private float _leftFrontier = -2;
    [SerializeField] private float _rightFrontier = 2.5f;
    [SerializeField] private float _maxHeigh = 6;
    [SerializeField] private float _minHeigh = 1;

    private IDataSource _source;
    private SectorData _sectorData;

    private void Start()
    {
        _source = new DataSource();
        _sectorData = _source.GetSectorData(Global.CurrentSectorID);
        foreach (EntitySpawner spawner in _sectorData.Monsters)
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
                avatar.transform.LookAt(_character.transform);
                _spawnPoints.Remove(spawnPoint);
            }

        }
    }

    private void Update()
    {
        Quaternion ang = _cameraHolder.rotation;

        if (Input.GetKey(KeyCode.E))
        {
            ang.eulerAngles = new Vector3(ang.eulerAngles.x, _cameraHolder.eulerAngles.y + _cameraRotateSpeed * Time.deltaTime, ang.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            ang.eulerAngles = new Vector3(ang.eulerAngles.x, _cameraHolder.eulerAngles.y - _cameraRotateSpeed * Time.deltaTime, ang.eulerAngles.z);
        }

        _cameraHolder.rotation = ang;

        //Vector3 forward = _cameraHolder.TransformDirection(Vector3.forward);


        var newPosition = _cameraHolder.position;

        if (Input.GetKey(KeyCode.A))
        {
            newPosition += _cameraHolder.TransformDirection(Vector3.left) * _cameraScrollSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += _cameraHolder.TransformDirection(Vector3.right) * _cameraScrollSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += _cameraHolder.TransformDirection(Vector3.forward) * _cameraScrollSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition += _cameraHolder.TransformDirection(Vector3.back) * _cameraScrollSpeed * Time.deltaTime;
        }

        if (newPosition.x >= _leftFrontier && newPosition.x <= _rightFrontier && newPosition.z <= _frontFrontier && newPosition.z >= _backFrontier)
            _cameraHolder.position = newPosition;


        float wheelScroll = Input.GetAxis("Mouse ScrollWheel");

        if (wheelScroll < 0 && _cameraHolder.position.y <= _maxHeigh || wheelScroll > 0 && _cameraHolder.position.y >= _minHeigh)
        {
            _cameraHolder.Translate(Vector3.up * -wheelScroll);
        }



    }
    public void FinishBattle()
    {
        SceneManager.LoadScene(Global.CurrentMapName);
    }
}
