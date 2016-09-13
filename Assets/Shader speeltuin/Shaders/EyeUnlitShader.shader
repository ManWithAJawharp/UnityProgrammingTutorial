﻿Shader "ShaderSpeeltuin/EyeUnlitShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_IrisColor("Iris color", Color) = (1,1,1,1)
		_PupilSize("Pupil Size", Range(0.42,.495)) = 0.5
		_MainTex("Eye texture", 2D) = "white" {}
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
				//float3 objPos : TEXCOORD1;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _Color;
			fixed4 _IrisColor;
			half _PupilSize;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				//o.objPos = v.vertex;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				half pupilPole = clamp((i.vertex.x - _PupilSize) * 50, 0, 1);
				fixed3 tex = tex2D(_MainTex, i.uv);
				fixed4 col = _Color;
				//fixed4 c = tex.g *_PupilColor *_PupilColor;
				//col -= clamp((i.objPos.x - .4) * 50, 0, 1);
				//col += tex.g *_IrisColor;
				//col -= tex.r;
				//col.r += tex.r;
				col = i.vertex;
				return col;
			}
			ENDCG
		}
	}
}
