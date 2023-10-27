using UnityEngine;

namespace GamePlay.House.Cells.Root
{
    [DisallowMultipleComponent]
    public class Cell : MonoBehaviour, ICell
    {
        [SerializeField] private int _id;
        [SerializeField] private GameObject _freeBackground;
        [SerializeField] private GameObject _takenBackground;
        [SerializeField] private Transform _cameraPoint;

        public int Id => _id;
        public Transform Transform => transform;
        public Transform CameraPoint => _cameraPoint;

        public void SetId(int id)
        {
            _id = id;
        }

        public void OnTaken()
        {
            _freeBackground.SetActive(false);
            _takenBackground.SetActive(true);
        }

        public void OnFreed()
        {
            _freeBackground.SetActive(true);
            _takenBackground.SetActive(false);
        }
    }
}