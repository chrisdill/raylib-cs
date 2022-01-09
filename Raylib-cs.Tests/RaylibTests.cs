using System;
using Xunit;
using Raylib_cs;

namespace Raylib_cs.Tests
{
    public class RaylibTests
    {
        private unsafe void CheckType<T>() where T : unmanaged
        {
            Assert.True(BlittableHelper.IsBlittable<T>());
        }

        [Fact]
        public void CheckTypes()
        {
            CheckType<Color>();
            CheckType<Rectangle>();
            CheckType<Image>();
            CheckType<Texture2D>();
            CheckType<RenderTexture2D>();
            CheckType<NPatchInfo>();
            CheckType<GlyphInfo>();
            CheckType<Font>();
            CheckType<Camera2D>();
            CheckType<Camera3D>();
            CheckType<Mesh>();
            CheckType<Shader>();
            CheckType<MaterialMap>();
            CheckType<Material>();
            CheckType<Transform>();
            CheckType<BoneInfo>();
            CheckType<Model>();
            CheckType<ModelAnimation>();
            CheckType<Ray>();
            CheckType<RayCollision>();
            CheckType<BoundingBox>();
            CheckType<Wave>();
            CheckType<AudioStream>();
            CheckType<Sound>();
            CheckType<Music>();
            CheckType<VrDeviceInfo>();
            CheckType<VrStereoConfig>();
            CheckType<RenderBatch>();
        }

        [Fact]
        public void TextToInteger()
        {
            int value = Raylib.TextToInteger("99999");
            Assert.Equal(99999, value);
        }

        [Fact]
        public void TextToPascal()
        {
            string input = "hello_world";
            string text = Raylib.TextToPascal(input).ToString();
            Assert.Equal("HelloWorld", text);
        }

        [Fact]
        public void LoadCodepoints()
        {
            int count = 0;
            string input = "aàáâãäāăąȧXǎȁȃeèéêẽëē";
            int[] codepoints1 = Raylib.LoadCodepoints(input, ref count);

            for (int i = 0; i < input.Length; i++)
            {
                Assert.Equal(input[i], codepoints1[i]);
            }
        }

        [Fact]
        public void CodepointToUTF8()
        {
            int byteSize = 0;
            string text = Raylib.CodepointToUTF8(224, ref byteSize).ToString();
            Assert.Equal("à", text);
        }

        [Fact]
        public void TextCodepointsToUTF8()
        {
            string input = "aàáâãäāăąȧXǎȁȃeèéêẽëē";

            int count = 0;
            int[] codepoints1 = Raylib.LoadCodepoints(input, ref count);

            string text = Raylib.TextCodepointsToUTF8(codepoints1, codepoints1.Length).ToString();
            Assert.Equal(input, text);
        }
    }
}
