using UnityEngine;

namespace Utils
{
    public enum CameraFitType
    {
        Top,
        Center,
        Bottom
    }

    public enum AspectFitType
    {
        OnlyWide,
        OnlyNotWide,
        Both
    }

    public class CameraFitter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CameraFitType _cameraFitType;
        [SerializeField] private AspectFitType _aspectFitType;
        [SerializeField] private float _defaultAspect = 9f / 16f;

        private void Awake()
        {
            float currentAspect = (float) Screen.width / Screen.height;

            switch (_aspectFitType)
            {
                case AspectFitType.OnlyWide:
                    if (currentAspect > _defaultAspect)
                        return;
                    break;
                case AspectFitType.OnlyNotWide:
                    if (currentAspect <= _defaultAspect)
                        return;
                    break;
                case AspectFitType.Both:
                    break;
            }

            float originalSize = _camera.orthographicSize;
            _camera.orthographicSize = _camera.orthographicSize * _defaultAspect / currentAspect;

            int direction = 0;
            switch (_cameraFitType)
            {
                case CameraFitType.Top:
                    direction = currentAspect < _defaultAspect ? -1 : 1;
                    break;
                case CameraFitType.Center:
                    break;
                case CameraFitType.Bottom:
                    direction = currentAspect < _defaultAspect ? 1 : -1;
                    break;
            }

            _camera.transform.position += new Vector3(0f, direction * Mathf.Abs(originalSize - _camera.orthographicSize));
        }
    }
}