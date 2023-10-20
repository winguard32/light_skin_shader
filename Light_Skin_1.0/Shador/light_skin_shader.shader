//Reference the function of the unity chan toon shader.
//For information on existing shaders, please use the related link.
//https://unity-chan.com/

Shader "Light_Skin/light_skin"
{
    Properties
    {
        //----------------------------------------------------------------------------------------------------------------------
        // Main
        [HideInInspector] _simpleUI("SimpleUI", Int) = 0


        [NoScaleOffset]                     _Main_Tex("Texture", 2D) = "white" {}
        [HDR]                               _Main_Color("Main_Color", Color) = (0,0,0,1)
        [NoScaleOffset]                     _Emissive_Tex("Texture", 2D) = "white" {}
        [HDR]                               _Emissive_Color("Main_Color", Color) = (0,0,0,1)
                                            _Scroll_Scale("Scroll_Scale", Range(0, 1)) = 0.1
                                            _Rotation("Rotation", Range(0, 1)) = 0
                                            _Offset("Offset", Vector) = (0, 0, 0, 0)

        //----------------------------------------------------------------------------------------------------------------------
        // EMISSIVE
        [KeywordEnum(SIMPLE,ANIMATION)]     _EMISSIVE("EMISSIVE MODE", Float) = 0

                                            _Base_Speed("Base_Speed", Float) = 0

                                            _Scroll_EmissiveU("Scroll_EmissiveU", Range(-1, 1)) = 0
                                            _Scroll_EmissiveV("Scroll_EmissiveV", Range(-1, 1)) = 0
                                            _Rotate_EmissiveUV("Rotate_EmissiveUV", Float) = 0

        [Toggle(_)]                         _Is_PingPong_Base("Is_PingPong_Base", Float) = 0

        [NoScaleOffset]                     _Bloom_Tex("Texture", 2D) = "white" {}

        [Toggle(_)]                         _Is_BloomShift("Activate BloomShift", Float) = 0
        [HDR]                               _BloomShift("BloomSift", Color) = (0,0,0,1)
                                            _BloomShift_Speed("BloomShift_Speed", Float) = 0
                                            _BloomShift_Ratio("BloomShift_Ratio", Range(0, 1)) = 0

        [Toggle(_)]                         _Is_ColorShift("Activate ColorShift", Float) = 0
        [HDR]                               _ColorShift("ColorSift", Color) = (0,0,0,1)
                                            _ColorShift_Speed("ColorShift_Speed", Float) = 0

        [Toggle(_)]                         _Is_ViewShift("Activate ViewShift", Float) = 0
        [HDR]                               _ViewShift("ViewSift", Color) = (0,0,0,1)

        [Toggle(_)]                         _Is_ViewCoord_Scroll("Is_ViewCoord_Scroll", Float) = 0

    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            
            //v.1.0.0
            #pragma multi_compile _EMISSIVE_SIMPLE _EMISSIVE_ANIMATION
            #include "Light_Skin.cginc"
            ENDCG
        }
    }
    CustomEditor "Light_Skin.LightSkin"
}