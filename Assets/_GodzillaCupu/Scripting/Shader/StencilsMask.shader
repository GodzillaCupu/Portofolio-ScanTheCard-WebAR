Shader "IndonesianTradingCard/StencilsMask"
{
    Properties
    {
        [intRange(0, 1)] _StencilRef("Stencil Ref", Range(0,255)) = 1
    }
    SubShader
    {
        Tags 
        { 
            "RenderType"="Opaque" 
            "Queue"="Geometry"
            "RenderPipeline"="UniversalPipeline"
        }
        Pass
        {
            Stencil
            {
                Ref [_StencilRef]
                Comp Always
                Pass Replace
                Fail Keep
            }
            ZWrite Off
            ColorMask 0
            Tags
            {
                "lightMode" = "UniversalForward"
            }
        }
    }
    FallBack "Off"
}
