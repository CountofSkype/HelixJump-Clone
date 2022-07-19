using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Player player;
    public Transform Finish;
    public Slider Slider;
    public float FinishDistance = 1f;
    private float _startPos;
    private float _minPos;

    private void Start()
    {
        _startPos = player.transform.position.y;
    }
    private void Update()
    {
        _minPos = Mathf.Min(_minPos, player.transform.position.y);
        float finishY = Finish.transform.position.y;
        float part = Mathf.InverseLerp(_startPos, finishY + FinishDistance, _minPos);
        Slider.value = part;
    }
}
