using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using SpriteCollections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace MainView
{
    public class HumanView : MonoBehaviour
    {
        [SerializeField] private RectTransform m_root;
        [SerializeField] private CanvasGroup m_canvasGroup;
        [SerializeField] private Image m_humanFaceImage;
        [SerializeField] private Image m_humanBodyImage;
        [SerializeField] private Image m_humanEyesSpriteImage;
        [SerializeField] private Image m_humanNoseSpriteImage;
        [SerializeField] private Image m_humanWyebrowsImage;
        [SerializeField] private Image m_humanMouthImage;
        [SerializeField] private Image m_humanHaircutImage;
        [SerializeField] private Image m_maleBeardImage;
        [SerializeField] private Image m_humanHeaddressImage;
        [SerializeField] private Image m_humanClothesImage;
        [SerializeField] private Image m_humanGlassesImage;

        [SerializeField] private bool m_isLeft;
        [SerializeField] private bool m_isCanMove;
        [SerializeField] private bool m_isMale;

        [SerializeField] private Vector2 m_leftRestorePosition;

        [FormerlySerializedAs("m_leftEndPosition")] [SerializeField]
        private Vector2 m_leftAppendPosition;

        [FormerlySerializedAs("m_leftStartPosition")] [SerializeField]
        private Vector2 m_leftDissapearPosition;

        [SerializeField] private Vector2 m_rightRestorePosition;

        [FormerlySerializedAs("m_rightEndPosition")] [SerializeField]
        private Vector2 m_rightAppendPosition;

        [FormerlySerializedAs("m_rightStartPosition")] [SerializeField]
        private Vector2 m_rightDissapearPosition;


        [SerializeField] private bool m_WithBeard;
        [SerializeField] private bool m_WithHeaddress;
        [SerializeField] private bool m_WithGlasses;

        [SerializeField] private List<Color> m_availableColors;

        [SerializeField] private List<Color> m_availableClothColors;


        [Inject] private HumanSpriteCollection m_humanSpriteCollection;

        public HumanView(Image mHumanFaceImage, Image mHumanEyesSpriteImage, Image mHumanEyebrowsImage,
            Image mHumanMouthImage, Image mHumanHaircutImage, [CanBeNull] Image mMaleBeardImage,
            [CanBeNull] Image mHumanHeaddressImage, bool mIsMale, HumanSpriteCollection humanSpriteCollection)
        {
            m_humanFaceImage = mHumanFaceImage;
            m_humanEyesSpriteImage = mHumanEyesSpriteImage;
            m_humanWyebrowsImage = mHumanEyebrowsImage;
            m_humanMouthImage = mHumanMouthImage;
            m_humanHaircutImage = mHumanHaircutImage;
            m_maleBeardImage = mMaleBeardImage;
            m_humanHeaddressImage = mHumanHeaddressImage;
            m_isMale = mIsMale;
            m_humanSpriteCollection = humanSpriteCollection;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) HumanAppend();
            if (Input.GetKeyDown(KeyCode.E)) HumanDisappear();

            if (Input.GetKeyDown(KeyCode.R)) GenerateHumanViewFinal(m_WithBeard, m_WithHeaddress, m_WithGlasses);
        }

        public void GenerateHumanViewFinal(bool needBeard, bool needHeaddress, bool needGlasses)
        {
            m_maleBeardImage.enabled = needBeard;
            m_humanHeaddressImage.enabled = needHeaddress;
            m_humanGlassesImage.enabled = needGlasses;

            GenerateHumanViewInternal(m_isMale,
                m_humanSpriteCollection.GetSexDependentSprite(m_isMale, SpriteAtlasType.Face),
                m_humanSpriteCollection.GetSexDependentSprite(m_isMale, SpriteAtlasType.Body),
                m_humanSpriteCollection.GetPossibleSpriteNames(SpriteAtlasType.Eyes),
                m_humanSpriteCollection.GetPossibleSpriteNames(m_isMale
                    ? SpriteAtlasType.MaleNose
                    : SpriteAtlasType.FemaleNose),
                m_humanSpriteCollection.GetPossibleSpriteNames(m_isMale
                    ? SpriteAtlasType.MaleEyebrows
                    : SpriteAtlasType.FemaleEyebrows),
                m_humanSpriteCollection.GetPossibleSpriteNames(m_isMale
                    ? SpriteAtlasType.MaleLips
                    : SpriteAtlasType.FemaleLips),
                m_humanSpriteCollection.GetPossibleSpriteNames(m_isMale
                    ? SpriteAtlasType.MaleHaircut
                    : SpriteAtlasType.FemaleHaircut),
                m_humanSpriteCollection.GetPossibleSpriteNames(m_isMale
                    ? SpriteAtlasType.MaleClothes
                    : SpriteAtlasType.FemaleClothes),
                needBeard ? m_humanSpriteCollection.GetPossibleSpriteNames(SpriteAtlasType.MaleBeard) : null,
                needHeaddress ? m_humanSpriteCollection.GetPossibleSpriteNames(SpriteAtlasType.FemaleHeaddress) : null,
                needGlasses
                    ? m_humanSpriteCollection.GetPossibleSpriteNames(m_isMale
                        ? SpriteAtlasType.MaleGlasses
                        : SpriteAtlasType.FemaleGlasses)
                    : null
            );

            ApplyColor();
        }

        private void ApplyColor()
        {
            Color color = m_availableColors[Random.Range(0, m_availableColors.Count)];
            m_humanFaceImage.color = color;
            m_humanBodyImage.color = color;
            m_humanClothesImage.color = m_availableClothColors[Random.Range(0, m_availableClothColors.Count)];
            m_humanHeaddressImage.color = m_availableClothColors[Random.Range(0, m_availableClothColors.Count)];
        }


        private void GenerateHumanViewInternal(bool isMan, string face, string body, string eyes, string nose,
            string eyebrows, string mouth, string haircut, string clothes, [CanBeNull] string beard,
            [CanBeNull] string headdress, [CanBeNull] string glasses)
        {
            var faceSprite = m_humanSpriteCollection.GetSpriteFromSpriteCollection(SpriteAtlasType.Face, face);
            var bodySprite = m_humanSpriteCollection.GetSpriteFromSpriteCollection(SpriteAtlasType.Body, body);
            var noseSprite =
                m_humanSpriteCollection.GetSpriteFromSpriteCollection(
                    isMan ? SpriteAtlasType.MaleNose : SpriteAtlasType.FemaleNose, nose);
            var eyesSprite = m_humanSpriteCollection.GetSpriteFromSpriteCollection(SpriteAtlasType.Eyes, eyes);
            var eyebrowsSprite =
                m_humanSpriteCollection.GetSpriteFromSpriteCollection(
                    isMan ? SpriteAtlasType.MaleEyebrows : SpriteAtlasType.FemaleEyebrows, eyebrows);
            var mouthSprite =
                m_humanSpriteCollection.GetSpriteFromSpriteCollection(
                    isMan ? SpriteAtlasType.MaleLips : SpriteAtlasType.FemaleLips, mouth);
            var haircutSprite =
                m_humanSpriteCollection.GetSpriteFromSpriteCollection(
                    isMan ? SpriteAtlasType.MaleHaircut : SpriteAtlasType.FemaleHaircut, haircut);
            var clothesSprite =
                m_humanSpriteCollection.GetSpriteFromSpriteCollection(
                    isMan ? SpriteAtlasType.MaleClothes : SpriteAtlasType.FemaleClothes, clothes);
            Sprite beardSprite = null;
            Sprite headdressSprite = null;
            Sprite glassesSprite = null;

            if (glasses != null)
                glassesSprite =
                    m_humanSpriteCollection.GetSpriteFromSpriteCollection(
                        isMan ? SpriteAtlasType.MaleGlasses : SpriteAtlasType.FemaleGlasses, glasses);

            if (beard != null)
                beardSprite = m_humanSpriteCollection.GetSpriteFromSpriteCollection(SpriteAtlasType.MaleBeard, beard);

            if (headdress != null)
                headdressSprite =
                    m_humanSpriteCollection.GetSpriteFromSpriteCollection(SpriteAtlasType.FemaleHeaddress, headdress);

            GenerateHumanView(faceSprite, bodySprite, eyesSprite, noseSprite, eyebrowsSprite, mouthSprite,
                haircutSprite,clothesSprite, beardSprite, headdressSprite, glassesSprite);
        }

        private void GenerateHumanView(Sprite face, Sprite body, Sprite eyes, Sprite nose, Sprite eyebrows,
            Sprite mouth, Sprite haircut, Sprite clothesSprite, [CanBeNull] Sprite beard, [CanBeNull] Sprite headdress,
            [CanBeNull] Sprite glasses)
        {
            m_humanFaceImage.sprite = face;
            m_humanBodyImage.sprite = body;
            m_humanEyesSpriteImage.sprite = eyes;
            m_humanNoseSpriteImage.sprite = nose;
            m_humanWyebrowsImage.sprite = eyebrows;
            m_humanMouthImage.sprite = mouth;
            m_humanHaircutImage.sprite = haircut;
            Debug.Log(eyes.name);
            m_humanClothesImage.sprite = clothesSprite;
            if (beard != null) m_maleBeardImage.sprite = beard;
            if (headdress != null) m_humanHeaddressImage.sprite = headdress;
            if (glasses != null) m_humanGlassesImage.sprite = glasses;
        }

        //появления
        public void HumanAppend()
        {
            if (m_isCanMove)
            {
                var sequence = DOTween.Sequence();
                var restoreStartPos = m_root
                    .DOAnchorPos(m_isLeft ? m_leftRestorePosition : m_rightRestorePosition, 0.1f)
                    .OnStart(() => AlphaCallback(1));
                var pos = m_root.DOAnchorPos(m_isLeft ? m_leftAppendPosition : m_rightAppendPosition, 0.6f);
                sequence.Append(restoreStartPos).AppendInterval(0.2f).Append(pos);
            }
        }

        //пропуск успешен
        public void HumanDisappear()
        {
            if (m_isCanMove)
            {
                var sequence = DOTween.Sequence();
                var restoreStartPos =
                    m_root.DOAnchorPos(m_isLeft ? m_leftRestorePosition : m_rightRestorePosition, 0.1f);
                var pos = m_root.DOAnchorPos(m_isLeft ? m_leftDissapearPosition : m_rightDissapearPosition, 0.6f)
                    .OnComplete(() => AlphaCallback(0));
                sequence.Append(pos).AppendInterval(0.2f).Append(restoreStartPos);
            }
        }
        //человек ушел так как не пропустили
        public void HumanLeave()
        {
            if (m_isCanMove)
            {
                var sequence = DOTween.Sequence();
                var restoreStartPos =
                    m_root.DOAnchorPos(m_isLeft ? m_leftRestorePosition : m_rightRestorePosition, 0.1f);
                var pos = m_root.DOAnchorPos(m_isLeft ? m_leftDissapearPosition : m_rightDissapearPosition, 0.6f)
                    .OnComplete(() => AlphaCallback(0));
                sequence.Append(restoreStartPos).AppendInterval(0.2f).Append(pos);
            }
        }

        private void AlphaCallback(float alpha)
        {
            m_canvasGroup.alpha = alpha;
        }

        public void InitializeView()
        {
            CheckSex(m_isMale);
        }

        private void CheckSex(bool isMale)
        {
        }
    }
}