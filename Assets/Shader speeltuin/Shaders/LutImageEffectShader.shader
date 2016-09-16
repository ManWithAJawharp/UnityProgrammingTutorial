Shader "Hidden/LutImageEffectShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_LutTex ("Lut Texture", 3D) = "" {}
		_LutSize ("Dimentions", Float) = 16
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			sampler3D _LutTex;
			float _LutSize;

			float3 offsetCords(float3 rawColor)
			{
				/*
				Add offset sugested by nvidia article
				http://http.developer.nvidia.com/GPUGems2/gpugems2_chapter24.html
				*/
				half3 lutSize = half3(_LutSize, _LutSize, _LutSize);
				half3 scale = (lutSize - 1) / lutSize;
				half3 offset = 1.0 / (2.0 * lutSize);
				return scale * rawColor + offset;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 img = tex2D(_MainTex, i.uv);
				fixed4 col = tex3D(_LutTex, offsetCords(img));

				return col;
			}
			ENDCG
		}
	}
}
