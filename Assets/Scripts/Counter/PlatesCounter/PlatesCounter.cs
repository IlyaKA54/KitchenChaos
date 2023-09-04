using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : Counter
{
    [SerializeField] private KitchenObjectSO _plateTemplate;
    [SerializeField] private int _platesSpawnedAmountMax;
    [SerializeField] private float _delayBetweenSpawnObject;
    [SerializeField] private float _distanceBetweenObjects;

    private List<KitchenObject> _plates;
    private float _accumulatedTime;
    private Transform _createPoint;

    private void Start()
    {
        _createPoint = SpawnPoint;
        _plates = new List<KitchenObject>();
    }

    private void Update()
    {
        if (_plates.Count < _platesSpawnedAmountMax)
        {
            _accumulatedTime += Time.deltaTime;

            if (_accumulatedTime >= _delayBetweenSpawnObject)
            {
                _accumulatedTime = 0;

                var newObject = CreatePlate(_createPoint);

                _plates.Add(newObject);

                _createPoint = newObject.transform;
            }
        }
    }
    public override void Interact()
    {
        if (_plates.Count > 0 && !CurrentUser.HasKitchenObject)
        {
            GiveKitchenObject(_plates[_plates.Count - 1]);

            ChangeCreatePoint();
        }
    }

    private void GiveKitchenObject(KitchenObject kitchenObject)
    {
        _plates.Remove(kitchenObject);

        CurrentUser.SetKitchenObject(kitchenObject);
    }

    private void ChangeCreatePoint()
    {
        if (_plates.Count > 0)
            _createPoint = _plates[_plates.Count - 1].transform;
        else
            _createPoint = SpawnPoint;
    }

    private KitchenObject CreatePlate(Transform buildPoint)
    {
        return Instantiate(_plateTemplate.KitchenObject, GetBuildPoint(buildPoint), Quaternion.identity, SpawnPoint);
    }

    private Vector3 GetBuildPoint(Transform buildPoint)
    {
        return new Vector3(buildPoint.position.x, buildPoint.position.y + _distanceBetweenObjects, buildPoint.position.z);
    }
}
