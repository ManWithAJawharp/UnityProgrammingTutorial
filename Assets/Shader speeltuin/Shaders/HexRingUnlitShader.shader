Shader "ShaderSpeeltuin/HexRingUnlitShader"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_HexTex("Hexes (B/W)", 2D) = "black" {}
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
				float2 screenuv : TECCOORD2;
				float3 viewDir : TEXCOORD3;
				float3 objectPos : TEXCOORD4;
				float4 vertex : SV_POSITION;
				float depth : DEPTH;
				float3 normal : NORMAL;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				o.screenuv = ((o.vertex.xy / o.vertex.w) + 1) / 2;
				o.screenuv.y = 1 - o.screenuv.y;
				o.depth - mul(UNITY_MATRIX_MV, v.vertex).z * _ProjectionParams.w;

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);

				return col;
			}
			ENDCG
		}
	}
}
