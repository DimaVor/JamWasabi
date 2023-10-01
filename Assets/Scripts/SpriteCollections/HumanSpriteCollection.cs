using System;
using System.Collections.Generic;
using SpriteCollections;
using UnityEditor;
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
        protected SpriteAtlas m_bodySpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_eyesSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleEyebrowsSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleEyebrowsSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleLipsSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleLipsSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleNoseSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleNoseSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleClothesSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleClothesSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleHaircutSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleHaircutSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleBeardSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_maleGlassesSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleGlassesSpriteAtlas;
        [SerializeField]
        protected SpriteAtlas m_femaleHeaddressSpriteAtlas;


        [SerializeField] private List<string> m_spriteNames;

        //Точка входа в систему подбора спрайтов
        public Sprite GetSpriteFromSpriteCollection(SpriteAtlasType atlasType, string spriteName)
        {
            return GetSpriteAtlasByType(atlasType).GetSprite(spriteName);
        }
        public void GetAllSpriteNames(SpriteAtlasType atlasType)
        {
            Sprite[] sprites = new Sprite[GetSpriteAtlasByType(atlasType).spriteCount];
            GetSpriteAtlasByType(atlasType).GetSprites(sprites);

            int counter = 0;
            m_spriteNames.Clear();

            foreach (Sprite sprite in sprites)
            {
                //найти путь
                string path = AssetDatabase.GetAssetPath(sprite);
                string newName = atlasType + "_" + counter;
                AssetDatabase.RenameAsset(path, newName);
                m_spriteNames.Add(newName);
            }
        }

        private SpriteAtlas GetSpriteAtlasByType(SpriteAtlasType atlasType)
        {
            return atlasType switch
            {
                SpriteAtlasType.Face => m_faceSpriteAtlas,
                SpriteAtlasType.Body => m_bodySpriteAtlas,
                SpriteAtlasType.Eyes => m_eyesSpriteAtlas,
                SpriteAtlasType.MaleEyebrows => m_maleEyebrowsSpriteAtlas,
                SpriteAtlasType.FemaleEyebrows => m_femaleEyebrowsSpriteAtlas,
                SpriteAtlasType.MaleLips => m_maleLipsSpriteAtlas,
                SpriteAtlasType.FemaleLips => m_femaleLipsSpriteAtlas,
                SpriteAtlasType.MaleNose => m_maleNoseSpriteAtlas,
                SpriteAtlasType.FemaleNose => m_femaleNoseSpriteAtlas,
                SpriteAtlasType.MaleHaircut => m_maleHaircutSpriteAtlas,
                SpriteAtlasType.FemaleHaircut => m_femaleHaircutSpriteAtlas,
                SpriteAtlasType.MaleBeard => m_maleBeardSpriteAtlas,
                SpriteAtlasType.FemaleHeaddress => m_femaleHeaddressSpriteAtlas,
                SpriteAtlasType.MaleClothes => m_maleClothesSpriteAtlas,
                SpriteAtlasType.FemaleClothes => m_femaleClothesSpriteAtlas,
                SpriteAtlasType.MaleGlasses => m_maleGlassesSpriteAtlas,
                SpriteAtlasType.FemaleGlasses => m_femaleGlassesSpriteAtlas,
                _ => throw new ArgumentOutOfRangeException(nameof(atlasType), atlasType, null)
            };
        }
    }
}