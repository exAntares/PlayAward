// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-16-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33771,y:32453,ptlb:Floor Tex,ptin:_FloorTex,tex:e9b2b3ea215e8a1478001eec6d80ed27,ntxv:0,isnm:False|UVIN-44-OUT;n:type:ShaderForge.SFN_Tex2d,id:3,x:33771,y:32643,ptlb:Wall Tex,ptin:_WallTex,tex:84d32aa2e69351a4e8f4a6bfdfab1fff,ntxv:2,isnm:False|UVIN-44-OUT;n:type:ShaderForge.SFN_Vector3,id:11,x:34811,y:33225,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Dot,id:12,x:34632,y:33281,dt:0|A-11-OUT,B-13-OUT;n:type:ShaderForge.SFN_NormalVector,id:13,x:34811,y:33343,pt:False;n:type:ShaderForge.SFN_Relay,id:16,x:33173,y:32650|IN-17-OUT;n:type:ShaderForge.SFN_Lerp,id:17,x:33332,y:32639|A-3-RGB,B-2-RGB,T-12-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:27,x:34769,y:32494;n:type:ShaderForge.SFN_Append,id:30,x:34586,y:32667,cmnt:ZY|A-27-Z,B-27-Y;n:type:ShaderForge.SFN_Append,id:31,x:34586,y:32811,cmnt:XY|A-27-X,B-27-Y;n:type:ShaderForge.SFN_Lerp,id:39,x:34313,y:32727|A-30-OUT,B-31-OUT,T-41-OUT;n:type:ShaderForge.SFN_Dot,id:41,x:34586,y:32994,dt:0|A-43-OUT,B-42-OUT;n:type:ShaderForge.SFN_NormalVector,id:42,x:34802,y:33066,pt:False;n:type:ShaderForge.SFN_Vector3,id:43,x:34802,y:32974,v1:1,v2:0,v3:0;n:type:ShaderForge.SFN_Lerp,id:44,x:34044,y:32683|A-56-OUT,B-46-OUT,T-12-OUT;n:type:ShaderForge.SFN_Append,id:45,x:34313,y:32580,cmnt:XZ|A-27-Z,B-27-X;n:type:ShaderForge.SFN_Multiply,id:46,x:34313,y:32408|A-49-OUT,B-45-OUT;n:type:ShaderForge.SFN_ValueProperty,id:47,x:34762,y:32273,ptlb:Floor U tiling,ptin:_FloorUtiling,glob:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:48,x:34762,y:32355,ptlb:Floor V Tiling,ptin:_FloorVTiling,glob:False,v1:1;n:type:ShaderForge.SFN_Append,id:49,x:34594,y:32311|A-47-OUT,B-48-OUT;n:type:ShaderForge.SFN_Append,id:51,x:35165,y:32705|A-55-OUT,B-53-OUT;n:type:ShaderForge.SFN_ValueProperty,id:53,x:35333,y:32749,ptlb:Wall V Tiling_copy,ptin:_WallVTiling_copy,glob:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:55,x:35333,y:32667,ptlb:Wall U tiling_copy,ptin:_WallUtiling_copy,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:56,x:34167,y:32863|A-39-OUT,B-51-OUT;proporder:55-53-3-47-48-2;pass:END;sub:END;*/

Shader "Shader Forge/EnvironmentWorldUV" {
    Properties {
        _WallUtiling_copy ("Wall U tiling_copy", Float ) = 1
        _WallVTiling_copy ("Wall V Tiling_copy", Float ) = 1
        _WallTex ("Wall Tex", 2D) = "black" {}
        _FloorUtiling ("Floor U tiling", Float ) = 1
        _FloorVTiling ("Floor V Tiling", Float ) = 1
        _FloorTex ("Floor Tex", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _FloorTex; uniform float4 _FloorTex_ST;
            uniform sampler2D _WallTex; uniform float4 _WallTex_ST;
            uniform float _FloorUtiling;
            uniform float _FloorVTiling;
            uniform float _WallVTiling_copy;
            uniform float _WallUtiling_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float4 node_27 = i.posWorld;
                float node_12 = dot(float3(0,1,0),i.normalDir);
                float2 node_44 = lerp((lerp(float2(node_27.b,node_27.g),float2(node_27.r,node_27.g),dot(float3(1,0,0),i.normalDir))*float2(_WallUtiling_copy,_WallVTiling_copy)),(float2(_FloorUtiling,_FloorVTiling)*float2(node_27.b,node_27.r)),node_12);
                finalColor += diffuseLight * lerp(tex2D(_WallTex,TRANSFORM_TEX(node_44, _WallTex)).rgb,tex2D(_FloorTex,TRANSFORM_TEX(node_44, _FloorTex)).rgb,node_12);
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _FloorTex; uniform float4 _FloorTex_ST;
            uniform sampler2D _WallTex; uniform float4 _WallTex_ST;
            uniform float _FloorUtiling;
            uniform float _FloorVTiling;
            uniform float _WallVTiling_copy;
            uniform float _WallUtiling_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
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
                float4 node_27 = i.posWorld;
                float node_12 = dot(float3(0,1,0),i.normalDir);
                float2 node_44 = lerp((lerp(float2(node_27.b,node_27.g),float2(node_27.r,node_27.g),dot(float3(1,0,0),i.normalDir))*float2(_WallUtiling_copy,_WallVTiling_copy)),(float2(_FloorUtiling,_FloorVTiling)*float2(node_27.b,node_27.r)),node_12);
                finalColor += diffuseLight * lerp(tex2D(_WallTex,TRANSFORM_TEX(node_44, _WallTex)).rgb,tex2D(_FloorTex,TRANSFORM_TEX(node_44, _FloorTex)).rgb,node_12);
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
