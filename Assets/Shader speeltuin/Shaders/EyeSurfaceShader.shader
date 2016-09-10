Shader "ShaderSpeeltuin/EyeSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_PupilColor("Pupil color", Color) = (1,1,1,1)
		_PupilSize("Pupil Size", Range(0.42,.5)) = 0.5
		_MainTex ("Eye texture", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 objPos;
		};

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.objPos = v.vertex;
		}

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _PupilColor;
		half _PupilSize;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			_PupilSize = (.035 *sin(_Time.w/2)) +.46;
			half pupilPole = clamp((IN.objPos.x- _PupilSize)*50, 0, 1);
			fixed3 tex = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 c = _Color;
			//fixed4 c = tex.g *_PupilColor *_PupilColor;
			c -= clamp((IN.objPos.x - .4) * 50,0,1);
			c += tex.g *_PupilColor;
			c -= tex.r;
			c.r += tex.r;
			c -= pupilPole;

			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic * tex.b;
			o.Smoothness = _Glossiness ;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
