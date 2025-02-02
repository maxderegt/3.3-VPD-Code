﻿Shader "Custom/Ultraviolet" {
    Properties{
        /*_Color ("Main Color", Color) = (1,1,1,1)*/
      _MainTex("Texture", 2D) = "white" {}
    }
        SubShader{
        //Tags { "RenderType" = "Opaque" }
        Tags {"Queue" = "Transparent" "RenderType" = "Transparent" /*"ForceNoShadowCasting" = "True"*/}
        CGPROGRAM
        #pragma surface surf Standard alpha:fade
        struct Input {
            float2 uv_MainTex;
        };
    /*fixed4 _Color = (1,1,1,1);*/
    sampler2D _MainTex;
    void surf(Input IN, inout SurfaceOutputStandard o) {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * fixed4(1,1,1,1);
        o.Albedo = c.rgb * 30/*fixed3(1,0,0)*/;
        o.Alpha = c.a * (1 - _LightColor0.a);
    }
    ENDCG
    }
        //Fallback "Standard"
}