using System;

namespace Raylib_cs;

internal static unsafe class MeshExtensions
{
    /// <summary>Allocate mesh vertices</summary>
    public static void AllocVertices(ref this Mesh mesh)
    {
        mesh.Vertices = Raylib.New<float>(3 * mesh.VertexCount);
    }

    /// <summary>Allocate mesh texcoords</summary>
    public static void AllocTexcoords(ref this Mesh mesh)
    {
        mesh.TexCoords = Raylib.New<float>(2 * mesh.VertexCount);
    }

    /// <summary>Allocate mesh texcoords2</summary>
    public static void AllocTexcoords2(ref this Mesh mesh)
    {
        mesh.TexCoords2 = Raylib.New<float>(2 * mesh.VertexCount);
    }

    /// <summary>Allocate mesh normals</summary>
    public static void AllocNormals(ref this Mesh mesh)
    {
        mesh.Normals = Raylib.New<float>(3 * mesh.VertexCount);
    }

    /// <summary>Allocate mesh tangents</summary>
    public static void AllocTangents(ref this Mesh mesh)
    {
        mesh.Tangents = Raylib.New<float>(4 * mesh.VertexCount);
    }

    /// <summary>Allocate mesh colors</summary>
    public static void AllocColors(ref this Mesh mesh)
    {
        mesh.Colors = Raylib.New<byte>(4 * mesh.VertexCount);
    }

    /// <summary>Allocate mesh indices</summary>
    public static void AllocIndices(ref this Mesh mesh)
    {
        mesh.Indices = Raylib.New<ushort>(3 * mesh.TriangleCount);
    }

    /// <summary>Access mesh vertices</summary>
    public static Span<T> VerticesAs<T>(this Mesh mesh) where T : unmanaged
    {
        return new(mesh.Vertices, 3 * mesh.VertexCount * sizeof(float) / sizeof(T));
    }

    /// <summary>Access mesh texcoords</summary>
    public static Span<T> TexcoordsAs<T>(this Mesh mesh) where T : unmanaged
    {
        return new(mesh.TexCoords, 2 * mesh.VertexCount * sizeof(float) / sizeof(T));
    }

    /// <summary>Access mesh texcoords2</summary>
    public static Span<T> Texcoords2As<T>(this Mesh mesh) where T : unmanaged
    {
        return new(mesh.TexCoords2, 2 * mesh.VertexCount * sizeof(float) / sizeof(T));
    }

    /// <summary>Access mesh normals</summary>
    public static Span<T> NormalsAs<T>(this Mesh mesh) where T : unmanaged
    {
        return new(mesh.Normals, 3 * mesh.VertexCount * sizeof(float) / sizeof(T));
    }

    /// <summary>Access mesh tangents</summary>
    public static Span<T> TangentsAs<T>(this Mesh mesh) where T : unmanaged
    {
        return new(mesh.Tangents, 4 * mesh.VertexCount * sizeof(float) / sizeof(T));
    }

    /// <summary>Access mesh colors</summary>
    public static Span<T> ColorsAs<T>(this Mesh mesh) where T : unmanaged
    {
        return new(mesh.Colors, 4 * mesh.VertexCount * sizeof(byte) / sizeof(T));
    }

    /// <summary>Access mesh indices</summary>
    public static Span<T> IndicesAs<T>(this Mesh mesh) where T : unmanaged
    {
        return new(mesh.Indices, 3 * mesh.TriangleCount * sizeof(ushort) / sizeof(T));
    }
}
