Shader "Hidden/LutImageEffectShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_LutTex ("Lut Texture", 3D) = "" {}
		_LutDebug ("Debug vector 3", Color) = (0,0,0,0)
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
			float4 _LutDebug;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 cor = tex2D(_MainTex, i.uv + half2(0.5,0));
				fixed4 img = tex2D(_MainTex, i.uv - half2(0.5,0));
				//fixed4 col = tex3D(_LutTex, _LutDebug);//- float3(.2,.2,.2));

				fixed4 col = tex3D(_LutTex, img);
				//col.rgb = img.rgb;
				col.a = 0;
				//col.rgb -= cor.rgb;
				col.rgb += cor.rgb;
				return col;
			}
			ENDCG
		}
	}
}
