// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:Unlit/Transparent,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:RefractionPass,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:1,ofsu:0,f2p0:False,fnsp:True,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:36448,y:33777,cmnt:Outputs,varname:node_9361,prsc:2|diff-8266-OUT,spec-8807-OUT,gloss-7592-OUT,normal-8494-OUT,amdfl-2876-OUT,alpha-2433-OUT,refract-1798-OUT,disp-933-OUT,tess-8040-OUT;n:type:ShaderForge.SFN_DepthBlend,id:7261,x:31951,y:32413,varname:node_7261,prsc:2|DIST-163-OUT;n:type:ShaderForge.SFN_Slider,id:163,x:31563,y:32414,ptovrint:False,ptlb:Rim Size,ptin:_RimSize,varname:_RimSize,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:4;n:type:ShaderForge.SFN_Color,id:3503,x:34333,y:31317,ptovrint:False,ptlb:Water Color,ptin:_WaterColor,varname:_WaterColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.503546,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:6509,x:32564,y:32231,ptovrint:False,ptlb:Rim Color,ptin:_RimColor,varname:_RimColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:6015,x:35402,y:31888,cmnt:Add rim color to water,varname:node_6015,prsc:2|A-691-OUT,B-6509-RGB,T-2630-OUT;n:type:ShaderForge.SFN_Power,id:949,x:32166,y:32588,varname:node_949,prsc:2|VAL-7261-OUT,EXP-3193-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4756,x:31491,y:33628,ptovrint:False,ptlb:Shadermap,ptin:_Shadermap,varname:_Shadermap,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:True,tagnrm:False,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:2,isnm:False;n:type:ShaderForge.SFN_FragmentPosition,id:5725,x:31691,y:30558,varname:node_5725,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:4686,x:31915,y:30558,varname:node_4686,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-5725-XYZ;n:type:ShaderForge.SFN_Multiply,id:5510,x:32316,y:30628,varname:node_5510,prsc:2|A-8213-OUT,B-6834-OUT;n:type:ShaderForge.SFN_Slider,id:3045,x:31758,y:30763,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:_Tiling,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.9,max:1;n:type:ShaderForge.SFN_Set,id:8104,x:33718,y:35231,varname:Refraction,prsc:2|IN-5220-OUT;n:type:ShaderForge.SFN_Get,id:1798,x:36209,y:34092,varname:node_1798,prsc:2|IN-8104-OUT;n:type:ShaderForge.SFN_Multiply,id:5220,x:33540,y:35231,varname:node_5220,prsc:2|A-4086-OUT,B-8903-OUT;n:type:ShaderForge.SFN_Slider,id:4086,x:33163,y:35110,ptovrint:False,ptlb:Refraction Amount,ptin:_RefractionAmount,varname:_RefractionAmount,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:0.2;n:type:ShaderForge.SFN_Time,id:8305,x:33365,y:30357,varname:Time,prsc:2;n:type:ShaderForge.SFN_Slider,id:832,x:34333,y:30875,ptovrint:False,ptlb:Transparency,ptin:_Transparency,varname:_Transparency,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.75,max:1;n:type:ShaderForge.SFN_Tex2dAsset,id:2935,x:32480,y:35417,ptovrint:False,ptlb:Normals,ptin:_Normals,varname:_Normals,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:True,tagnrm:True,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:4911,x:32756,y:35343,varname:WavePanningV_Tex,prsc:0,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-9360-UVOUT,TEX-2935-TEX;n:type:ShaderForge.SFN_Panner,id:9360,x:32030,y:34919,varname:WavePanningV,prsc:0,spu:0,spv:1.1|UVIN-5129-OUT,DIST-8956-OUT;n:type:ShaderForge.SFN_Tex2d,id:9198,x:32756,y:35527,varname:WavePanningU_Tex,prsc:0,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-1488-UVOUT,TEX-2935-TEX;n:type:ShaderForge.SFN_Panner,id:1488,x:32030,y:35118,varname:WavePanningU,prsc:0,spu:0.1,spv:0|UVIN-5129-OUT,DIST-8956-OUT;n:type:ShaderForge.SFN_Slider,id:6342,x:32955,y:30529,ptovrint:False,ptlb:Waves speed,ptin:_Wavesspeed,varname:_Wavesspeed,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.75,max:10;n:type:ShaderForge.SFN_Multiply,id:3981,x:33556,y:30480,varname:node_3981,prsc:2|A-8305-T,B-107-OUT;n:type:ShaderForge.SFN_Blend,id:409,x:33127,y:35787,varname:node_409,prsc:2,blmd:6,clmp:True|SRC-4911-R,DST-9198-G;n:type:ShaderForge.SFN_Multiply,id:4832,x:33399,y:35851,varname:node_4832,prsc:2|A-409-OUT,B-1805-OUT;n:type:ShaderForge.SFN_Multiply,id:6243,x:31634,y:32930,varname:rimTiling,prsc:0|A-2721-OUT,B-5878-OUT;n:type:ShaderForge.SFN_Slider,id:1805,x:33000,y:36021,ptovrint:False,ptlb:Glossiness,ptin:_Glossiness,varname:_Glossiness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Set,id:2341,x:32545,y:30628,varname:Tiling,prsc:0|IN-5510-OUT;n:type:ShaderForge.SFN_Get,id:2721,x:31423,y:32894,varname:node_2721,prsc:2|IN-2341-OUT;n:type:ShaderForge.SFN_Get,id:5129,x:31666,y:34994,varname:mTiling,prsc:0|IN-2341-OUT;n:type:ShaderForge.SFN_Set,id:2137,x:34621,y:35527,varname:Normals,prsc:2|IN-1436-OUT;n:type:ShaderForge.SFN_Get,id:8494,x:36209,y:33877,varname:node_8494,prsc:2|IN-2137-OUT;n:type:ShaderForge.SFN_Tex2d,id:1028,x:32223,y:32988,varname:rimU_Tex,prsc:2,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-1318-UVOUT,TEX-4756-TEX;n:type:ShaderForge.SFN_Panner,id:1318,x:31958,y:32988,varname:rimPanningU,prsc:0,spu:0.5,spv:0.1|UVIN-6243-OUT,DIST-2352-OUT;n:type:ShaderForge.SFN_Multiply,id:8846,x:32476,y:33151,varname:node_8846,prsc:2|A-1028-B,B-6468-B;n:type:ShaderForge.SFN_Panner,id:6391,x:31958,y:33244,varname:rimPanningV,prsc:0,spu:0,spv:1|UVIN-6243-OUT,DIST-2352-OUT;n:type:ShaderForge.SFN_Tex2d,id:6468,x:32215,y:33245,varname:rimV_Tex,prsc:2,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-6391-UVOUT,TEX-4756-TEX;n:type:ShaderForge.SFN_Append,id:8903,x:33163,y:35250,varname:node_8903,prsc:2|A-4911-R,B-9198-G;n:type:ShaderForge.SFN_Vector1,id:8807,x:36470,y:33679,varname:node_8807,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:7600,x:33386,y:33741,varname:DisplacementDirection,prsc:2|A-3950-G,B-3758-OUT;n:type:ShaderForge.SFN_Slider,id:3758,x:32968,y:33831,ptovrint:False,ptlb:Waves strength,ptin:_Wavesstrength,varname:_Wavesstrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:107,x:33365,y:30564,varname:node_107,prsc:2|A-6342-OUT,B-8626-OUT;n:type:ShaderForge.SFN_Vector1,id:8626,x:33112,y:30686,varname:node_8626,prsc:2,v1:0.1;n:type:ShaderForge.SFN_NormalVector,id:8130,x:34520,y:32479,prsc:2,pt:False;n:type:ShaderForge.SFN_Fresnel,id:3544,x:34728,y:32479,varname:node_3544,prsc:2|NRM-8130-OUT;n:type:ShaderForge.SFN_Power,id:807,x:35031,y:32489,varname:node_807,prsc:2|VAL-3544-OUT,EXP-1906-OUT;n:type:ShaderForge.SFN_OneMinus,id:3646,x:35442,y:32499,varname:invertFresnel,prsc:0|IN-2221-OUT;n:type:ShaderForge.SFN_Lerp,id:5570,x:35783,y:32014,cmnt:Add fresnel,varname:AddFresnel,prsc:2|A-1369-RGB,B-6015-OUT,T-3646-OUT;n:type:ShaderForge.SFN_Slider,id:9211,x:33960,y:31617,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:_Depth,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:30,max:30;n:type:ShaderForge.SFN_DepthBlend,id:4175,x:34341,y:31619,varname:depth,prsc:2|DIST-9211-OUT;n:type:ShaderForge.SFN_Set,id:1450,x:33786,y:30480,varname:WaveSpeed,prsc:2|IN-3981-OUT;n:type:ShaderForge.SFN_Get,id:8956,x:31666,y:35124,varname:mWaveSpeed,prsc:0|IN-1450-OUT;n:type:ShaderForge.SFN_Blend,id:1465,x:35295,y:31197,cmnt:Depth based transparency,varname:DepthTransparency,prsc:2,blmd:10,clmp:True|SRC-4175-OUT,DST-6557-OUT;n:type:ShaderForge.SFN_Multiply,id:2523,x:34691,y:31786,varname:node_2523,prsc:0|A-3503-RGB,B-4919-OUT;n:type:ShaderForge.SFN_Slider,id:9486,x:33960,y:31830,ptovrint:False,ptlb:Depth darkness,ptin:_Depthdarkness,varname:_Depthdarkness,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Lerp,id:691,x:34989,y:31708,cmnt:Final water color,varname:node_691,prsc:2|A-3503-RGB,B-2523-OUT,T-4175-OUT;n:type:ShaderForge.SFN_OneMinus,id:4919,x:34341,y:31832,varname:node_4919,prsc:0|IN-9486-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5878,x:31444,y:33008,ptovrint:False,ptlb:Rim tiling,ptin:_Rimtiling,varname:_Rimtiling,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_SwitchProperty,id:8213,x:32108,y:30492,ptovrint:False,ptlb:Worldspace tiling,ptin:_Worldspacetiling,varname:_Worldspacetiling,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-9523-OUT,B-4686-OUT;n:type:ShaderForge.SFN_TexCoord,id:2490,x:31780,y:30324,varname:node_2490,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:3193,x:31563,y:32609,ptovrint:False,ptlb:Rim falloff,ptin:_Rimfalloff,varname:_Rimfalloff,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.25,max:5;n:type:ShaderForge.SFN_Multiply,id:6870,x:33229,y:32753,varname:node_6870,prsc:2|A-7451-OUT,B-6303-OUT,C-6509-A;n:type:ShaderForge.SFN_OneMinus,id:6303,x:32763,y:33071,cmnt:Cross panning intersection texture,varname:node_6303,prsc:2|IN-8846-OUT;n:type:ShaderForge.SFN_Add,id:9324,x:33454,y:32717,varname:AddRimTextureToMask,prsc:2|A-7451-OUT,B-6870-OUT;n:type:ShaderForge.SFN_Slider,id:8040,x:36222,y:34270,ptovrint:False,ptlb:Tessellation,ptin:_Tessellation,varname:_Tessellation,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.1,max:10;n:type:ShaderForge.SFN_Slider,id:790,x:34076,y:34311,ptovrint:False,ptlb:Surface Highlight,ptin:_SurfaceHighlight,varname:_SurfaceHighlight,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05,max:1;n:type:ShaderForge.SFN_Multiply,id:1881,x:34471,y:34483,varname:node_1881,prsc:2|A-790-OUT,B-158-OUT;n:type:ShaderForge.SFN_Clamp01,id:758,x:34683,y:34483,varname:ClampHighlight,prsc:2|IN-1881-OUT;n:type:ShaderForge.SFN_Subtract,id:2610,x:33557,y:34433,varname:node_2610,prsc:2|A-8200-OUT,B-5823-OUT;n:type:ShaderForge.SFN_Slider,id:4493,x:33439,y:34298,ptovrint:False,ptlb:Surface hightlight size,ptin:_Surfacehightlightsize,varname:_Surfacehightlightsize,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:5469,x:32784,y:34413,varname:HighlightPanningV_Tex,prsc:2,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-1986-OUT,TEX-4756-TEX;n:type:ShaderForge.SFN_Tex2d,id:8808,x:32786,y:34588,varname:HightlightPanningU_Tex,prsc:2,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-5631-OUT,TEX-4756-TEX;n:type:ShaderForge.SFN_Multiply,id:5631,x:32531,y:34612,varname:HightlightPanningU,prsc:2|A-1488-UVOUT,B-3883-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3883,x:32002,y:34507,ptovrint:False,ptlb:Surface Hightlight tiling,ptin:_SurfaceHightlighttiling,varname:_SurfaceHightlighttiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_Multiply,id:1986,x:32549,y:34413,varname:HighlightPanningV,prsc:2|A-9360-UVOUT,B-3883-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1906,x:34794,y:32636,ptovrint:False,ptlb:Fresnel exponent,ptin:_Fresnelexponent,varname:_Fresnelexponent,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:9523,x:31941,y:30285,varname:node_9523,prsc:2|A-1592-OUT,B-2490-UVOUT;n:type:ShaderForge.SFN_Vector1,id:1592,x:31780,y:30246,varname:node_1592,prsc:2,v1:-20;n:type:ShaderForge.SFN_OneMinus,id:6834,x:32113,y:30707,varname:node_6834,prsc:2|IN-3045-OUT;n:type:ShaderForge.SFN_Clamp01,id:457,x:33664,y:32717,cmnt:Rim final,varname:node_457,prsc:2|IN-9324-OUT;n:type:ShaderForge.SFN_Multiply,id:7451,x:32871,y:32629,cmnt:Control rim opacity with color alpha,varname:RimAllphaMultiply,prsc:2|A-7913-OUT,B-6509-A;n:type:ShaderForge.SFN_Color,id:1369,x:35031,y:32245,ptovrint:False,ptlb:Fresnel Color,ptin:_FresnelColor,varname:_FresnelColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:0.5019608;n:type:ShaderForge.SFN_Multiply,id:2221,x:35248,y:32499,varname:node_2221,prsc:2|A-807-OUT,B-1369-A;n:type:ShaderForge.SFN_Step,id:8963,x:33899,y:34429,varname:node_8963,prsc:2|A-4493-OUT,B-2610-OUT;n:type:ShaderForge.SFN_NormalVector,id:4752,x:33386,y:33567,prsc:2,pt:True;n:type:ShaderForge.SFN_Set,id:8064,x:33615,y:35822,varname:Roughness,prsc:2|IN-4832-OUT;n:type:ShaderForge.SFN_Get,id:7592,x:36209,y:33818,varname:node_7592,prsc:2|IN-8064-OUT;n:type:ShaderForge.SFN_NormalBlend,id:3220,x:33146,y:35490,varname:WaveNormalBlend,prsc:2|BSE-4911-RGB,DTL-9198-RGB;n:type:ShaderForge.SFN_Slider,id:7640,x:31563,y:32236,ptovrint:False,ptlb:Rim Distance,ptin:_RimDistance,varname:_RimDistance,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_DepthBlend,id:4045,x:31951,y:32235,varname:node_4045,prsc:2|DIST-7640-OUT;n:type:ShaderForge.SFN_Subtract,id:7913,x:32405,y:32445,cmnt:Intersection mask,varname:node_7913,prsc:2|A-4045-OUT,B-949-OUT;n:type:ShaderForge.SFN_Multiply,id:3507,x:33535,y:34590,varname:node_3507,prsc:2|A-8200-OUT,B-5823-OUT;n:type:ShaderForge.SFN_OneMinus,id:1273,x:33899,y:34619,varname:node_1273,prsc:2|IN-5333-OUT;n:type:ShaderForge.SFN_Set,id:4330,x:33866,y:32717,varname:Intersection,prsc:2|IN-457-OUT;n:type:ShaderForge.SFN_Get,id:8832,x:34304,y:31054,varname:node_8832,prsc:2|IN-4330-OUT;n:type:ShaderForge.SFN_Set,id:6326,x:34902,y:34483,varname:SurfaceHighlights,prsc:2|IN-758-OUT;n:type:ShaderForge.SFN_Get,id:7705,x:34420,y:31215,varname:node_7705,prsc:2|IN-6326-OUT;n:type:ShaderForge.SFN_Set,id:41,x:35567,y:31197,varname:Opacity,prsc:2|IN-1465-OUT;n:type:ShaderForge.SFN_Get,id:2433,x:36209,y:34037,varname:node_2433,prsc:2|IN-41-OUT;n:type:ShaderForge.SFN_Set,id:7614,x:37139,y:32015,varname:Color,prsc:2|IN-2631-OUT;n:type:ShaderForge.SFN_Get,id:8791,x:36048,y:32099,varname:node_8791,prsc:2|IN-6326-OUT;n:type:ShaderForge.SFN_Get,id:8266,x:36209,y:33763,varname:node_8266,prsc:2|IN-7614-OUT;n:type:ShaderForge.SFN_Get,id:2630,x:35084,y:32053,varname:node_2630,prsc:2|IN-4330-OUT;n:type:ShaderForge.SFN_Get,id:2352,x:31634,y:33165,varname:node_2352,prsc:2|IN-1450-OUT;n:type:ShaderForge.SFN_Set,id:6726,x:33829,y:33694,varname:Displacement,prsc:2|IN-8106-OUT;n:type:ShaderForge.SFN_Get,id:933,x:36209,y:34162,varname:node_933,prsc:2|IN-6726-OUT;n:type:ShaderForge.SFN_Tex2d,id:3950,x:33113,y:33620,varname:HeightmapTex,prsc:2,tex:e3d849a71cf1896458f0932f079b66a3,ntxv:0,isnm:False|UVIN-5626-UVOUT,TEX-4756-TEX;n:type:ShaderForge.SFN_Multiply,id:6703,x:32628,y:33567,cmnt:Adjust for tiling defined through Substance,varname:node_6703,prsc:2|A-1904-OUT,B-9621-OUT;n:type:ShaderForge.SFN_Panner,id:5626,x:32819,y:33614,varname:node_5626,prsc:2,spu:0,spv:1|UVIN-6703-OUT,DIST-6645-OUT;n:type:ShaderForge.SFN_Get,id:1904,x:32408,y:33533,varname:node_1904,prsc:2|IN-2341-OUT;n:type:ShaderForge.SFN_Add,id:8599,x:34617,y:31122,cmnt:Items excluded from transparency,varname:node_8599,prsc:2|A-8832-OUT,B-7705-OUT;n:type:ShaderForge.SFN_Clamp01,id:2631,x:36853,y:31986,varname:node_2631,prsc:2|IN-881-OUT;n:type:ShaderForge.SFN_Add,id:6557,x:34851,y:30963,varname:node_6557,prsc:2|A-832-OUT,B-8832-OUT;n:type:ShaderForge.SFN_Lerp,id:9987,x:36332,y:31992,varname:node_9987,prsc:2|A-5570-OUT,B-2445-OUT,T-8791-OUT;n:type:ShaderForge.SFN_Vector3,id:2445,x:36018,y:31879,varname:node_2445,prsc:2,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_Multiply,id:8106,x:33659,y:33694,cmnt:Move in normal direction for spheres,varname:node_8106,prsc:2|A-4752-OUT,B-7600-OUT;n:type:ShaderForge.SFN_Set,id:9078,x:33649,y:33837,varname:Heightmap,prsc:2|IN-7600-OUT;n:type:ShaderForge.SFN_Get,id:3992,x:32386,y:33738,varname:node_3992,prsc:2|IN-1450-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5333,x:33727,y:34699,ptovrint:True,ptlb:HighlightPanning,ptin:_HighlightPanning,varname:_HighlightPanning,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5823-OUT,B-3507-OUT;n:type:ShaderForge.SFN_Multiply,id:6645,x:32621,y:33724,varname:node_6645,prsc:2|A-3992-OUT,B-7249-OUT;n:type:ShaderForge.SFN_Vector1,id:7249,x:32459,y:33858,varname:node_7249,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Subtract,id:881,x:36615,y:31986,varname:node_881,prsc:2|A-9987-OUT,B-6000-OUT;n:type:ShaderForge.SFN_Multiply,id:6000,x:36305,y:32294,varname:node_6000,prsc:2|A-3950-G,B-3811-OUT;n:type:ShaderForge.SFN_Lerp,id:8048,x:33640,y:35523,cmnt:Mask out SH from normals,varname:node_8048,prsc:2|A-3220-OUT,B-2944-OUT,T-1765-OUT;n:type:ShaderForge.SFN_Get,id:1765,x:33380,y:35678,varname:node_1765,prsc:2|IN-6326-OUT;n:type:ShaderForge.SFN_Vector3,id:2944,x:33380,y:35558,varname:node_2944,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Cubemap,id:3442,x:33191,y:36336,ptovrint:False,ptlb:Reflection,ptin:_Reflection,varname:_Reflection,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:0|DIR-4908-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:4908,x:32993,y:36336,varname:node_4908,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2164,x:33445,y:36322,varname:node_2164,prsc:2|A-1805-OUT,B-3442-RGB;n:type:ShaderForge.SFN_Set,id:8232,x:33916,y:36331,varname:Reflection,prsc:2|IN-2909-OUT;n:type:ShaderForge.SFN_Get,id:2876,x:36209,y:33956,varname:node_2876,prsc:2|IN-8232-OUT;n:type:ShaderForge.SFN_Clamp01,id:2909,x:33658,y:36343,varname:node_2909,prsc:2|IN-2164-OUT;n:type:ShaderForge.SFN_Slider,id:3811,x:35888,y:32460,ptovrint:False,ptlb:Wave tint,ptin:_Wavetint,varname:_Wavetint,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_ValueProperty,id:9621,x:32407,y:33620,ptovrint:False,ptlb:WaveSize,ptin:_WaveSize,varname:_WaveSize,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_NormalVector,id:4536,x:34105,y:35406,prsc:2,pt:False;n:type:ShaderForge.SFN_Lerp,id:1436,x:34373,y:35525,varname:node_1436,prsc:2|A-4536-OUT,B-8048-OUT,T-7711-OUT;n:type:ShaderForge.SFN_Slider,id:7711,x:33928,y:35657,ptovrint:False,ptlb:Normal Strength,ptin:_NormalStrength,varname:_NormalStrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Lerp,id:5823,x:33128,y:34633,varname:node_5823,prsc:2|A-8808-R,B-8808-B,T-7340-OUT;n:type:ShaderForge.SFN_Slider,id:7340,x:32639,y:34883,ptovrint:False,ptlb:UseIntersectionHighlight,ptin:_UseIntersectionHighlight,varname:_UseIntersectionHighlight,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:8200,x:33107,y:34369,varname:node_8200,prsc:2|A-5469-R,B-5469-B,T-7340-OUT;n:type:ShaderForge.SFN_Lerp,id:158,x:34202,y:34517,varname:node_158,prsc:2|A-8963-OUT,B-1273-OUT,T-7340-OUT;n:type:ShaderForge.SFN_ViewVector,id:9035,x:30712,y:34315,varname:node_9035,prsc:2;n:type:ShaderForge.SFN_LightVector,id:5617,x:30712,y:34536,varname:node_5617,prsc:2;n:type:ShaderForge.SFN_Add,id:6628,x:31110,y:34394,varname:node_6628,prsc:2|A-611-OUT,B-9222-OUT;n:type:ShaderForge.SFN_Normalize,id:7846,x:31311,y:34394,varname:node_7846,prsc:2|IN-6628-OUT;n:type:ShaderForge.SFN_Normalize,id:9222,x:30892,y:34535,varname:node_9222,prsc:2|IN-5617-OUT;n:type:ShaderForge.SFN_Normalize,id:611,x:30877,y:34333,varname:node_611,prsc:2|IN-9035-OUT;proporder:3503-6509-1369-3811-1906-7711-832-1805-790-4493-3883-7340-5333-9211-9486-163-3193-7640-8213-3045-5878-4086-6342-3758-9621-2935-4756-8040-3442;pass:END;sub:END;*/

Shader "StylizedWater/Desktop (DX11 Tessellation)" {
    Properties {
        _WaterColor ("Water Color", Color) = (0,0.503546,1,1)
        _RimColor ("Rim Color", Color) = (1,1,1,1)
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,0.5019608)
        _Wavetint ("Wave tint", Range(-1, 1)) = 0
        _Fresnelexponent ("Fresnel exponent", Float ) = 4
        _NormalStrength ("Normal Strength", Range(0, 1)) = 1
        _Transparency ("Transparency", Range(0, 1)) = 0.75
        _Glossiness ("Glossiness", Range(0, 3)) = 1
        _SurfaceHighlight ("Surface Highlight", Range(0, 1)) = 0.05
        _Surfacehightlightsize ("Surface hightlight size", Range(0, 1)) = 0
        _SurfaceHightlighttiling ("Surface Hightlight tiling", Float ) = 0.25
        _UseIntersectionHighlight ("UseIntersectionHighlight", Range(0, 1)) = 0
        [MaterialToggle] _HighlightPanning ("HighlightPanning", Float ) = 0
        _Depth ("Depth", Range(0, 30)) = 30
        _Depthdarkness ("Depth darkness", Range(0, 1)) = 0.5
        _RimSize ("Rim Size", Range(0, 4)) = 2
        _Rimfalloff ("Rim falloff", Range(0, 5)) = 0.25
        _RimDistance ("Rim Distance", Range(0, 1)) = 0.1
        [MaterialToggle] _Worldspacetiling ("Worldspace tiling", Float ) = 1
        _Tiling ("Tiling", Range(0.1, 1)) = 0.9
        _Rimtiling ("Rim tiling", Float ) = 2
        _RefractionAmount ("Refraction Amount", Range(0, 0.2)) = 0.1
        _Wavesspeed ("Waves speed", Range(0, 10)) = 0.75
        _Wavesstrength ("Waves strength", Range(0, 1)) = 0
        _WaveSize ("WaveSize", Float ) = 0.1
        [NoScaleOffset][Normal]_Normals ("Normals", 2D) = "bump" {}
        [NoScaleOffset]_Shadermap ("Shadermap", 2D) = "black" {}
        _Tessellation ("Tessellation", Range(0.1, 10)) = 0.1
        _Reflection ("Reflection", Cube) = "_Skybox" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Offset 1, 0
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform fixed _RimSize;
            uniform fixed4 _WaterColor;
            uniform fixed4 _RimColor;
            uniform sampler2D _Shadermap;
            uniform fixed _Tiling;
            uniform float _RefractionAmount;
            uniform float _Transparency;
            uniform sampler2D _Normals;
            uniform fixed _Wavesspeed;
            uniform float _Glossiness;
            uniform float _Wavesstrength;
            uniform fixed _Depth;
            uniform fixed _Depthdarkness;
            uniform fixed _Rimtiling;
            uniform fixed _Worldspacetiling;
            uniform fixed _Rimfalloff;
            uniform float _Tessellation;
            uniform float _SurfaceHighlight;
            uniform float _Surfacehightlightsize;
            uniform float _SurfaceHightlighttiling;
            uniform float _Fresnelexponent;
            uniform float4 _FresnelColor;
            uniform float _RimDistance;
            uniform fixed _HighlightPanning;
            uniform samplerCUBE _Reflection;
            uniform float _Wavetint;
            uniform float _WaveSize;
            uniform float _NormalStrength;
            uniform float _UseIntersectionHighlight;
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
                float4 screenPos : TEXCOORD5;
                float4 projPos : TEXCOORD6;
                UNITY_FOG_COORDS(7)
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
                o.screenPos = o.pos;
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 Time = _Time + _TimeEditor;
                    float WaveSpeed = (Time.g*(_Wavesspeed*0.1));
                    fixed2 Tiling = (lerp( ((-20.0)*v.texcoord0), mul(unity_ObjectToWorld, v.vertex).rgb.rb, _Worldspacetiling )*(1.0 - _Tiling));
                    float2 node_5626 = ((Tiling*_WaveSize)+(WaveSpeed*0.5)*float2(0,1));
                    float4 HeightmapTex = tex2Dlod(_Shadermap,float4(node_5626,0.0,0));
                    float DisplacementDirection = (HeightmapTex.g*_Wavesstrength);
                    float3 Displacement = (v.normal*DisplacementDirection);
                    v.vertex.xyz += Displacement;
                }
                float Tessellation(TessVertex v){
                    return _Tessellation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 Time = _Time + _TimeEditor;
                float WaveSpeed = (Time.g*(_Wavesspeed*0.1));
                fixed mWaveSpeed = WaveSpeed;
                fixed2 Tiling = (lerp( ((-20.0)*i.uv0), i.posWorld.rgb.rb, _Worldspacetiling )*(1.0 - _Tiling));
                fixed2 mTiling = Tiling;
                fixed2 WavePanningV = (mTiling+mWaveSpeed*float2(0,1.1));
                fixed3 WavePanningV_Tex = UnpackNormal(tex2D(_Normals,WavePanningV));
                fixed2 WavePanningU = (mTiling+mWaveSpeed*float2(0.1,0));
                fixed3 WavePanningU_Tex = UnpackNormal(tex2D(_Normals,WavePanningU));
                float3 WaveNormalBlend_nrm_base = WavePanningV_Tex.rgb + float3(0,0,1);
                float3 WaveNormalBlend_nrm_detail = WavePanningU_Tex.rgb * float3(-1,-1,1);
                float3 WaveNormalBlend_nrm_combined = WaveNormalBlend_nrm_base*dot(WaveNormalBlend_nrm_base, WaveNormalBlend_nrm_detail)/WaveNormalBlend_nrm_base.z - WaveNormalBlend_nrm_detail;
                float3 WaveNormalBlend = WaveNormalBlend_nrm_combined;
                float2 HighlightPanningV = (WavePanningV*_SurfaceHightlighttiling);
                float4 HighlightPanningV_Tex = tex2D(_Shadermap,HighlightPanningV);
                float node_8200 = lerp(HighlightPanningV_Tex.r,HighlightPanningV_Tex.b,_UseIntersectionHighlight);
                float2 HightlightPanningU = (WavePanningU*_SurfaceHightlighttiling);
                float4 HightlightPanningU_Tex = tex2D(_Shadermap,HightlightPanningU);
                float node_5823 = lerp(HightlightPanningU_Tex.r,HightlightPanningU_Tex.b,_UseIntersectionHighlight);
                float SurfaceHighlights = saturate((_SurfaceHighlight*lerp(step(_Surfacehightlightsize,(node_8200-node_5823)),(1.0 - lerp( node_5823, (node_8200*node_5823), _HighlightPanning )),_UseIntersectionHighlight)));
                float3 Normals = lerp(i.normalDir,lerp(WaveNormalBlend,float3(0,0,1),SurfaceHighlights),_NormalStrength);
                float3 normalLocal = Normals;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float2 Refraction = (_RefractionAmount*float2(WavePanningV_Tex.r,WavePanningU_Tex.g));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + Refraction;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float Roughness = (saturate((1.0-(1.0-WavePanningV_Tex.r)*(1.0-WavePanningU_Tex.g)))*_Glossiness);
                float gloss = 1.0 - Roughness; // Convert roughness to gloss
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
                float depth = saturate((sceneZ-partZ)/_Depth);
                float RimAllphaMultiply = ((saturate((sceneZ-partZ)/_RimDistance)-pow(saturate((sceneZ-partZ)/_RimSize),_Rimfalloff))*_RimColor.a); // Control rim opacity with color alpha
                float node_2352 = WaveSpeed;
                fixed2 rimTiling = (Tiling*_Rimtiling);
                fixed2 rimPanningU = (rimTiling+node_2352*float2(0.5,0.1));
                float4 rimU_Tex = tex2D(_Shadermap,rimPanningU);
                fixed2 rimPanningV = (rimTiling+node_2352*float2(0,1));
                float4 rimV_Tex = tex2D(_Shadermap,rimPanningV);
                float Intersection = saturate((RimAllphaMultiply+(RimAllphaMultiply*(1.0 - (rimU_Tex.b*rimV_Tex.b))*_RimColor.a)));
                float2 node_5626 = ((Tiling*_WaveSize)+(WaveSpeed*0.5)*float2(0,1));
                float4 HeightmapTex = tex2D(_Shadermap,node_5626);
                float3 Color = saturate((lerp(lerp(_FresnelColor.rgb,lerp(lerp(_WaterColor.rgb,(_WaterColor.rgb*(1.0 - _Depthdarkness)),depth),_RimColor.rgb,Intersection),(1.0 - (pow((1.0-max(0,dot(i.normalDir, viewDirection))),_Fresnelexponent)*_FresnelColor.a))),float3(1,1,1),SurfaceHighlights)-(HeightmapTex.g*_Wavetint)));
                float3 diffuseColor = Color; // Need this for specular when using metallic
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
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz)*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 Reflection = saturate((_Glossiness*texCUBE(_Reflection,viewReflectDirection).rgb));
                indirectDiffuse += Reflection; // Diffuse Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_8832 = Intersection;
                float Opacity = saturate(( (_Transparency+node_8832) > 0.5 ? (1.0-(1.0-2.0*((_Transparency+node_8832)-0.5))*(1.0-depth)) : (2.0*(_Transparency+node_8832)*depth) ));
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,Opacity),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            Offset 1, 0
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform fixed _RimSize;
            uniform fixed4 _WaterColor;
            uniform fixed4 _RimColor;
            uniform sampler2D _Shadermap;
            uniform fixed _Tiling;
            uniform float _RefractionAmount;
            uniform float _Transparency;
            uniform sampler2D _Normals;
            uniform fixed _Wavesspeed;
            uniform float _Glossiness;
            uniform float _Wavesstrength;
            uniform fixed _Depth;
            uniform fixed _Depthdarkness;
            uniform fixed _Rimtiling;
            uniform fixed _Worldspacetiling;
            uniform fixed _Rimfalloff;
            uniform float _Tessellation;
            uniform float _SurfaceHighlight;
            uniform float _Surfacehightlightsize;
            uniform float _SurfaceHightlighttiling;
            uniform float _Fresnelexponent;
            uniform float4 _FresnelColor;
            uniform float _RimDistance;
            uniform fixed _HighlightPanning;
            uniform float _Wavetint;
            uniform float _WaveSize;
            uniform float _NormalStrength;
            uniform float _UseIntersectionHighlight;
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
                float4 screenPos : TEXCOORD5;
                float4 projPos : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
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
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 Time = _Time + _TimeEditor;
                    float WaveSpeed = (Time.g*(_Wavesspeed*0.1));
                    fixed2 Tiling = (lerp( ((-20.0)*v.texcoord0), mul(unity_ObjectToWorld, v.vertex).rgb.rb, _Worldspacetiling )*(1.0 - _Tiling));
                    float2 node_5626 = ((Tiling*_WaveSize)+(WaveSpeed*0.5)*float2(0,1));
                    float4 HeightmapTex = tex2Dlod(_Shadermap,float4(node_5626,0.0,0));
                    float DisplacementDirection = (HeightmapTex.g*_Wavesstrength);
                    float3 Displacement = (v.normal*DisplacementDirection);
                    v.vertex.xyz += Displacement;
                }
                float Tessellation(TessVertex v){
                    return _Tessellation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 Time = _Time + _TimeEditor;
                float WaveSpeed = (Time.g*(_Wavesspeed*0.1));
                fixed mWaveSpeed = WaveSpeed;
                fixed2 Tiling = (lerp( ((-20.0)*i.uv0), i.posWorld.rgb.rb, _Worldspacetiling )*(1.0 - _Tiling));
                fixed2 mTiling = Tiling;
                fixed2 WavePanningV = (mTiling+mWaveSpeed*float2(0,1.1));
                fixed3 WavePanningV_Tex = UnpackNormal(tex2D(_Normals,WavePanningV));
                fixed2 WavePanningU = (mTiling+mWaveSpeed*float2(0.1,0));
                fixed3 WavePanningU_Tex = UnpackNormal(tex2D(_Normals,WavePanningU));
                float3 WaveNormalBlend_nrm_base = WavePanningV_Tex.rgb + float3(0,0,1);
                float3 WaveNormalBlend_nrm_detail = WavePanningU_Tex.rgb * float3(-1,-1,1);
                float3 WaveNormalBlend_nrm_combined = WaveNormalBlend_nrm_base*dot(WaveNormalBlend_nrm_base, WaveNormalBlend_nrm_detail)/WaveNormalBlend_nrm_base.z - WaveNormalBlend_nrm_detail;
                float3 WaveNormalBlend = WaveNormalBlend_nrm_combined;
                float2 HighlightPanningV = (WavePanningV*_SurfaceHightlighttiling);
                float4 HighlightPanningV_Tex = tex2D(_Shadermap,HighlightPanningV);
                float node_8200 = lerp(HighlightPanningV_Tex.r,HighlightPanningV_Tex.b,_UseIntersectionHighlight);
                float2 HightlightPanningU = (WavePanningU*_SurfaceHightlighttiling);
                float4 HightlightPanningU_Tex = tex2D(_Shadermap,HightlightPanningU);
                float node_5823 = lerp(HightlightPanningU_Tex.r,HightlightPanningU_Tex.b,_UseIntersectionHighlight);
                float SurfaceHighlights = saturate((_SurfaceHighlight*lerp(step(_Surfacehightlightsize,(node_8200-node_5823)),(1.0 - lerp( node_5823, (node_8200*node_5823), _HighlightPanning )),_UseIntersectionHighlight)));
                float3 Normals = lerp(i.normalDir,lerp(WaveNormalBlend,float3(0,0,1),SurfaceHighlights),_NormalStrength);
                float3 normalLocal = Normals;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float2 Refraction = (_RefractionAmount*float2(WavePanningV_Tex.r,WavePanningU_Tex.g));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + Refraction;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float Roughness = (saturate((1.0-(1.0-WavePanningV_Tex.r)*(1.0-WavePanningU_Tex.g)))*_Glossiness);
                float gloss = 1.0 - Roughness; // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float3 specularColor = 0.0;
                float specularMonochrome;
                float depth = saturate((sceneZ-partZ)/_Depth);
                float RimAllphaMultiply = ((saturate((sceneZ-partZ)/_RimDistance)-pow(saturate((sceneZ-partZ)/_RimSize),_Rimfalloff))*_RimColor.a); // Control rim opacity with color alpha
                float node_2352 = WaveSpeed;
                fixed2 rimTiling = (Tiling*_Rimtiling);
                fixed2 rimPanningU = (rimTiling+node_2352*float2(0.5,0.1));
                float4 rimU_Tex = tex2D(_Shadermap,rimPanningU);
                fixed2 rimPanningV = (rimTiling+node_2352*float2(0,1));
                float4 rimV_Tex = tex2D(_Shadermap,rimPanningV);
                float Intersection = saturate((RimAllphaMultiply+(RimAllphaMultiply*(1.0 - (rimU_Tex.b*rimV_Tex.b))*_RimColor.a)));
                float2 node_5626 = ((Tiling*_WaveSize)+(WaveSpeed*0.5)*float2(0,1));
                float4 HeightmapTex = tex2D(_Shadermap,node_5626);
                float3 Color = saturate((lerp(lerp(_FresnelColor.rgb,lerp(lerp(_WaterColor.rgb,(_WaterColor.rgb*(1.0 - _Depthdarkness)),depth),_RimColor.rgb,Intersection),(1.0 - (pow((1.0-max(0,dot(i.normalDir, viewDirection))),_Fresnelexponent)*_FresnelColor.a))),float3(1,1,1),SurfaceHighlights)-(HeightmapTex.g*_Wavetint)));
                float3 diffuseColor = Color; // Need this for specular when using metallic
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
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_8832 = Intersection;
                float Opacity = saturate(( (_Transparency+node_8832) > 0.5 ? (1.0-(1.0-2.0*((_Transparency+node_8832)-0.5))*(1.0-depth)) : (2.0*(_Transparency+node_8832)*depth) ));
                fixed4 finalRGBA = fixed4(finalColor * Opacity,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Unlit/Transparent"
}
