
namespace Raylib_cs
{
    //----------------------------------------------------------------------------------
    // Types and Structures Definition
    //----------------------------------------------------------------------------------
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

    // Light type
    public enum LightType
    {
        LIGHT_DIRECTIONAL,
        LIGHT_POINT
    }

    public static class Rlights
    {
        //----------------------------------------------------------------------------------
        // Global Variables Definition
        //----------------------------------------------------------------------------------
        public const int MAX_LIGHTS = 4;
        public static int lightsCount = 0;    // Current amount of created lights
        public const float LIGHT_DISTANCE = 3.5f;
        public const float LIGHT_HEIGHT = 1.0f;

        //----------------------------------------------------------------------------------
        // Module Functions Definition
        //----------------------------------------------------------------------------------

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

                string enabledName = $"lights[{lightsCount}].enabled\0";
                string typeName = $"lights[{lightsCount}].type\0";
                string posName = $"lights[{lightsCount}].position\0";
                string targetName = $"lights[{lightsCount}].target\0";
                string colorName = $"lights[{lightsCount}].color\0";

                light.enabledLoc = Raylib.GetShaderLocation(shader, enabledName);
                light.typeLoc = Raylib.GetShaderLocation(shader, typeName);
                light.posLoc = Raylib.GetShaderLocation(shader, posName);
                light.targetLoc = Raylib.GetShaderLocation(shader, targetName);
                light.colorLoc = Raylib.GetShaderLocation(shader, colorName);

                UpdateLightValues(shader, light);
                lightsCount++;
            }
            return light;
        }

        public static void UpdateLightValues(Shader shader, Light light)
        {
            // Send to shader light enabled state and type
            /*Raylib.SetShaderValue(shader, light.enabledLoc, new int[] { light.enabled ? 1 : 0 }, ShaderUniformDataType.UNIFORM_INT);
            Raylib.SetShaderValue(shader, light.typeLoc, new int[] { (int)light.type }, ShaderUniformDataType.UNIFORM_INT);

            // Send to shader light position values
            float[] position = { light.position.x, light.position.y, light.position.z };
            Raylib.SetShaderValue(shader, light.posLoc, ref position, ShaderUniformDataType.UNIFORM_VEC3);

            // Send to shader light target position values
            float[] target = { light.target.x, light.target.y, light.target.z };
            Raylib.SetShaderValue(shader, light.targetLoc, ref target, ShaderUniformDataType.UNIFORM_VEC3);

            // Send to shader light color values
            float[] color = { light.color.r / 255, light.color.g / 255,
                              light.color.b / 255, light.color.a / 255 };
            Raylib.SetShaderValue(shader, light.colorLoc, ref color, ShaderUniformDataType.UNIFORM_VEC4);*/
        }
    }
}
