﻿Shader "ShaderSpeeltuin/SurfaceShaderWithRimlight" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_FresnellColor ("Rimlight color", Color) = (0,0,0,0)
		_FresnellPower ("Rimlight strength", Range(0,10)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldRefl;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _FresnellColor;
		half _FresnellPower;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;

			half fresnell = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = (_FresnellColor.rgb * pow(fresnell, _FresnellPower)) * (_FresnellColor.a * (.3* sin(_Time.w) + .7));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
