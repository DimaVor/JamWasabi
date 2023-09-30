using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace MainView
{
    public class HumanView : MonoBehaviour
    {
        [SerializeField] private Image m_humanFaceImage;

        [SerializeField] private Image m_humanEyesSpriteImage;

        [SerializeField] private Image m_humanWyebrowsImage;

        [SerializeField] private Image m_humanMouthImage;

        [SerializeField] private Image m_humanHaircutImage;

        [SerializeField] private Image m_maleBeardImage;

        [SerializeField] private Image m_humanHeaddressImage;

        private bool m_isMale;


        public HumanView(Image mHumanFaceImage, Image mHumanWyesSpriteImage, Image mHumanWyebrowsImage, Image mHumanMouthImage, Image mHumanHaircutImage, [CanBeNull] Image mMaleBeardImage, [CanBeNull] Image mHumanHeaddressImage, bool mIsMale)
        {
            m_humanFaceImage = mHumanFaceImage;
            m_humanEyesSpriteImage = mHumanWyesSpriteImage;
            m_humanWyebrowsImage = mHumanWyebrowsImage;
            m_humanMouthImage = mHumanMouthImage;
            m_humanHaircutImage = mHumanHaircutImage;
            m_maleBeardImage = mMaleBeardImage;
            m_humanHeaddressImage = mHumanHeaddressImage;
            m_isMale = mIsMale;

            CheckSex(m_isMale);
        }

        private void CheckSex(bool isMale)
        {

        }



    }
}