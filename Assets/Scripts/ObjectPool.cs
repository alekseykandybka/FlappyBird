using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private int _saveDistance;

    private Camera _camera;
    
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }

    protected void DissableObjectAbroadScreen()
    {
        Vector3 dissablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));
        
        foreach (var item in _pool)
        {
            if(item.activeSelf == true)
            {
                {
                    if (item.transform.position.x < dissablePoint.x - _saveDistance)
                        item.SetActive(false);
                }
            }
        }
    }
}
