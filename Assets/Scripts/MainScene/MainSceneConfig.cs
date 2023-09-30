using MainView;
using UnityEngine;

namespace MainScene
{
    [CreateAssetMenu(fileName = "mainSceneConfig", menuName = "mainSceneConfig")]
    public class MainSceneConfig : ScriptableObject
    {
        [SerializeField] private HumanSpriteCollection m_humanSpriteCollection;

        public HumanSpriteCollection HumanSpriteCollection => m_humanSpriteCollection;

    }
}