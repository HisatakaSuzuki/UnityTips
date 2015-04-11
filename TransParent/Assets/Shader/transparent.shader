Shader "Custom/transparent" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MaskColor ("MaskColor", Color) = (0.0,0.0,0.0,0.0)
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;
		float4 _MaskColor;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			//a=0だと透明になる
			if(c.r == _MaskColor.r && c.g == _MaskColor.g && c.b == _MaskColor.b){
				c.a = 0.0;
			}
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
