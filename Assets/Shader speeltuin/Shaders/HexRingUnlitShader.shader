// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "ShaderSpeeltuin/HexRingUnlitShader"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_HexTex("Hexes (B/W)", 2D) = "black" {}
		_Color("Color", Color) = (1,1,1,1)
		_RingSize("Ring size", Range(1,5)) = 2
		_RingColor("Ring color", Color) = (1,1,1,1)
		_Falloff("Falloff", Float) = 1
	}
	SubShader
	{

		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#define PI 3.14159265359
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 projectedUVTop : TEXCOORD1;
				float2 projectedUVLeft : TEXCOORD2;
				float2 projectedUVFront : TEXCOORD3;
				float3 worldPos : TEXCOORD4;
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
			};

			sampler2D _MainTex;
			sampler2D _HexTex;
			float4 _MainTex_ST;
			float4 _HexTex_ST;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.normal = v.normal;

				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.projectedUVTop = TRANSFORM_TEX(o.worldPos.xz, _HexTex);
				o.projectedUVLeft = TRANSFORM_TEX(o.worldPos.zy, _HexTex);
				o.projectedUVFront = TRANSFORM_TEX(o.worldPos.xy, _HexTex);

				return o;
			}
			
			fixed4 _RingColor;
			fixed4 _Color;
			half _Falloff;
			half _RingSize;

			fixed4 hexWaves(fixed4 hex, half dist)
			{
				hex.r *= sin((dist - _Time.w * .6666666 * PI) / _RingSize);
				hex.g *= sin((dist - _Time.w * .6666666 * PI + .666666 * PI) / _RingSize);
				hex.b *= sin((dist - _Time.w * .6666666 * PI + 1.333333 * PI) / _RingSize);
				hex.a = 0; // heel belangrijk (!)
				return hex;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				half dist = length(i.worldPos);
				fixed4 col = (tex2D(_MainTex, i.uv) * _Color) * _Color.a;
				
				fixed4 hex = tex2D(_HexTex, i.projectedUVTop) * abs(dot(half3(0, 1, 0), i.normal));
				hex += tex2D(_HexTex, i.projectedUVLeft) * abs(dot(half3(1, 0, 0), i.normal));
				hex += tex2D(_HexTex, i.projectedUVFront) * abs(dot(half3(0, 0, 1), i.normal));
				
				hex = hexWaves(hex, dist);
				//hex.gb = half2(0, 0);
				hex *= _RingColor * _RingColor.a * _Falloff / dist;
				col += hex;
				//col = max(0, col) + hex;


				return col;

			}
			ENDCG
		}
	}
}
