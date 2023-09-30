using System;
using UnityEngine;
using UnityEngine.U2D;

namespace MainView
{

    [CreateAssetMenu(fileName = "HumanSpriteCollection", menuName = "HumanSpriteCollection", order = 0)]
    public class HumanSpriteCollection : ScriptableObject
    {
        [SerializeField]
        protected SpriteAtlas m_faceSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_eyesSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_wyebrowsSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_mouthSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_noseSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleHaircutSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleHaircutSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleBeardSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleHeaddressSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleHeaddressSpriteAtlas;

        //Точка входа в систему подбора спрайтов
        public Sprite GetSpriteFromSpriteCollection(SpriteAtlasType atlasType, string spriteName)
        {
            return GetSpriteAtlasByType(atlasType).GetSprite(spriteName);
        }

        private SpriteAtlas GetSpriteAtlasByType(SpriteAtlasType atlasType)
        {
            switch (atlasType)
            {
                case SpriteAtlasType.Face:
                    return m_faceSpriteAtlas;
                case SpriteAtlasType.Eyes:
                    return m_eyesSpriteAtlas;
                case SpriteAtlasType.Eyebrows:
                    return m_wyebrowsSpriteAtlas;
                case SpriteAtlasType.Mouth:
                    return m_mouthSpriteAtlas;
                case SpriteAtlasType.Nose:
                    return m_noseSpriteAtlas;
                case SpriteAtlasType.MaleHaircut:
                    return m_maleHaircutSpriteAtlas;
                case SpriteAtlasType.FemaleHaircut:
                    return m_femaleHaircutSpriteAtlas;
                case SpriteAtlasType.MaleBeard:
                    return m_maleBeardSpriteAtlas;
                case SpriteAtlasType.MaleHeaddress:
                    return m_maleHeaddressSpriteAtlas;
                case SpriteAtlasType.FemaleHeaddress:
                    return m_femaleHeaddressSpriteAtlas;
                default:
                    throw new ArgumentOutOfRangeException(nameof(atlasType), atlasType, null);
            }
        }
    }
}