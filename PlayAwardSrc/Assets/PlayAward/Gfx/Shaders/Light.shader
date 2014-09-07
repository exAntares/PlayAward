// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.04346884,fgcg:0.04363439,fgcb:0.04411763,fgca:1,fgde:0.04,fgrn:4,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32656,y:32703|diff-10-OUT,emission-5-OUT,alpha-21-OUT;n:type:ShaderForge.SFN_Color,id:2,x:33624,y:32660,ptlb:Color,ptin:_Color,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:3,x:33274,y:32844,ptlb:Swicth,ptin:_Swicth,min:0,cur:1,max:1;n:type:ShaderForge.SFN_ValueProperty,id:4,x:33284,y:32936,ptlb:Light Intensity,ptin:_LightIntensity,glob:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:5,x:32990,y:32889|A-3-OUT,B-4-OUT,C-10-OUT,D-7-OUT;n:type:ShaderForge.SFN_Fresnel,id:6,x:33483,y:32995|EXP-8-OUT;n:type:ShaderForge.SFN_OneMinus,id:7,x:33284,y:32995|IN-6-OUT;n:type:ShaderForge.SFN_Slider,id:8,x:33284,y:33201,ptlb:Fresnel Intensity,ptin:_FresnelIntensity,min:1,cur:1,max:5;n:type:ShaderForge.SFN_Tex2d,id:9,x:33614,y:32467,ptlb:Base(RGB) Trans(A),ptin:_BaseRGBTransA,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:10,x:32972,y:32552|A-2-RGB,B-9-RGB;n:type:ShaderForge.SFN_Multiply,id:21,x:32990,y:32715|A-9-A,B-2-A;proporder:2-3-4-8-9;pass:END;sub:END;*/

Shader "Shader Forge/Light" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Swicth ("Swicth", Range(0, 1)) = 1
        _LightIntensity ("Light Intensity", Float ) = 2
        _FresnelIntensity ("Fresnel Intensity", Range(1, 5)) = 1
        _BaseRGBTransA ("Base(RGB) Trans(A)", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
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
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _Swicth;
            uniform float _LightIntensity;
            uniform float _FresnelIntensity;
            uniform sampler2D _BaseRGBTransA; uniform float4 _BaseRGBTransA_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
////// Emissive:
                float2 node_36 = i.uv0;
                float4 node_9 = tex2D(_BaseRGBTransA,TRANSFORM_TEX(node_36.rg, _BaseRGBTransA));
                float3 node_10 = (_Color.rgb*node_9.rgb);
                float3 emissive = (_Swicth*_LightIntensity*node_10*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelIntensity)));
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * node_10;
                finalColor += emissive;
/// Final Color:
                return fixed4(finalColor,(node_9.a*_Color.a));
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _Swicth;
            uniform float _LightIntensity;
            uniform float _FresnelIntensity;
            uniform sampler2D _BaseRGBTransA; uniform float4 _BaseRGBTransA_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float2 node_37 = i.uv0;
                float4 node_9 = tex2D(_BaseRGBTransA,TRANSFORM_TEX(node_37.rg, _BaseRGBTransA));
                float3 node_10 = (_Color.rgb*node_9.rgb);
                finalColor += diffuseLight * node_10;
/// Final Color:
                return fixed4(finalColor * (node_9.a*_Color.a),0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
