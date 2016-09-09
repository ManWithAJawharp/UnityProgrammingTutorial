// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "ShaderSpeeltuin/HexRingUnlitShader"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_HexTex("Hexes (B/W)", 2D) = "black" {}
		_Color("Color", Color) = (1,1,1,1)
		_RingColor("Ring color", Color) = (1,1,1,1)
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

			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
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
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv, _HexTex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

				return o;
			}
			
			fixed4 _RingColor;
			fixed4 _Color;

			fixed4 frag (v2f i) : SV_Target
			{
				half dist = length(i.worldPos);
				fixed4 col = (tex2D(_MainTex, i.uv) * _Color) * _Color.a;
				fixed4 hex = ((tex2D(_HexTex, i.uv2) * _RingColor) * 0.5*(1 + sin(_Time.w + dist))) * _RingColor.a;
				// col = fixed4(i.worldPos.x, i.worldPos.y, i.worldPos.z, 0);
				
				col -= hex;
				col = max(0, col) + hex;
				return col;
			}
			ENDCG
		}
	}
}
