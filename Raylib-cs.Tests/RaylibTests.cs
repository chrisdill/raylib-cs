using System;
using Xunit;
using Raylib_cs;

namespace Raylib_cs.Tests
{
    public class RaylibTests
    {
        // Test if binding structs are blittable.
        [Fact]
        public void IsBlittable()
        {
            Assert.True(BlittableHelper.IsBlittable<Color>());
            Assert.True(BlittableHelper.IsBlittable<Rectangle>());
            Assert.True(BlittableHelper.IsBlittable<Image>());
            Assert.True(BlittableHelper.IsBlittable<Texture2D>());
            Assert.True(BlittableHelper.IsBlittable<RenderTexture2D>());
            Assert.True(BlittableHelper.IsBlittable<NPatchInfo>());
            Assert.True(BlittableHelper.IsBlittable<GlyphInfo>());
            Assert.True(BlittableHelper.IsBlittable<Font>());
            Assert.True(BlittableHelper.IsBlittable<Camera3D>());
            Assert.True(BlittableHelper.IsBlittable<Camera2D>());
            Assert.True(BlittableHelper.IsBlittable<Mesh>());
            Assert.True(BlittableHelper.IsBlittable<Shader>());
            Assert.True(BlittableHelper.IsBlittable<MaterialMap>());
            Assert.True(BlittableHelper.IsBlittable<Material>());
            Assert.True(BlittableHelper.IsBlittable<Transform>());
            Assert.True(BlittableHelper.IsBlittable<BoneInfo>());
            Assert.True(BlittableHelper.IsBlittable<Model>());
            Assert.True(BlittableHelper.IsBlittable<Model>());
            Assert.True(BlittableHelper.IsBlittable<ModelAnimation>());
            Assert.True(BlittableHelper.IsBlittable<Ray>());
            Assert.True(BlittableHelper.IsBlittable<RayCollision>());
            Assert.True(BlittableHelper.IsBlittable<BoundingBox>());
            Assert.True(BlittableHelper.IsBlittable<Wave>());
            Assert.True(BlittableHelper.IsBlittable<AudioStream>());
            Assert.True(BlittableHelper.IsBlittable<Sound>());
            Assert.True(BlittableHelper.IsBlittable<Music>());
            Assert.True(BlittableHelper.IsBlittable<VrDeviceInfo>());
            Assert.True(BlittableHelper.IsBlittable<VrStereoConfig>());
            Assert.True(BlittableHelper.IsBlittable<RenderBatch>());
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
                Assert.Equal(codepoints1[i], input[i]);
            }
        }

        [Fact]
        public void CodepointToUTF8()
        {
            int byteSize = 0;
            string text = Raylib.CodepointToUTF8(224, ref byteSize).ToString();
            Assert.Equal(text, "à");
        }

        [Fact]
        public void TextCodepointsToUTF8()
        {
            string input = "aàáâãäāăąȧXǎȁȃeèéêẽëē";
            
            int count = 0;
            int[] codepoints1 = Raylib.LoadCodepoints(input, ref count);

            string text = Raylib.TextCodepointsToUTF8(codepoints1, codepoints1.Length).ToString();
            Assert.Equal(text, input);
        }
    }
}
