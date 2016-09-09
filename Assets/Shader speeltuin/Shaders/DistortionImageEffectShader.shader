Shader "Hidden/DistortionImageEffectShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_DistortionTex("Texture", 2D) = "black" {}
		_Weirdness ("Amount of weirdness", Range(0,.5)) = 0.0
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
				float2 uv2 : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _DistortionTex;
			float4 _MainTex_ST;
			float4 _DistortionTex_ST;
			half _Weirdness;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv, _DistortionTex);
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				float2 displacementUV = float2(i.uv2.x + (sin(sin(_Time.x * 3) * 3)), i.uv2.y - (sin(sin(_Time.x * 2) * 2.5)));
				float2 displacement = tex2D(_DistortionTex, displacementUV).xy;
				displacement = ((displacement * 2) - 1) * ( _Weirdness * (.3 * sin(_Time.x) + .7));  // displacement = ((displacement * 2) - 1) * ((.3 * sin(_Time.z + 5) + .3)); //
				fixed4 col = tex2D(_MainTex, (i.uv + displacement)); // fixed4 col = fixed4(displacement.x, displacement.y,0,0);

				//fixed4 col = tex2D(_MainTex, i.uv);
				//col += (( ((.25 * sin(_Time.w) + .25) -  tex2D(_DistortionTex, i.uv2) )) * _Weirdness); // += float4(i.uv.x,i.uv.y, (.25 * sin(_Time.w) + .25), 0);
				return col;
			}
			ENDCG
		}
	}
}
