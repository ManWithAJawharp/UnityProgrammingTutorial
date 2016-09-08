Shader "Hidden/ArgiaIluna/Bloom Shader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		CGINCLUDE

		sampler2D _MainTex;
		sampler2D _BaseTex;
		float2 _MainTex_TexelSize;
		float2 _BaseTex_TexelSize;

		uniform half _Threshold = 1;
		uniform half _BlurScale = 1;
		uniform half _Intensity = 1;

		float brightness(float3 color)
		{
			return max(max(color.r, color.g), color.b);
			//return (0.299 * color.r + 0.587 * color.g + 0.114 * color.b);
		}

		half4 downsampleFilter(float2 uv)
		{
			float4 d = _MainTex_TexelSize.xyxy * float4(-1, -1, +1, +1);

			half4 s;
			s = tex2D(_MainTex, uv + d.xy);
			s += tex2D(_MainTex, uv + d.zy);
			s += tex2D(_MainTex, uv + d.xw);
			s += tex2D(_MainTex, uv + d.zw);

			return 0.25 * s;
		}

		half4 upsampleFilter(float2 uv)
		{
			float4 d = _MainTex_TexelSize.xyxy * float4(1, 1, -1, 0) * _BlurScale;

			half4 s;
			s = tex2D(_MainTex, uv - d.xy);
			s += tex2D(_MainTex, uv - d.wy) * 2;
			s += tex2D(_MainTex, uv - d.zy);

			s += tex2D(_MainTex, uv + d.zw) * 2;
			s += tex2D(_MainTex, uv) * 4;
			s += tex2D(_MainTex, uv + d.xw) * 2;

			s += tex2D(_MainTex, uv + d.zy);
			s += tex2D(_MainTex, uv + d.wy) * 2;
			s += tex2D(_MainTex, uv + d.xy);

			return s * (1.0 / 16);
		}

		struct appdata
		{
			float4 vertex : POSITION;
			float2 texcoord : TEXCOORD0;
		};

		struct v2f
		{
			float4 vertex : SV_POSITION;
			float2 uv : TEXCOORD0;
		};

		struct v2f_multitex
		{
			float4 vertex : SV_POSITION;
			float2 uv_main : TEXCOORD0;
			float2 uv_base : TEXCOORD1;
		};

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			o.uv = v.texcoord;
			return o;
		}

		v2f_multitex vert_multitex(appdata v)
		{
			v2f_multitex o;
			o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			o.uv_main = v.texcoord;
			o.uv_base = v.texcoord;
			return o;
		}

		fixed4 frag_prefilter (v2f i) : SV_Target
		{
			fixed4 col = tex2D(_MainTex, i.uv);
			return step(_Threshold, brightness(col)) * col;
			//return pow(brightness(col), 2.17) * col;
		}

		fixed4 frag_downsample(v2f i) : SV_Target
		{
			return downsampleFilter(i.uv);
		}

		fixed4 frag_upsample(v2f_multitex i) : SV_Target
		{
			return upsampleFilter(i.uv_main);
		}

		fixed4 frag_final(v2f_multitex i) : SV_Target
		{
			return float4(_Intensity * tex2D(_MainTex, i.uv_main).rgb + tex2D(_BaseTex, i.uv_base).rgb, 1);
			//return float4(_Intensity * tex2D(_MainTex, i.uv_main).rgb, 1);
		}

		ENDCG

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag_prefilter
			ENDCG
		}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag_downsample
			ENDCG
		}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_multitex
			#pragma fragment frag_upsample
			ENDCG
		}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_multitex
			#pragma fragment frag_final
			ENDCG
		}
	}
}
