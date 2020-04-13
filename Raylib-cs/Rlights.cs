using System;
using static Raylib_cs.Raylib;
using static Raylib_cs.ShaderUniformDataType;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    public static class Rlights
    {
        public static int MAX_LIGHTS = 4;
        private static int lightsCount = 0;

        public static Light CreateLight(LightType type, Vector3 pos, Vector3 targ, Color color, Shader shader)
        {
            Light light = new Light();

            if (lightsCount < MAX_LIGHTS)
            {
                light.enabled = true;
                light.type = type;
                light.position = pos;
                light.target = targ;
                light.color = color;

                string enabledName = "lights[" + lightsCount + "].enabled";
                string typeName = "lights[" + lightsCount + "].type";
                string posName = "lights[" + lightsCount + "].position";
                string targetName = "lights[" + lightsCount + "].target";
                string colorName = "lights[" + lightsCount + "].color";

                light.enabledLoc = GetShaderLocation(shader, enabledName);
                light.typeLoc = GetShaderLocation(shader, typeName);
                light.posLoc = GetShaderLocation(shader, posName);
                light.targetLoc = GetShaderLocation(shader, targetName);
                light.colorLoc = GetShaderLocation(shader, colorName);

                UpdateLightValues(shader, light);

                //lights[lightsCount] = light;
                lightsCount++;
                return light;
            }

            return default;
        }

        public static void UpdateLightValues(Shader shader, Light light)
        {
            // Send to shader light enabled state and type
            IntPtr enabledPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Int32)));
            Marshal.WriteInt32(enabledPtr, light.enabled ? ((Int32)1) : ((Int32)0));
            SetShaderValue(shader, light.enabledLoc, enabledPtr, UNIFORM_INT);

            IntPtr lightPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Int32)));
            Marshal.WriteInt32(lightPtr, (Int32)light.type);
            SetShaderValue(shader, light.typeLoc, lightPtr, UNIFORM_INT);

            // Send to shader light position values
            float[] position = new[] { light.position.x, light.position.y, light.position.z };

            // Send to shader light target position values
            float[] target = new[] { light.target.x, light.target.y, light.target.z };
            IntPtr targetPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * target.Length);
            Marshal.Copy(target, 0, targetPtr, target.Length);
            SetShaderValue(shader, light.targetLoc, targetPtr, UNIFORM_VEC3);

            // Send to shader light color values
            float[] diff = new[] { (float)light.color.r / (float)255, (float)light.color.g / (float)255, (float)light.color.b / (float)255, (float)light.color.a / (float)255 };
            IntPtr diffPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * diff.Length);
            Marshal.Copy(diff, 0, diffPtr, diff.Length);
            SetShaderValue(shader, light.colorLoc, diffPtr, UNIFORM_VEC4);
        }
    }

    public enum LightType
    {
        LIGHT_DIRECTIONAL,
        LIGHT_POINT
    }

    public struct Light
    {
        public bool enabled;
        public LightType type;
        public Vector3 position;
        public Vector3 target;
        public Color color;
        public int enabledLoc;
        public int typeLoc;
        public int posLoc;
        public int targetLoc;
        public int colorLoc;
    }
}