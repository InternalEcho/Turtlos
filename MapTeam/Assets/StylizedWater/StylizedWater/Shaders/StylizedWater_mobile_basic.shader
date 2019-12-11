// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:Unlit/Transparent,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:False,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:36721,y:32897,varname:node_9361,prsc:2|diff-6015-OUT,spec-8807-OUT,gloss-4832-OUT,normal-3947-OUT,alpha-7951-OUT;n:type:ShaderForge.SFN_DepthBlend,id:7261,x:33855,y:32526,varname:node_7261,prsc:2|DIST-163-OUT;n:type:ShaderForge.SFN_Slider,id:163,x:33477,y:32524,ptovrint:False,ptlb:Rim Size,ptin:_RimSize,varname:_RimSize,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:4;n:type:ShaderForge.SFN_Color,id:3503,x:35657,y:32305,ptovrint:False,ptlb:Water Color,ptin:_WaterColor,varname:_WaterColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.503546,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:6509,x:34349,y:32309,ptovrint:False,ptlb:Rim Color,ptin:_RimColor,varname:_RimColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:6015,x:36236,y:32650,cmnt:Add rim color to water,varname:node_6015,prsc:2|A-3503-RGB,B-6509-RGB,T-457-OUT;n:type:ShaderForge.SFN_Power,id:949,x:34088,y:32646,varname:node_949,prsc:2|VAL-7261-OUT,EXP-3193-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4756,x:33860,y:33277,ptovrint:False,ptlb:Shadermap,ptin:_Shadermap,varname:_Shadermap,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:True,tagnrm:False,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:2,isnm:False;n:type:ShaderForge.SFN_FragmentPosition,id:5725,x:31462,y:32964,varname:node_5725,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:4686,x:31686,y:32964,varname:node_4686,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-5725-XYZ;n:type:ShaderForge.SFN_Multiply,id:5510,x:32087,y:33034,varname:node_5510,prsc:2|A-8213-OUT,B-6834-OUT;n:type:ShaderForge.SFN_Slider,id:3045,x:31529,y:33169,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:_Tiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.9,max:1;n:type:ShaderForge.SFN_Time,id:8305,x:32796,y:33542,varname:node_8305,prsc:2;n:type:ShaderForge.SFN_Tex2dAsset,id:2935,x:34471,y:33862,ptovrint:False,ptlb:Normals,ptin:_Normals,varname:_Normals,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:True,tagnrm:True,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:4911,x:35144,y:33692,varname:NormalMap,prsc:0,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-9360-UVOUT,TEX-2935-TEX;n:type:ShaderForge.SFN_Panner,id:9360,x:34142,y:33629,varname:WavePanningV,prsc:0,spu:0,spv:1|UVIN-5510-OUT,DIST-3981-OUT;n:type:ShaderForge.SFN_Slider,id:6342,x:32386,y:33745,ptovrint:False,ptlb:Waves speed,ptin:_Wavesspeed,varname:_Wavesspeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.75,max:10;n:type:ShaderForge.SFN_Multiply,id:3981,x:32987,y:33696,varname:node_3981,prsc:2|A-8305-T,B-107-OUT;n:type:ShaderForge.SFN_Multiply,id:4832,x:35679,y:33786,varname:node_4832,prsc:2|A-4911-G,B-1805-OUT;n:type:ShaderForge.SFN_Multiply,id:6243,x:33103,y:32950,varname:rimTiling,prsc:0|A-5510-OUT,B-5878-OUT;n:type:ShaderForge.SFN_Slider,id:1805,x:35280,y:34031,ptovrint:False,ptlb:Glossiness,ptin:_Glossiness,varname:_Glossiness,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Panner,id:6391,x:33414,y:33030,varname:rimPanningV,prsc:0,spu:0,spv:0.5|UVIN-6243-OUT,DIST-3981-OUT;n:type:ShaderForge.SFN_Tex2d,id:6468,x:34047,y:33046,varname:rimTexB,prsc:0,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-6391-UVOUT,TEX-4756-TEX;n:type:ShaderForge.SFN_Vector1,id:8807,x:36745,y:32827,varname:node_8807,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:107,x:32796,y:33780,varname:node_107,prsc:2|A-6342-OUT,B-8626-OUT;n:type:ShaderForge.SFN_Vector1,id:8626,x:32543,y:33902,varname:node_8626,prsc:2,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:5878,x:32913,y:33062,ptovrint:False,ptlb:Rim tiling,ptin:_Rimtiling,varname:_Rimtiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_SwitchProperty,id:8213,x:31879,y:32898,ptovrint:False,ptlb:Worldspace tiling,ptin:_Worldspacetiling,varname:_Worldspacetiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-9523-OUT,B-4686-OUT;n:type:ShaderForge.SFN_TexCoord,id:2490,x:31551,y:32730,varname:node_2490,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:3193,x:33477,y:32727,ptovrint:False,ptlb:Rim falloff,ptin:_Rimfalloff,varname:_Rimfalloff,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.25,max:5;n:type:ShaderForge.SFN_Multiply,id:6870,x:35032,y:32865,varname:node_6870,prsc:2|A-7451-OUT,B-6303-OUT,C-6509-A;n:type:ShaderForge.SFN_OneMinus,id:8217,x:34333,y:32646,cmnt:Intersection mask,varname:rimDepthInvert,prsc:0|IN-949-OUT;n:type:ShaderForge.SFN_OneMinus,id:6303,x:34740,y:32977,varname:node_6303,prsc:2|IN-6468-B;n:type:ShaderForge.SFN_Add,id:9324,x:35582,y:32795,varname:AddRimTextureToMask,prsc:0|A-7451-OUT,B-6870-OUT;n:type:ShaderForge.SFN_Multiply,id:9523,x:31712,y:32691,varname:node_9523,prsc:2|A-1592-OUT,B-2490-UVOUT;n:type:ShaderForge.SFN_Vector1,id:1592,x:31551,y:32652,varname:node_1592,prsc:2,v1:-20;n:type:ShaderForge.SFN_OneMinus,id:6834,x:31884,y:33113,varname:node_6834,prsc:2|IN-3045-OUT;n:type:ShaderForge.SFN_Clamp01,id:457,x:35909,y:32812,cmnt:Rim final,varname:node_457,prsc:2|IN-9324-OUT;n:type:ShaderForge.SFN_Multiply,id:7451,x:34645,y:32616,varname:RimAllphaMultiply,prsc:0|A-6509-A,B-8217-OUT;n:type:ShaderForge.SFN_Slider,id:7786,x:35649,y:33124,ptovrint:False,ptlb:Transparency,ptin:_Transparency,varname:_Transparency,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:7951,x:36247,y:33076,varname:node_7951,prsc:2|A-457-OUT,B-7786-OUT;n:type:ShaderForge.SFN_Lerp,id:3947,x:35531,y:33496,varname:node_3947,prsc:2|A-749-OUT,B-4911-RGB,T-8250-OUT;n:type:ShaderForge.SFN_NormalVector,id:749,x:35256,y:33398,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:8250,x:35010,y:33908,ptovrint:False,ptlb:Normal Strength,ptin:_NormalStrength,varname:_NormalStrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;proporder:3503-6509-7786-1805-163-3193-8213-3045-5878-6342-2935-4756-8250;pass:END;sub:END;*/

Shader "StylizedWater/Mobile Basic" {
    Properties {
        _WaterColor ("Water Color", Color) = (0,0.503546,1,1)
        _RimColor ("Rim Color", Color) = (1,1,1,1)
        _Transparency ("Transparency", Range(0, 1)) = 0.5
        _Glossiness ("Glossiness", Range(0, 3)) = 1
        _RimSize ("Rim Size", Range(0, 4)) = 2
        _Rimfalloff ("Rim falloff", Range(0, 5)) = 0.25
        [MaterialToggle] _Worldspacetiling ("Worldspace tiling", Float ) = 0
        _Tiling ("Tiling", Range(0.1, 1)) = 0.9
        _Rimtiling ("Rim tiling", Float ) = 2
        _Wavesspeed ("Waves speed", Range(0, 10)) = 0.75
        [NoScaleOffset][Normal]_Normals ("Normals", 2D) = "bump" {}
        [NoScaleOffset]_Shadermap ("Shadermap", 2D) = "black" {}
        _NormalStrength ("Normal Strength", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D_float _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform fixed _RimSize;
            uniform fixed4 _WaterColor;
            uniform fixed4 _RimColor;
            uniform sampler2D _Shadermap;
            uniform float _Tiling;
            uniform sampler2D _Normals;
            uniform float _Wavesspeed;
            uniform fixed _Glossiness;
            uniform float _Rimtiling;
            uniform fixed _Worldspacetiling;
            uniform fixed _Rimfalloff;
            uniform float _Transparency;
            uniform float _NormalStrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 projPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_8305 = _Time + _TimeEditor;
                float node_3981 = (node_8305.g*(_Wavesspeed*0.1));
                float2 node_5510 = (lerp( ((-20.0)*i.uv0), i.posWorld.rgb.rb, _Worldspacetiling )*(1.0 - _Tiling));
                fixed2 WavePanningV = (node_5510+node_3981*float2(0,1));
                fixed3 NormalMap = UnpackNormal(tex2D(_Normals,WavePanningV));
                float3 normalLocal = lerp(i.normalDir,NormalMap.rgb,_NormalStrength);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 1.0 - (NormalMap.g*_Glossiness); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float3 specularColor = 0.0;
                float specularMonochrome;
                fixed RimAllphaMultiply = (_RimColor.a*(1.0 - pow(saturate((sceneZ-partZ)/_RimSize),_Rimfalloff)));
                fixed2 rimPanningV = ((node_5510*_Rimtiling)+node_3981*float2(0,0.5));
                fixed4 rimTexB = tex2D(_Shadermap,rimPanningV);
                float node_457 = saturate((RimAllphaMultiply+(RimAllphaMultiply*(1.0 - rimTexB.b)*_RimColor.a))); // Rim final
                float3 diffuseColor = lerp(_WaterColor.rgb,_RimColor.rgb,node_457); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, GGXTerm(NdotH, 1.0-gloss));
                float specularPBL = (NdotL*visTerm*normTerm) * (UNITY_PI / 4);
                if (IsGammaSpace())
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                specularPBL = max(0, specularPBL * NdotL);
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,(node_457+_Transparency));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Unlit/Transparent"
}
