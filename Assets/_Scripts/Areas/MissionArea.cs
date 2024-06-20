using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionArea : MonoBehaviour
{
    [SerializeField] private Transform _missionCubesArea;
    [SerializeField] private Transform _playerCubesArea;
    [SerializeField] private Transform _playerTriggerArea;

    private List<GameObject> _missionCubes = new List<GameObject>();
    private List<GameObject> _playerCubes = new List<GameObject>();
    private List<GameObject> _playerTriggerCubes = new List<GameObject>();
  

    private void Start()
    {
        CreateLevel();
        StartLevel();
        
    }

    public void CheckSimilarityAreas()
    {
        int activeCubes = 0;
        for(int i = 0; i < _missionCubes.Count; i++)
        {
            if (_missionCubes[i].activeSelf == _playerCubes[i].activeSelf)
            {
                activeCubes++;
            }
        }
        if(activeCubes == 4) 
        {
            Debug.Log("The drawing is identical.");
        }
        else
        {
            Debug.Log("The drawing is not identical. Cubes activated = " +  activeCubes);
        }
    }

    private void StartLevel()
    {
        for(int i = 0; i < 4; i++)
        {
            bool isActivated = false;
            while(!isActivated)
            {
                int random = Random.Range(0, 9);
                if (!_missionCubes[random].activeSelf)
                {
                    _missionCubes[random].SetActive(true);
                    isActivated = true;
                }
            }
        }
    }

    private void CreateLevel()
    {
        CreateArea(_missionCubes, _missionCubesArea);
        CreateArea(_playerCubes, _playerCubesArea);
        CreateArea(_playerTriggerCubes, _playerTriggerArea);
    }

    private void CreateArea(List<GameObject> cubes, Transform area)
    {
        foreach (Transform cubeArea in area)
        {
            cubes.Add(cubeArea.gameObject);
        }     
    }
}
