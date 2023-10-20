//Reference the function of the unity chan toon shader.
//For information on existing shaders, please use the related link.
//https://unity-chan.com/

using UnityEngine;
using UnityEditor;

namespace Light_Skin_2_0
{
    public class LightSkin_2_0 : ShaderGUI
    {
        public enum _MainMode
        {
            Main
        }

        public enum _EmissiveMode
        {
            SimpleEmissive, EmissiveAnimation
        }

        public _EmissiveMode emissiveMode;
        public _MainMode MainMode;

        public GUILayoutOption[] shortButtonStyle = new GUILayoutOption[] { GUILayout.Width(130) };
        public GUILayoutOption[] middleButtonStyle = new GUILayoutOption[] { GUILayout.Width(130) };

        static bool _SimpleUI = false;

        static bool _Main_Foldout = true;
        static bool _Emissive_Foldout = true;

        //MaterialProperty Main_Tex = null;
        //MaterialProperty Main_Color = null;
        MaterialProperty Emissive_Tex = null;
        MaterialProperty Emissive_Color = null;
        MaterialProperty Scroll_Scale = null;
        MaterialProperty Rotation = null;
        MaterialProperty Offset = null;

        MaterialProperty base_Speed = null;
        MaterialProperty scroll_EmissiveU = null;
        MaterialProperty scroll_EmissiveV = null;
        MaterialProperty rotate_EmissiveUV = null;

        MaterialProperty Bloom_Tex = null;        
        MaterialProperty BloomShift = null;
        MaterialProperty BloomShift_Speed = null;
        MaterialProperty BloomShift_Ratio = null;

        //MaterialProperty ScaleShift = null;
        //MaterialProperty ScaleShift_Speed = null;

        //poi
        MaterialProperty m_emission_Scrolling_Strength = null;

        MaterialProperty m_emissiveBlinkMin = null;
        MaterialProperty m_emissiveBlinkMax = null;
        MaterialProperty m_emissiveBlinkVelocity = null;

        MaterialProperty m_emissiveScrollDirection = null;
        MaterialProperty m_emissiveScrollWidth = null;
        MaterialProperty m_emissiveScrollVelocity = null;
        MaterialProperty m_emissiveScrollInterval = null;
        //

        MaterialProperty colorShift = null;
        MaterialProperty colorShift_Speed = null;
        MaterialProperty viewShift = null;

        MaterialEditor m_MaterialEditor;

        public void FindProperties(MaterialProperty[] props)
        {
            //Main_Tex = FindProperty("_Main_Tex", props);
            //Main_Color = FindProperty("_Main_Color", props);
            Emissive_Tex = FindProperty("_Emissive_Tex", props);
            Emissive_Color = FindProperty("_Emissive_Color", props);

            Scroll_Scale = FindProperty("_Scroll_Scale", props);
            Rotation = FindProperty("_Rotation", props);
            Offset = FindProperty("_Offset", props);

            base_Speed = FindProperty("_Base_Speed", props);

            scroll_EmissiveU = FindProperty("_Scroll_EmissiveU", props);
            scroll_EmissiveV = FindProperty("_Scroll_EmissiveV", props);
            rotate_EmissiveUV = FindProperty("_Rotate_EmissiveUV", props);

            Bloom_Tex = FindProperty("_Bloom_Tex", props);
            BloomShift = FindProperty("_BloomShift", props);
            BloomShift_Speed = FindProperty("_BloomShift_Speed", props);
            BloomShift_Ratio = FindProperty("_BloomShift_Ratio", props);

            //ScaleShift = FindProperty("_ScaleShift", props);
            //ScaleShift_Speed = FindProperty("_ScaleShift_Speed", props);

            //poi
            m_emission_Scrolling_Strength = FindProperty("_Emission_Scrolling_Strength", props);

            m_emissiveBlinkMin = FindProperty("_EmissiveBlink_Min", props);
            m_emissiveBlinkMax = FindProperty("_EmissiveBlink_Max", props);
            m_emissiveBlinkVelocity = FindProperty("_EmissiveBlink_Velocity", props);

            m_emissiveScrollDirection = FindProperty("_EmissiveScroll_Direction", props);
            m_emissiveScrollWidth = FindProperty("_EmissiveScroll_Width", props);
            m_emissiveScrollVelocity = FindProperty("_EmissiveScroll_Velocity", props);
            m_emissiveScrollInterval = FindProperty("_EmissiveScroll_Interval", props);
            //

            colorShift = FindProperty("_ColorShift", props);
            colorShift_Speed = FindProperty("_ColorShift_Speed", props);

            viewShift = FindProperty("_ViewShift", props);
        }


        // --------------------------------
        static void Line()
        {
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        }

        static bool Foldout(bool display, string title)
        {
            var style = new GUIStyle("ShurikenModuleTitle");
            style.font = new GUIStyle(EditorStyles.boldLabel).font;
            style.border = new RectOffset(15, 7, 4, 4);
            style.fixedHeight = 22;
            style.contentOffset = new Vector2(20f, -2f);

            var rect = GUILayoutUtility.GetRect(16f, 22f, style);
            GUI.Box(rect, title, style);

            var e = Event.current;

            var toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
            if (e.type == EventType.Repaint)
            {
                EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
            }

            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
            {
                display = !display;
                e.Use();
            }

            return display;
        }

        static bool FoldoutSubMenu(bool display, string title)
        {
            var style = new GUIStyle("ShurikenModuleTitle");
            style.font = new GUIStyle(EditorStyles.boldLabel).font;
            style.border = new RectOffset(15, 7, 4, 4);
            style.padding = new RectOffset(5, 7, 4, 4);
            style.fixedHeight = 22;
            style.contentOffset = new Vector2(32f, -2f);

            var rect = GUILayoutUtility.GetRect(16f, 22f, style);
            GUI.Box(rect, title, style);

            var e = Event.current;

            var toggleRect = new Rect(rect.x + 16f, rect.y + 2f, 13f, 13f);
            if (e.type == EventType.Repaint)
            {
                EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
            }

            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
            {
                display = !display;
                e.Use();
            }

            return display;
        }


        private static class Styles
        {
            //public static GUIContent MainTexText = new GUIContent("MainTexture", "MainTexture : Texture(sRGB)× MainMask(alpha) × Color(HDR) Default:Black");
            public static GUIContent emissiveTexText = new GUIContent("Texture", "Emissive : Texture(sRGB)× EmissiveMask(alpha) × Color(HDR) Default:Black");
            //public static GUIContent emissiveTexText = new GUIContent("Texture", "Emissive : Texture(sRGB)× EmissiveMask(alpha) × Color(HDR) Default:Black");
            public static GUIContent BloomTexText = new GUIContent("Bloom", "Bloom : Texture(sRGB)× BloomMask(alpha) × Color(HDR) Default:Black");

            //poi
            public static GUIContent Emission_Scrolling_Color = new GUIContent("Color", "Color used for emission");
            public static GUIContent EmissionMap = new GUIContent("Map", "Texture used for emission");
            public static GUIContent Emission_Scrolling_Strength = new GUIContent("Strength", "Strength multiplier for emission");
            // emissive blink
            public static GUIContent EmissiveBlinkMin = new GUIContent("Min", "Minimum value used for emissive blink");
            public static GUIContent EmissiveBlinkMax = new GUIContent("Max", "Maximum value used for emissive blink");
            public static GUIContent EmissiveBlinkVelocity = new GUIContent("Velocity", "Blinking speed");
            // emissive scroll
            public static GUIContent EmissiveScrollDirection = new GUIContent("Direction", "Emissive scrolling direction");
            public static GUIContent EmissiveScrollWidth = new GUIContent("Width", "Emissive scrolling width");
            public static GUIContent EmissiveScrollVelocity = new GUIContent("Velocity", "Emissive scrolling speed");
            public static GUIContent EmissiveScrollInterval = new GUIContent("Interval", "Delay between emissive scrolls");
            //
        }
        // --------------------------------


        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
        {
            EditorGUIUtility.fieldWidth = 0;
            FindProperties(props);
            m_MaterialEditor = materialEditor;
            Material material = materialEditor.target as Material;

            _Main_Foldout = Foldout(_Main_Foldout, "【Main: transport】");
            if (_Main_Foldout)
            {
                EditorGUI.indentLevel++;
                //EditorGUILayout.Space();
                GUI_Main(material);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space();

            _Emissive_Foldout = Foldout(_Emissive_Foldout, "【Emissive : Self-luminescence Settings】");
            if (_Emissive_Foldout)
            {
                EditorGUI.indentLevel++;
                //EditorGUILayout.Space();
                GUI_Emissive(material);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space();


        }// End of OnGUI()


        void RemoveShaderKeywords(Material material)
        {
            string shaderKeywords = "";

            if (material.HasProperty("_EMISSIVE"))
            {
                float outlineMode = material.GetFloat("_EMISSIVE");
                if (outlineMode == 0)
                {
                    shaderKeywords = shaderKeywords + "_EMISSIVE_SIMPLE";
                }
                else
                {
                    shaderKeywords = shaderKeywords + "_EMISSIVE_ANIMATION";
                }
            }
            if (material.HasProperty("_OUTLINE"))
            {
                float outlineMode = material.GetFloat("_OUTLINE");
                if (outlineMode == 0)
                {
                    shaderKeywords = shaderKeywords + " _OUTLINE_NML";
                }
                else
                {
                    shaderKeywords = shaderKeywords + " _OUTLINE_POS";
                }
            }

            var so = new SerializedObject(material);
            so.Update();
            so.FindProperty("m_ShaderKeywords").stringValue = shaderKeywords;
            so.ApplyModifiedProperties();
        }
        void GUI_Main(Material material)
        {
            GUILayout.Label("Main_texture", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            //m_MaterialEditor.TexturePropertySingleLine(Styles.MainTexText, Main_Tex, Main_Color);
            m_MaterialEditor.TexturePropertySingleLine(Styles.emissiveTexText, Emissive_Tex, Emissive_Color);
            //m_MaterialEditor.ShaderProperty(Emissive_Tex, Styles.emissiveTexText);

            EditorGUI.indentLevel++;
            m_MaterialEditor.RangeProperty(Scroll_Scale, "Scroll_Scale");
            m_MaterialEditor.RangeProperty(Rotation, "Rotation");
            m_MaterialEditor.VectorProperty(Offset, "Offset");
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
        }
        
        void GUI_Emissive(Material material)
        {
            GUILayout.Label("Emissive Tex × HDR Color", EditorStyles.boldLabel);
            GUILayout.Label("(Bloom Post-Processing Effect necessary)");
            EditorGUILayout.Space();

            //m_MaterialEditor.TexturePropertySingleLine(Styles.emissiveTexText, Emissive_Tex, Emissive_Color);

            int _EmissiveMode_Setting = material.GetInt("_EMISSIVE");
            if ((int)_EmissiveMode.SimpleEmissive == _EmissiveMode_Setting)
            {
                emissiveMode = _EmissiveMode.SimpleEmissive;
            }
            else if ((int)_EmissiveMode.EmissiveAnimation == _EmissiveMode_Setting)
            {
                emissiveMode = _EmissiveMode.EmissiveAnimation;
            }
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Emissive Animation");
            //GUILayout.Space(60);
            if (emissiveMode == _EmissiveMode.SimpleEmissive)
            {
                if (GUILayout.Button("Off", shortButtonStyle))
                {
                    material.SetFloat("_EMISSIVE", 1);
                    material.EnableKeyword("_EMISSIVE_ANIMATION");
                    material.DisableKeyword("_EMISSIVE_SIMPLE");
                }
            }
            else
            {
                if (GUILayout.Button("Active", shortButtonStyle))
                {
                    material.SetFloat("_EMISSIVE", 0);
                    material.EnableKeyword("_EMISSIVE_SIMPLE");
                    material.DisableKeyword("_EMISSIVE_ANIMATION");
                }
            }
            EditorGUILayout.EndHorizontal();

            if (emissiveMode == _EmissiveMode.EmissiveAnimation)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.BeginHorizontal();
                m_MaterialEditor.FloatProperty(base_Speed, "Base Speed (Time)");
                //EditorGUILayout.PrefixLabel("Select Scroll Coord");
                //GUILayout.Space(60);
                if (!_SimpleUI)
                {
                    if (material.GetFloat("_Is_ViewCoord_Scroll") == 0)
                    {
                        if (GUILayout.Button("UV Coord Scroll", shortButtonStyle))
                        {
                            material.SetFloat("_Is_ViewCoord_Scroll", 1);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("View Coord Scroll", shortButtonStyle))
                        {
                            material.SetFloat("_Is_ViewCoord_Scroll", 0);
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();

                m_MaterialEditor.RangeProperty(scroll_EmissiveU, "Scroll U/X direction");
                m_MaterialEditor.RangeProperty(scroll_EmissiveV, "Scroll V/Y direction");
                m_MaterialEditor.FloatProperty(rotate_EmissiveUV, "Rotate around UV center");

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("PingPong Move for Base");
                //GUILayout.Space(60);
                if (material.GetFloat("_Is_PingPong_Base") == 0)
                {
                    if (GUILayout.Button("Off", shortButtonStyle))
                    {
                        material.SetFloat("_Is_PingPong_Base", 1);
                    }
                }
                else
                {
                    if (GUILayout.Button("Active", shortButtonStyle))
                    {
                        material.SetFloat("_Is_PingPong_Base", 0);
                    }
                }
                EditorGUILayout.EndHorizontal();

                EditorGUI.indentLevel--;



                if (!_SimpleUI)
                {

//-----------------------------------------------------------------

                    EditorGUILayout.Space();
                    m_MaterialEditor.TexturePropertySingleLine(Styles.BloomTexText, Bloom_Tex, BloomShift_Ratio);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("BloomShift with Time");
                    //GUILayout.Space(60);
                    if (material.GetFloat("_Is_BloomShift") == 0)
                    {
                        if (GUILayout.Button("Off", shortButtonStyle))
                        {
                            material.SetFloat("_Is_BloomShift", 1);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Active", shortButtonStyle))
                        {
                            material.SetFloat("_Is_BloomShift", 0);
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUI.indentLevel++;

                    if (material.GetFloat("_Is_BloomShift") == 1)
                    {
                        m_MaterialEditor.ColorProperty(BloomShift, "Destination Color");
                        m_MaterialEditor.FloatProperty(BloomShift_Speed, "BloomShift Speed (Time)");
                    }
                    EditorGUI.indentLevel--;

//-----------------------------------------------------------------
/*
                    EditorGUILayout.Space();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("ScaleShift with Time");
                    //GUILayout.Space(60);
                    if (material.GetFloat("_Is_ScaleShift") == 0)
                    {
                        if (GUILayout.Button("Off", shortButtonStyle))
                        {
                            material.SetFloat("_Is_ScaleShift", 1);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Active", shortButtonStyle))
                        {
                            material.SetFloat("_Is_ScaleShift", 0);
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUI.indentLevel++;

                    if (material.GetFloat("_Is_ScaleShift") == 1)
                    {
                        m_MaterialEditor.RangeProperty(ScaleShift, "Destination Scale");
                        m_MaterialEditor.FloatProperty(ScaleShift_Speed, "ScaleShift Speed (Time)");
                    }
                    EditorGUI.indentLevel--;
*/
//-----------------------------------------------------------------
//-----------------------------------------------------------------

                    EditorGUILayout.Space();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("Scrolling with Time");
                    //GUILayout.Space(60);
                    if (material.GetFloat("_Is_Scrolling") == 0)
                    {
                        if (GUILayout.Button("Off", shortButtonStyle))
                        {
                            material.SetFloat("_Is_Scrolling", 1);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Active", shortButtonStyle))
                        {
                            material.SetFloat("_Is_Scrolling", 0);
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUI.indentLevel++;

                    if (material.GetFloat("_Is_Scrolling") == 1)
                    {
                        // emissive section
                            EditorGUILayout.Space();
                            m_MaterialEditor.ShaderProperty(m_emission_Scrolling_Strength, Styles.Emission_Scrolling_Strength);
                            m_MaterialEditor.ShaderProperty(m_emissiveBlinkMin, Styles.EmissiveBlinkMin);
                            m_MaterialEditor.ShaderProperty(m_emissiveBlinkMax, Styles.EmissiveBlinkMax);
                            m_MaterialEditor.ShaderProperty(m_emissiveBlinkVelocity, Styles.EmissiveBlinkVelocity);
                            EditorGUILayout.Space();
                            m_MaterialEditor.ShaderProperty(m_emissiveScrollDirection, Styles.EmissiveScrollDirection);
                            m_MaterialEditor.ShaderProperty(m_emissiveScrollWidth, Styles.EmissiveScrollWidth);
                            m_MaterialEditor.ShaderProperty(m_emissiveScrollVelocity, Styles.EmissiveScrollVelocity);
                            m_MaterialEditor.ShaderProperty(m_emissiveScrollInterval, Styles.EmissiveScrollInterval);
                            EditorGUILayout.Space();
                    }
                    EditorGUI.indentLevel--;

//-----------------------------------------------------------------

                    EditorGUILayout.Space();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("ColorShift with Time");
                    //GUILayout.Space(60);
                    if (material.GetFloat("_Is_ColorShift") == 0)
                    {
                        if (GUILayout.Button("Off", shortButtonStyle))
                        {
                            material.SetFloat("_Is_ColorShift", 1);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Active", shortButtonStyle))
                        {
                            material.SetFloat("_Is_ColorShift", 0);
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUI.indentLevel++;

                    if (material.GetFloat("_Is_ColorShift") == 1)
                    {
                        m_MaterialEditor.ColorProperty(colorShift, "Destination Color");
                        m_MaterialEditor.FloatProperty(colorShift_Speed, "ColorShift Speed (Time)");
                    }
                    EditorGUI.indentLevel--;

//-----------------------------------------------------------------

                    EditorGUILayout.Space();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("ViewShift of Color");
                    //GUILayout.Space(60);
                    if (material.GetFloat("_Is_ViewShift") == 0)
                    {
                        if (GUILayout.Button("Off", shortButtonStyle))
                        {
                            material.SetFloat("_Is_ViewShift", 1);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Active", shortButtonStyle))
                        {
                            material.SetFloat("_Is_ViewShift", 0);
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUI.indentLevel++;
                    if (material.GetFloat("_Is_ViewShift") == 1)
                    {
                        m_MaterialEditor.ColorProperty(viewShift, "ViewShift Color");
                    }
                    EditorGUI.indentLevel--;
                }//!_SimpleUI
            }
            EditorGUILayout.Space();
        }

    }
}
