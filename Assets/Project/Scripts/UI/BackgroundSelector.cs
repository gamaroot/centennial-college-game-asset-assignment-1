using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class BackgroundSelector : MonoBehaviour
    {
        [Range(0.3f, 5f)]
        [SerializeField] private float transitionDuration = 2f;

        [SerializeField] private Image backgroundImage;
        [SerializeField] private BackgroundData[] backgrounds;

        private int totalBackgrounds;
        private int currentBackgroundIndex;

        private Tweener tweener;

        private void Awake()
        {
            this.totalBackgrounds = this.backgrounds.Length;
        }

        // Called through inspector
        public void OnBackgroundChange()
        {
            if (++this.currentBackgroundIndex == totalBackgrounds)
                this.currentBackgroundIndex = 0;

            BackgroundData backgroundData = this.backgrounds[this.currentBackgroundIndex];

            this.backgroundImage.sprite = backgroundData.Sprite;

            if (this.tweener != null)
                DOTween.Kill(this.tweener);
            
            this.tweener = DOTween.To(() => this.backgroundImage.pixelsPerUnitMultiplier, 
                                      x => this.backgroundImage.pixelsPerUnitMultiplier = x, 
                                      backgroundData.PixelsPerUnitMultiplier, 
                                      this.transitionDuration);
        }
    }
}