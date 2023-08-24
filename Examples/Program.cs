using System;
using Examples.Core;
using Examples.Shapes;
using Examples.Textures;
using Examples.Text;
using Examples.Models;
using Examples.Shaders;
using Examples.Audio;

namespace Examples;

public class ExampleList
{
    public static Func<int>[] CoreExamples = new Func<int>[]
    {
        Camera2dPlatformer.Main,
        Camera2dDemo.Main,
        Camera3dFirstPerson.Main,
        Camera3dFree.Main,
        Camera3dMode.Main,
        Picking3d.Main,
        BasicScreenManager.Main,
        BasicWindow.Main,
        CustomLogging.Main,
        DropFiles.Main,
        InputGamepad.Main,
        InputGestures.Main,
        InputKeys.Main,
        InputMouseWheel.Main,
        InputMouse.Main,
        InputMultitouch.Main,
        RandomValues.Main,
        ScissorTest.Main,
        SmoothPixelPerfect.Main,
        SplitScreen.Main,
        StorageValues.Main,
        VrSimulator.Main,
        WindowFlags.Main,
        WindowLetterbox.Main,
        WorldScreen.Main,
    };

    public static Func<int>[] ShapesExamples = new Func<int>[]
    {
        BasicShapes.Main,
        BouncingBall.Main,
        CollisionArea.Main,
        ColorsPalette.Main,
        EasingsBallAnim.Main,
        EasingsBoxAnim.Main,
        EasingsRectangleArray.Main,
        FollowingEyes.Main,
        LinesBezier.Main,
        LogoRaylibAnim.Main,
        LogoRaylibShape.Main,
        RectangleScaling.Main,
    };

    public static Func<int>[] TexturesExamples = new Func<int>[]
    {
        BackgroundScrolling.Main,
        BlendModes.Main,
        Bunnymark.Main,
        DrawTiled.Main,
        ImageDrawing.Main,
        ImageGeneration.Main,
        ImageLoading.Main,
        ImageProcessing.Main,
        ImageText.Main,
        LogoRaylibTexture.Main,
        MousePainting.Main,
        NpatchDrawing.Main,
        ParticlesBlending.Main,
        TexturedCurve.Main,
        Polygon.Main,
        RawData.Main,
        SpriteAnim.Main,
        SpriteButton.Main,
        SpriteExplosion.Main,
        SrcRecDstRec.Main,
        ToImage.Main,
    };

    public static Func<int>[] TextExamples = new Func<int>[]
    {
        CodepointsLoading.Main,
        FontFilters.Main,
        FontLoading.Main,
        FontSdf.Main,
        FontSpritefont.Main,
        FormatText.Main,
        InputBox.Main,
        RaylibFonts.Main,
        RectangleBounds.Main,
        WritingAnim.Main,
    };

    public static Func<int>[] ModelsExamples = new Func<int>[]
    {
        AnimationDemo.Main,
        BillboardDemo.Main,
        BoxCollisions.Main,
        CubicmapDemo.Main,
        ModelCubeTexture.Main,
        FirstPersonMaze.Main,
        GeometricShapes.Main,
        HeightmapDemo.Main,
        ModelLoading.Main,
        MeshGeneration.Main,
        MeshPicking.Main,
        OrthographicProjection.Main,
        SolarSystem.Main,
        SkyboxDemo.Main,
        WavingCubes.Main,
        YawPitchRoll.Main,
    };

    public static Func<int>[] ShadersExamples = new Func<int>[]
    {
        BasicLighting.Main,
        CustomUniform.Main,
        Eratosthenes.Main,
        Fog.Main,
        HotReloading.Main,
        HybridRender.Main,
        JuliaSet.Main,
        ModelShader.Main,
        MultiSample2d.Main,
        PaletteSwitch.Main,
        PostProcessing.Main,
        Raymarching.Main,
        MeshInstancing.Main,
        ShapesTextures.Main,
        SimpleMask.Main,
        Spotlight.Main,
        TextureDrawing.Main,
        TextureOutline.Main,
        TextureWaves.Main,
        WriteDepth.Main,
    };

    public static Func<int>[] AudioExamples = new Func<int>[]
    {
        ModulePlaying.Main,
        MusicStreamDemo.Main,
        SoundLoading.Main,
    };
}

class Program
{
    static unsafe void Main(string[] args)
    {
        Raylib.SetTraceLogCallback(&Logging.LogConsole);
        RunExamples(ExampleList.CoreExamples);
        RunExamples(ExampleList.ShapesExamples);
        RunExamples(ExampleList.TexturesExamples);
        RunExamples(ExampleList.TextExamples);
        RunExamples(ExampleList.ModelsExamples);
        RunExamples(ExampleList.ShadersExamples);
        RunExamples(ExampleList.AudioExamples);
    }

    static void RunExamples(Func<int>[] examples)
    {
        var configFlags = Enum.GetValues(typeof(ConfigFlags));
        foreach (var example in examples)
        {
            example.Invoke();
            foreach (ConfigFlags flag in configFlags)
            {
                Raylib.ClearWindowState(flag);
            }
        }
    }
}
