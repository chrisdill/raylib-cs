/* Physac.cs
*
* Copyright 2019 Chris Dill
*
* Release under zLib License.
* See LICENSE for details.
*/

using System;
using System.Runtime.InteropServices;

namespace Raylib
{
    public enum PhysicsShapeType
    {
        PHYSICS_CIRCLE,
        PHYSICS_POLYGON
    }

    // Mat2 type (used for polygon shape rotation matrix)
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Mat2
    {
        public float m00;
        public float m01;
        public float m10;
        public float m11;
    }

    // @TODO Custom array marshall issue https://github.com/ChrisDill/Raylib-cs/issues/9
    // Hack same as raylib.cs _MaterialMap_e_FixedBuffer
    // No easy way to marshall arrays of custom types. no idea why?
    public unsafe struct _Polygon_e_FixedBuffer
    {
        public Vector2 v0;
        public Vector2 v1;
        public Vector2 v2;
        public Vector2 v3;
        public Vector2 v4;
        public Vector2 v5;
        public Vector2 v6;
        public Vector2 v7;
        public Vector2 v8;
        public Vector2 v9;
        public Vector2 v10;
        public Vector2 v11;
        public Vector2 v12;
        public Vector2 v13;
        public Vector2 v14;
        public Vector2 v15;
        public Vector2 v16;
        public Vector2 v17;
        public Vector2 v18;
        public Vector2 v19;
        public Vector2 v20;
        public Vector2 v21;
        public Vector2 v22;
        public Vector2 v23;
        public Vector2 v24;

        public Vector2 this[int index]
        {
            get
            {
                fixed (Vector2* e = &v0)
                    return e[index];
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PolygonData
    {
        public uint vertexCount;                           // Current used vertex and normals count       
        public _Polygon_e_FixedBuffer positions;           // Polygon vertex positions vectors
        public _Polygon_e_FixedBuffer normals;             // Polygon vertex normals vectors
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PhysicsShape
    {
        public PhysicsShapeType type;                      // Physics shape type (circle or polygon)  
        public IntPtr body;                                // Shape physics body reference      
        public float radius;                               // Circle shape radius (used for circle shapes)      
        public Mat2 transform;                             // Vertices transform matrix 2x2     
        public PolygonData vertexData;                     // Polygon shape vertices position and normals data (just used for polygon shapes)
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public partial struct PhysicsBodyData
    {
        public uint id;
        [MarshalAs(UnmanagedType.Bool)]
        public bool enabled;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 force;
        public float angularVelocity;
        public float torque;
        public float orient;
        public float inertia;
        public float inverseInertia;
        public float mass;
        public float inverseMass;
        public float staticFriction;
        public float dynamicFriction;
        public float restitution;
        [MarshalAs(UnmanagedType.Bool)]
        public bool useGravity;
        [MarshalAs(UnmanagedType.Bool)]
        public bool isGrounded;
        [MarshalAs(UnmanagedType.Bool)]
        public bool freezeOrient;
        public PhysicsShape shape;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PhysicsManifoldData
    {
        public uint id;                                    // Reference unique identifier  
        public IntPtr bodyA;                               // Manifold first physics body reference   
        public IntPtr bodyB;                               // Manifold second physics body reference
        public float penetration;                          // Depth of penetration from collision
        public Vector2 normal;                             // Normal direction vector from 'a' to 'b'
        public Vector2 contactsA;                          // Points of contact during collision
        public Vector2 contactsB;                          // Points of contact during collision
        public uint contactsCount;                         // Current collision number of contacts
        public float restitution;                          // Mixed restitution during collision
        public float dynamicFriction;                      // Mixed dynamic friction during collision
        public float staticFriction;                       // Mixed static friction during collision
    }

    public static partial class Raylib
    {
        // Initializes physics values, pointers and creates physics loop thread
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitPhysics();

        // Run physics step, to be used if PHYSICS_NO_THREADS is set in your main loop
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunPhysicsStep();

        // Returns true if physics thread is currently enabled
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsPhysicsEnabled();

        // Sets physics global gravity force
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPhysicsGravity(float x, float y);

        // Creates a new circle physics body with generic parameters
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreatePhysicsBodyCircle(Vector2 pos, float radius, float density);

        // Creates a new rectangle physics body with generic parameters
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreatePhysicsBodyRectangle(Vector2 pos, float width, float height, float density);

        // Creates a new polygon physics body with generic parameters
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreatePhysicsBodyPolygon(Vector2 pos, float radius, int sides, float density);

        // Adds a force to a physics body
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhysicsAddForce(PhysicsBodyData body, Vector2 force);

        // Adds an angular force to a physics body
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhysicsAddTorque(PhysicsBodyData body, float amount);

        // Shatters a polygon shape physics body to little physics bodies with explosion force
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhysicsShatter(PhysicsBodyData body, Vector2 position, float force);

        // Returns the current amount of created physics bodies
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPhysicsBodiesCount();

        // Returns a physics body of the bodies pool at a specific index
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetPhysicsBodyImport(int index);

        // Returns the physics body shape type (PHYSICS_CIRCLE or PHYSICS_POLYGON)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPhysicsShapeType(int index);

        // Returns the amount of vertices of a physics body shape
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPhysicsShapeVerticesCount(int index);

        // Returns transformed position of a body shape (body position + vertex transformed position)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetPhysicsShapeVertex(PhysicsBodyData body, int vertex);

        // Sets physics body shape transform based on radians parameter
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPhysicsBodyRotation(PhysicsBodyData body, float radians);

        // Unitializes and destroy a physics body
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyPhysicsBody(PhysicsBodyData body);

        // Destroys created physics bodies and manifolds and resets global values
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResetPhysics();

        // Unitializes physics pointers and closes physics loop thread
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClosePhysics();
    }
}
