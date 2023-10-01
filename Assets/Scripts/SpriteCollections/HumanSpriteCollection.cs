using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace SpriteCollections
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


        [SerializeField] private List<string> m_FaceSpriteNames = new List<string>();
        [SerializeField] private List<string> m_BodySpriteNames = new List<string>();
        [SerializeField] private List<string> m_EyesSpriteNames = new List<string>();
        [SerializeField] private List<string> m_MaleEyebrowsSpriteNames = new List<string>();
        [SerializeField] private List<string> m_FemaleEyebrowsSpriteNames = new List<string>();
        [SerializeField] private List<string> m_MaleLipsSpriteNames = new List<string>();
        [SerializeField] private List<string> m_FemaleLipsSpriteNames = new List<string>();
        [SerializeField] private List<string> m_MaleNoseSpriteNames = new List<string>();
        [SerializeField] private List<string> m_FemaleNoseSpriteNames = new List<string>();
        [SerializeField] private List<string> m_MaleHaircutSpriteNames = new List<string>();
        [SerializeField] private List<string> m_FemaleHaircutSpriteNames = new List<string>();
        [SerializeField] private List<string> m_MaleBeardSpriteNames = new List<string>();
        [SerializeField] private List<string> m_FemaleHeaddressSpriteNames = new List<string>();
        [SerializeField] private List<string> m_MaleClothesSpriteNames = new List<string>();
        [SerializeField] private List<string> m_FemaleClothesSpriteNames = new List<string>();
        [SerializeField] private List<string> m_MaleGlassesSpriteNames = new List<string>();
        [SerializeField] private List<string> m_FemaleGlassesSpriteNames = new List<string>();

        //Точка входа в систему подбора спрайтов
        public Sprite GetSpriteFromSpriteCollection(SpriteAtlasType atlasType, string spriteName)
        {
            return GetSpriteAtlasByType(atlasType).GetSprite(spriteName);
        }

        public string GetSexDependentSprite(bool isMale, SpriteAtlasType atlasType)
        {
            switch (atlasType)
            {
                case SpriteAtlasType.Face:
                    return isMale ? m_FaceSpriteNames[0] : m_FaceSpriteNames[1];
                case SpriteAtlasType.Body:
                    return isMale ? m_BodySpriteNames[0] : m_BodySpriteNames[1];

                default:
                    throw new ArgumentOutOfRangeException(nameof(atlasType), atlasType, null);
            }

        }

        public string GetPossibleSpriteNames(SpriteAtlasType atlasType)
        {
            var possibleSprites= atlasType switch
            {
                SpriteAtlasType.Face => m_FaceSpriteNames,
                SpriteAtlasType.Body => m_BodySpriteNames,
                SpriteAtlasType.Eyes => m_EyesSpriteNames,
                SpriteAtlasType.MaleEyebrows => m_MaleEyebrowsSpriteNames,
                SpriteAtlasType.FemaleEyebrows => m_FemaleEyebrowsSpriteNames,
                SpriteAtlasType.MaleLips => m_MaleLipsSpriteNames,
                SpriteAtlasType.FemaleLips => m_FemaleLipsSpriteNames,
                SpriteAtlasType.MaleNose => m_MaleNoseSpriteNames,
                SpriteAtlasType.FemaleNose => m_FemaleNoseSpriteNames,
                SpriteAtlasType.MaleHaircut => m_MaleHaircutSpriteNames,
                SpriteAtlasType.FemaleHaircut => m_FemaleHaircutSpriteNames,
                SpriteAtlasType.MaleBeard => m_MaleBeardSpriteNames,
                SpriteAtlasType.FemaleHeaddress => m_FemaleHeaddressSpriteNames,
                SpriteAtlasType.MaleClothes => m_MaleClothesSpriteNames,
                SpriteAtlasType.FemaleClothes => m_FemaleClothesSpriteNames,
                SpriteAtlasType.MaleGlasses => m_MaleGlassesSpriteNames,
                SpriteAtlasType.FemaleGlasses => m_FemaleGlassesSpriteNames,
                _ => throw new ArgumentOutOfRangeException(nameof(atlasType), atlasType, null)
            };

            int index = UnityEngine.Random.Range(0, possibleSprites.Count);
            return possibleSprites[index];
        }

        private void GetAllSpriteNames(SpriteAtlasType atlasType)
        {
            Sprite[] sprites = new Sprite[GetSpriteAtlasByType(atlasType).spriteCount];
            GetSpriteAtlasByType(atlasType).GetSprites(sprites);

            switch (atlasType)
            {
                case SpriteAtlasType.Face:
                    FillSpriteNamesList(sprites, m_FaceSpriteNames);
                    break;
                case SpriteAtlasType.Body:
                    FillSpriteNamesList(sprites, m_BodySpriteNames);
                    break;
                case SpriteAtlasType.Eyes:
                    FillSpriteNamesList(sprites, m_EyesSpriteNames);
                    break;
                case SpriteAtlasType.MaleEyebrows:
                    FillSpriteNamesList(sprites, m_MaleEyebrowsSpriteNames);
                    break;
                case SpriteAtlasType.FemaleEyebrows:
                    FillSpriteNamesList(sprites, m_FemaleEyebrowsSpriteNames);
                    break;
                case SpriteAtlasType.MaleLips:
                    FillSpriteNamesList(sprites, m_MaleLipsSpriteNames);
                    break;
                case SpriteAtlasType.FemaleLips:
                    FillSpriteNamesList(sprites, m_FemaleLipsSpriteNames);
                    break;
                case SpriteAtlasType.MaleNose:
                    FillSpriteNamesList(sprites, m_MaleNoseSpriteNames);
                    break;
                case SpriteAtlasType.FemaleNose:
                    FillSpriteNamesList(sprites, m_FemaleNoseSpriteNames);
                    break;
                case SpriteAtlasType.MaleHaircut:
                    FillSpriteNamesList(sprites, m_MaleHaircutSpriteNames);
                    break;
                case SpriteAtlasType.FemaleHaircut:
                    FillSpriteNamesList(sprites,m_FemaleHaircutSpriteNames);
                    break;
                case SpriteAtlasType.MaleBeard:
                    FillSpriteNamesList(sprites, m_MaleBeardSpriteNames);
                    break;
                case SpriteAtlasType.FemaleHeaddress:
                    FillSpriteNamesList(sprites, m_FemaleHeaddressSpriteNames);
                    break;
                case SpriteAtlasType.MaleClothes:
                    FillSpriteNamesList(sprites, m_MaleClothesSpriteNames);
                    break;
                case SpriteAtlasType.FemaleClothes:
                    FillSpriteNamesList(sprites, m_FemaleClothesSpriteNames);
                    break;
                case SpriteAtlasType.MaleGlasses:
                    FillSpriteNamesList(sprites, m_MaleGlassesSpriteNames);
                    break;
                case SpriteAtlasType.FemaleGlasses:
                    FillSpriteNamesList(sprites, m_FemaleGlassesSpriteNames);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(atlasType), atlasType, null);
            }
        }

        private void FillSpriteNamesList(Sprite[] sprites, List<string> spriteNames)
        {
            spriteNames.Clear();
            foreach (Sprite sprite in sprites)
            {
                var name = sprite.name.Substring(0, sprite.name.Length - 7);
                spriteNames.Add(name);
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