//Reference the function of the unity chan toon shader.
//For information on existing shaders, please use the related link.
//https://unity-chan.com/


//
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _Rotate_MatCapUV;
            uniform float _CameraRolling_Stabilizer;
            uniform fixed _BlurLevelMatcap;
            uniform fixed _Inverse_MatcapMask;
            uniform float _BumpScale;
            uniform float _BumpScaleMatcap; 
            //Emissive
            uniform sampler2D _Emissive_Tex; uniform float4 _Emissive_Tex_ST;

            //Light_Skin
            uniform float _Scroll_Scale;
            uniform float4 _Emissive_Color;
            uniform float _Rotation;
            uniform float4 _Offset;

            //uniform sampler2D _Main_Tex;
            //uniform float4 _Main_Tex_ST;
            //uniform float4 _Main_Color;
            //v.2.0.7
            uniform fixed _Is_ViewCoord_Scroll;
            uniform float _Rotate_EmissiveUV;
            uniform float _Base_Speed;
            uniform float _Scroll_EmissiveU;
            uniform float _Scroll_EmissiveV;
            uniform fixed _Is_PingPong_Base;

            uniform sampler2D _Bloom_Tex; uniform float4 _Bloom_Tex_ST;
            uniform float4 _Bloom_Color;
            uniform float4 _BloomShift;
            uniform float _BloomShift_Speed;
            uniform fixed _Is_BloomShift;
            uniform float4 BaseBloomColor;
            uniform float4 Bloom;
            uniform float _BloomShift_Ratio;

            //uniform float4 _ScaleShift;
            //uniform float _ScaleShift_Speed;
            //uniform fixed _Is_ScaleShift;

            //poi
            uniform fixed _Is_Scrolling;
            uniform float _Emission_Scrolling_Strength;

            uniform float4 _EmissiveScroll_Direction;
            uniform float4 _EmissionScrollSpeed;
            uniform float _EmissiveScroll_Width;
            uniform float _EmissiveScroll_Velocity;
            uniform float _EmissiveScroll_Interval;

            uniform float _EmissiveBlink_Min;
            uniform float _EmissiveBlink_Max;
            uniform float _EmissiveBlink_Velocity;

            uniform float4 _emission_var;
            //
            uniform float4 _ColorShift;
            uniform float4 _ViewShift;
            uniform float _ColorShift_Speed;
            uniform fixed _Is_ColorShift;
            uniform fixed _Is_ViewShift;
            uniform float3 emissive;


                    
            float2 RotateUV(float2 _uv, float _radian, float2 _piv, float _time)
            {
                float RotateUV_ang = _radian;
                float RotateUV_cos = cos(_time*RotateUV_ang);
                float RotateUV_sin = sin(_time*RotateUV_ang);
                return (mul(_uv - _piv, float2x2(RotateUV_cos, -RotateUV_sin, RotateUV_sin, RotateUV_cos)) + _piv);
            }
            
            
            struct VertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };

            struct VertexOutput
            {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;

                //v.2.0.7
                float mirrorFlag : TEXCOORD5;
                //poi
                float4 posLocal: TEXCOORD9;

                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
                //
            };
            
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.posLocal = v.vertex;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                float3 crossFwd = cross(UNITY_MATRIX_V[0], UNITY_MATRIX_V[1]);
                o.mirrorFlag = dot(crossFwd, UNITY_MATRIX_V[2]) < 0 ? 1 : -1;
                //
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            
            fixed4 frag(VertexOutput i) : SV_Target
            {
                //---------------------------------------------------------------------------------------------------------------------
                // Light_Skin

                float angle = frac(_Rotation) * 3.141592 * 2;
                float angleCos = cos(angle);
                float angleSin = sin(angle);
                float2x2 rotateMatrix = float2x2(angleCos, -angleSin, angleSin, angleCos);

                float2 MainUV = (i.uv0 - _Offset - float2(0.5, 0.5)) * (1 / _Scroll_Scale) + float2(0.5, 0.5);
                MainUV = mul(MainUV - 0.5, rotateMatrix) + 0.5;

                
                // Light_Skin Out
                //--------------------------------------------------------------------------------------------------------------------------
            
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir); 
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz); 
                float2 Set_UV0 = MainUV;
                //v.2.0.6
                
                float3 _NormalMap_var = UnpackScaleNormal(tex2D(_NormalMap,TRANSFORM_TEX(Set_UV0, _NormalMap)), _BumpScale);
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals


                
 
                fixed _sign_Mirror = i.mirrorFlag;
                //
                float3 _Camera_Right = UNITY_MATRIX_V[0].xyz;
                float3 _Camera_Front = UNITY_MATRIX_V[2].xyz;
                float3 _Up_Unit = float3(0, 1, 0);
                float3 _Right_Axis = cross(_Camera_Front, _Up_Unit);
                if(_sign_Mirror < 0){
                    _Right_Axis = -1 * _Right_Axis;
                    _Rotate_MatCapUV = -1 * _Rotate_MatCapUV;
                }else{
                    _Right_Axis = _Right_Axis;
                }
                float _Camera_Right_Magnitude = sqrt(_Camera_Right.x*_Camera_Right.x + _Camera_Right.y*_Camera_Right.y + _Camera_Right.z*_Camera_Right.z);
                float _Right_Axis_Magnitude = sqrt(_Right_Axis.x*_Right_Axis.x + _Right_Axis.y*_Right_Axis.y + _Right_Axis.z*_Right_Axis.z);
                float _Camera_Roll_Cos = dot(_Right_Axis, _Camera_Right) / (_Right_Axis_Magnitude * _Camera_Right_Magnitude);
                float _Camera_Roll = acos(clamp(_Camera_Roll_Cos, -1, 1));
                fixed _Camera_Dir = _Camera_Right.y < 0 ? -1 : 1;
                
                
                
//v.2.0.7
#ifdef _EMISSIVE_SIMPLE
                float4 _Emissive_Tex_var = tex2D(_Emissive_Tex,TRANSFORM_TEX(Set_UV0, _Emissive_Tex));
                float emissiveMask = _Emissive_Tex_var.a;
                emissive = _Emissive_Tex_var.rgb * _Emissive_Color.rgb * emissiveMask;

#elif _EMISSIVE_ANIMATION
                float3 viewNormal_Emissive = (mul(UNITY_MATRIX_V, float4(i.normalDir,0))).xyz;
                float3 NormalBlend_Emissive_Detail = viewNormal_Emissive * float3(-1,-1,1);
                float3 NormalBlend_Emissive_Base = (mul( UNITY_MATRIX_V, float4(viewDirection,0)).xyz*float3(-1,-1,1)) + float3(0,0,1);
                float3 noSknewViewNormal_Emissive = NormalBlend_Emissive_Base*dot(NormalBlend_Emissive_Base, NormalBlend_Emissive_Detail)/NormalBlend_Emissive_Base.z - NormalBlend_Emissive_Detail;
                float2 _ViewNormalAsEmissiveUV = noSknewViewNormal_Emissive.xy*0.5+0.5;
                float2 _ViewCoord_UV = RotateUV(_ViewNormalAsEmissiveUV, -(_Camera_Dir*_Camera_Roll), float2(0.5,0.5), 1.0);

                if(_sign_Mirror < 0){
                    _ViewCoord_UV.x = 1-_ViewCoord_UV.x;
                }else{
                    _ViewCoord_UV = _ViewCoord_UV;
                }

                float2 emissive_uv = lerp(Set_UV0, _ViewCoord_UV, _Is_ViewCoord_Scroll);
                //
                float4 _time_var = _Time;
                float _base_Speed_var = (_time_var.g*_Base_Speed);

                float _Is_PingPong_Base_var = lerp(_base_Speed_var, sin(_base_Speed_var), _Is_PingPong_Base );
                float2 scrolledUV = emissive_uv - float2(_Scroll_EmissiveU, _Scroll_EmissiveV)*_Is_PingPong_Base_var;

                float rotateVelocity = _Rotate_EmissiveUV * 3.141592654;
                float2 _rotate_EmissiveUV_var = RotateUV(scrolledUV, rotateVelocity, float2(0.5, 0.5), _Is_PingPong_Base_var);

                float4 _Emissive_Tex_var = tex2D(_Emissive_Tex, TRANSFORM_TEX(Set_UV0, _Emissive_Tex));
                _Emissive_Tex_var = tex2D(_Emissive_Tex, TRANSFORM_TEX(_rotate_EmissiveUV_var, _Emissive_Tex));
                float emissiveMask = _Emissive_Tex_var.a;

                float4 _Bloom_Tex_var = tex2D(_Bloom_Tex, TRANSFORM_TEX(Set_UV0, _Bloom_Tex));
                _Bloom_Tex_var = tex2D(_Bloom_Tex, TRANSFORM_TEX(_rotate_EmissiveUV_var, _Bloom_Tex)) * _BloomShift_Ratio;
                float BloomMask = _Bloom_Tex_var.a;

                float _BloomShift_Speed_var = 1.0 - cos(_time_var.g * _BloomShift_Speed);
                //_BloomShift_Speed_var *= BloomShift_Ratio;
                //float4 BaseBloomColor = lerp(_Emissive_Color, _Bloom_Color, _BloomShift_Speed);
                float4 BaseBloomColor = lerp(_Emissive_Color, lerp(_Emissive_Color, _BloomShift, _BloomShift_Speed_var), _Is_BloomShift);
                BaseBloomColor.rgb = BaseBloomColor.rgb * _BloomShift.rgb * BloomMask;

                float4 BloomTexture = _Bloom_Tex_var;
                float4 Bloom = BloomTexture;
                Bloom.rgb *= BaseBloomColor.rgb;

                //#if _SCROLLING_EMISSION
                // scrolling emission
                float4 _Emissive_Scrolling_Tex_var = tex2D(_Emissive_Tex, TRANSFORM_TEX(_rotate_EmissiveUV_var, _Emissive_Tex) + _Time.y * _EmissionScrollSpeed);
                float4 _emission_var = _Emissive_Scrolling_Tex_var * _Emission_Scrolling_Strength * _Is_Scrolling;

                //#if _SCROLLING_EMISSION
                    float phase = dot(_rotate_EmissiveUV_var, _EmissiveScroll_Direction);
                    phase -= _Time.y * _EmissiveScroll_Velocity;
                    phase /= _EmissiveScroll_Interval;
                    phase -= floor(phase);
                    float width = _EmissiveScroll_Width;
                    phase = (pow(phase, width) + pow(1 - phase, width * 4)) * 0.5;
                    _emission_var *= phase;
                //#endif

                // blinking emission
                float amplitude = (_EmissiveBlink_Max - _EmissiveBlink_Min) * 0.5f;
                float base = _EmissiveBlink_Min + amplitude;
                float emissiveBlink = sin(_Time.y * _EmissiveBlink_Velocity) * amplitude + base;
                _emission_var *= emissiveBlink;
                   
                float _colorShift_Speed_var = 1.0 - cos(_time_var.g*_ColorShift_Speed);
                float viewShift_var = smoothstep( 0.0, 1.0, max(0,dot(normalDirection,viewDirection)));
                float4 colorShift_Color = lerp(_Emissive_Color, lerp(_Emissive_Color, _ColorShift, _colorShift_Speed_var), _Is_ColorShift);
                float4 viewShift_Color = lerp(_ViewShift, colorShift_Color, viewShift_var);
                float4 emissive_Color = lerp(colorShift_Color, viewShift_Color, _Is_ViewShift);
                emissive = emissive_Color.rgb * _Emissive_Tex_var.rgb * emissiveMask;


#endif
                float4 baseTexture = _Emissive_Tex_var;
                float4 Main = baseTexture;
                Main.rgb *= emissive.rgb;
                Main += _emission_var;

                float4 col = float4(0, 0, 0, 0);
                col += Main;
                col += Bloom;
                col = saturate(col);

                //col *= _emission_var;

                return col;
                
            }
            