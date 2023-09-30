using System.Collections.Generic;

namespace MainView
{
    public class HumanModel
    {
        //общие сведения
        private bool m_isMale;
        private bool m_isShouldAccept;

        // названия для спрайтов
        private string m_humanFaceSpriteName;
        private string m_humanEyesSpriteSpriteName;
        private string m_humanEyebrowsSpriteName;
        private string m_humanMouthSpriteName;
        private string m_humanHaircutSpriteName;
        private string m_maleBeardSpriteName;
        private string m_humanHeaddressSpriteName;

        //Карточка
        private string m_humanName;
        private string m_surName;
        private string m_expireDateTo;
        private string m_professionName;
        private string m_cardId;
        private string m_cardFaceSpriteName;
        private string m_cardEyesSpriteSpriteName;
        private string m_cardEyebrowsSpriteName;
        private string m_cardMouthSpriteName;
        private string m_cardHaircutSpriteName;
        private string m_cardBeardSpriteName;
        private string m_cardHeaddressSpriteName;

        // приложения на телефоне
        private bool m_wasInBannedSite;
        private bool m_haveVirus;
        private Dictionary<int, string> m_appSpriteName;

        public HumanModel(bool mIsMale, bool mIsShouldAccept, string mHumanFaceSpriteName,
            string mHumanEyesSpriteSpriteName, string mHumanEyebrowsSpriteName, string mHumanMouthSpriteName,
            string mHumanHaircutSpriteName, string mMaleBeardSpriteName, string mHumanHeaddressSpriteName, string mHumanName,
            string mSurName, string mExpireDateTo, string mProfessionName, string mCardId, string mCardFaceSpriteName,
            string mCardEyesSpriteSpriteName, string mCardEyebrowsSpriteName, string mCardMouthSpriteName, string mCardHaircutSpriteName,
            string mCardBeardSpriteName, string mCardHeaddressSpriteName, bool mWasInBannedSite, bool mHaveVirus,
            Dictionary<int, string> mAppSpriteName)
        {
            m_isMale = mIsMale;
            m_isShouldAccept = mIsShouldAccept;
            m_humanFaceSpriteName = mHumanFaceSpriteName;
            m_humanEyesSpriteSpriteName = mHumanEyesSpriteSpriteName;
            m_humanEyebrowsSpriteName = mHumanEyebrowsSpriteName;
            m_humanMouthSpriteName = mHumanMouthSpriteName;
            m_humanHaircutSpriteName = mHumanHaircutSpriteName;
            m_maleBeardSpriteName = mMaleBeardSpriteName;
            m_humanHeaddressSpriteName = mHumanHeaddressSpriteName;
            m_humanName = mHumanName;
            m_surName = mSurName;
            m_expireDateTo = mExpireDateTo;
            m_professionName = mProfessionName;
            m_cardId = mCardId;
            m_cardFaceSpriteName = mCardFaceSpriteName;
            m_cardEyesSpriteSpriteName = mCardEyesSpriteSpriteName;
            m_cardEyebrowsSpriteName = mCardEyebrowsSpriteName;
            m_cardMouthSpriteName = mCardMouthSpriteName;
            m_cardHaircutSpriteName = mCardHaircutSpriteName;
            m_cardBeardSpriteName = mCardBeardSpriteName;
            m_cardHeaddressSpriteName = mCardHeaddressSpriteName;
            m_wasInBannedSite = mWasInBannedSite;
            m_haveVirus = mHaveVirus;
            m_appSpriteName = mAppSpriteName;
        }
    }
}