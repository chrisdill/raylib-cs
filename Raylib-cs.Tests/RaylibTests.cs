using System;
using Xunit;

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
            Assert.True(BlittableHelper.IsBlittable<CharInfo>());
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
            Assert.True(BlittableHelper.IsBlittable<RayHitInfo>());
            Assert.True(BlittableHelper.IsBlittable<BoundingBox>());
            Assert.True(BlittableHelper.IsBlittable<Wave>());
            Assert.True(BlittableHelper.IsBlittable<AudioStream>());
            Assert.True(BlittableHelper.IsBlittable<Sound>());
            Assert.True(BlittableHelper.IsBlittable<Music>());
            Assert.True(BlittableHelper.IsBlittable<VrDeviceInfo>());
            Assert.True(BlittableHelper.IsBlittable<VrStereoConfig>());
            Assert.True(BlittableHelper.IsBlittable<RenderBatch>());
        }
    }
}
