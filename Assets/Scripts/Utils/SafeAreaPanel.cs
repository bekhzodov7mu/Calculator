using UnityEngine;

namespace Utils
{
    public class SafeAreaPanel : MonoBehaviour
    {
        private RectTransform _panel;

        private void Awake()
        {
            _panel = GetComponent<RectTransform>();
            ApplySafeArea(Screen.safeArea);
        }

        private void ApplySafeArea(Rect r)
        {
            Vector2 anchorMin = r.position;
            Vector2 anchorMax = r.position + r.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            _panel.anchorMin = anchorMin;
            _panel.anchorMax = anchorMax;
        }
    }
}
