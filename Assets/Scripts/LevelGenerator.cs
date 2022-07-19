using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] StagePrefabs;
    public GameObject[] FirstStagePrefab;
    public int MinStages;
    public int MaxStages;
    public float DistanceBetweenStages;
    public Transform Finish;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;

    private void Awake()
    {
        int platformsCount = Random.Range(MinStages, MaxStages + 1);
        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = Random.Range(0, StagePrefabs.Length);
            GameObject stagePrefab = i == 0 ? FirstStagePrefab[(int)Random.Range(0f, 2f)] : StagePrefabs[prefabIndex];
            GameObject stage = Instantiate(stagePrefab, transform);
            stage.transform.localPosition = CalculateStagePosition(i);
            if (i > 0)
                stage.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }

        Finish.localPosition = CalculateStagePosition(platformsCount);

        CylinderRoot.localScale = new Vector3 (1, platformsCount * DistanceBetweenStages + ExtraCylinderScale, 1);
    }
    private Vector3 CalculateStagePosition(int i)
        {
            return new Vector3(0, -DistanceBetweenStages * i, 0);
        }
}
