Shader "Custom/MaskingShader" {
	Properties {
		_MainTex ("Main", 2D) = "white" {}
		_BackTex ("Back", 2D) = "white" {}
		_MaskTex ("Mask", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			
			//バーテックス用入力
			struct vertexInput{
				float4 vertex : POSITION;
				float2 uv     : TEXCOORD0;
			};
			
			//フラグメント用入力/バーテックス用出力
			struct fragmentInput{
				float4 position : SV_POSITION;
				float2 uv       : TEXCOORD0;
			};
			
			sampler2D _MainTex;
			sampler2D _BackTex;
			sampler2D _MaskTex;
			
			fragmentInput vert(vertexInput v){
				fragmentInput o;
				o.position = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			float4 frag(fragmentInput i) : COLOR{
				float4 maintex = tex2D(_MainTex, i.uv);
				float4 backtex = tex2D(_BackTex, i.uv);
				float4 masktex = tex2D(_MaskTex, i.uv);
				float4 output;
				
//				if(masktex.rgb > 0.5f){
//					output.rgb = maintex.rgb;
//				}else{
//					output.rgb = backtex.rgb;
//				}

				//output.rgb = maintex.rgb;
				if(masktex.r > 0.5){
					output.rgb = maintex.rgb;
				}else{
					output.rgb = backtex.rgb;
				}
				
				return float4(output.r,output.g,output.b,1.0);
			}
			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
