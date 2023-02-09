using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    [RequireComponent(typeof(Image))]
    public class BackgroundAnimator : MonoBehaviour
    {
        [SerializeField] private Image image;

        [Range(0.1f, 10f)]
        [SerializeField] private float loopTime = 3f;

        private void OnValidate()
        {
            if (image == null)
                this.image = base.GetComponent<Image>();
        }

        private void Start()
        {
            this.PlayColorAnimation();
        }

        private void PlayColorAnimation()
        {
            this.image.DOColor(Random.ColorHSV(), this.loopTime)
                .OnComplete(this.PlayColorAnimation);
        }
    }
}