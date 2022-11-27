using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Rendering
{
    //https://github.com/itsPeetah/unity-simple-URP-pixelation/blob/main/Scripts/PixelizeFeature.cs
    public class PixelizeFeature : ScriptableRendererFeature
    {
        [System.Serializable]
        public class CustomPassSettings
        {
            public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
            public int screenHeight = 144;
        }

        [SerializeField] private CustomPassSettings settings;
        private PixelizePass _customPass;

        public override void Create()
        {
            _customPass = new PixelizePass(settings);
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
#if UNITY_EDITOR
            if (renderingData.cameraData.isSceneViewCamera) return;
#endif
            renderer.EnqueuePass(_customPass);
        }
    }
}