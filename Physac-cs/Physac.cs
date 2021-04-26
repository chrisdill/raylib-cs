using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;
using Raylib_cs;

namespace Physac_cs
{
    public enum PhysicsShapeType
    {
        PHYSICS_CIRCLE,
        PHYSICS_POLYGON
    }

    // Matrix2x2 type (used for polygon shape rotation matrix)
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix2x2
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

    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicsVertexData
    {
        public uint vertexCount;                           // Vertex count (positions and normals)
        public _Polygon_e_FixedBuffer positions;           // Vertex positions vectors
        public _Polygon_e_FixedBuffer normals;             // Vertex normals vectors
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicsShape
    {
        public PhysicsShapeType type;                      // Shape type (circle or polygon)
        public IntPtr body;                                // Shape physics body reference
        public PhysicsVertexData vertexData;               // Shape vertices data (used for polygon shapes)
        public float radius;                               // Shape radius (used for circle shapes)
        public Matrix2x2 transform;                        // Vertices transform matrix 2x2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicsBodyData
    {
        public uint id;                                    // Unique identifier
        public byte enabled;                               // Enabled dynamics state (collisions are calculated anyway)
        public Vector2 position;                           // Physics body shape pivot
        public Vector2 velocity;                           // Current linear velocity applied to position
        public Vector2 force;                              // Current linear force (reset to 0 every step)
        public float angularVelocity;                      // Current angular velocity applied to orient
        public float torque;                               // Current angular force (reset to 0 every step)
        public float orient;                               // Rotation in radians
        public float inertia;                              // Moment of inertia
        public float inverseInertia;                       // Inverse value of inertia
        public float mass;                                 // Physics body mass
        public float inverseMass;                          // Inverse value of mass
        public float staticFriction;                       // Friction when the body has not movement (0 to 1)
        public float dynamicFriction;                      // Friction when the body has movement (0 to 1)
        public float restitution;                          // Restitution coefficient of the body (0 to 1)
        public byte useGravity;                            // Apply gravity force to dynamics
        public byte isGrounded;                            // Physics grounded on other body state
        public byte freezeOrient;                          // Physics rotation constraint
        public PhysicsShape shape;                         // Physics body shape information (type, radius, vertices, transform)
    }

    [StructLayout(LayoutKind.Sequential)]
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

    [SuppressUnmanagedCodeSecurity]
    public static class Physac
    {
        // Used by DllImport to load the native library.
        public const string nativeLibName = "physac";

        public const int PHYSAC_MAX_BODIES = 64;
        public const int PHYSAC_MAX_MANIFOLDS = 4096;
        public const int PHYSAC_MAX_VERTICES = 24;
        public const int PHYSAC_CIRCLE_VERTICES = 24;

        public const int PHYSAC_COLLISION_ITERATIONS = 100;
        public const float PHYSAC_PENETRATION_ALLOWANCE = 0.05f;
        public const float PHYSAC_PENETRATION_CORRECTION = 0.4f;

        // Physics system management

        // Initializes physics values, pointers and creates physics loop thread
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitPhysics();

        // Update physics system
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdatePhysics();

        // Reset physics system (global variables)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResetPhysics();

        // Close physics system and unload used memory
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClosePhysics();

        // Sets physics fixed time step in milliseconds. 1.666666 by default
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPhysicsTimeStep(double delta);

        // Sets physics global gravity force
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPhysicsGravity(float x, float y);


        // Physic body creation/destroy

        // Creates a new circle physics body with generic parameters
        // IntPtr refers to a PhysicsBodyData *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreatePhysicsBodyCircle(Vector2 pos, float radius, float density);

        // Creates a new rectangle physics body with generic parameters
        // IntPtr refers to a PhysicsBodyData *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreatePhysicsBodyRectangle(Vector2 pos, float width, float height, float density);

        // Creates a new polygon physics body with generic parameters
        // IntPtr refers to a PhysicsBodyData *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreatePhysicsBodyPolygon(Vector2 pos, float radius, int sides, float density);

        // Destroy a physics body
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyPhysicsBody(PhysicsBodyData body);


        // Physic body forces

        // Adds a force to a physics body
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhysicsAddForce(PhysicsBodyData body, Vector2 force);

        // Adds an angular force to a physics body
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhysicsAddTorque(PhysicsBodyData body, float amount);

        // Shatters a polygon shape physics body to little physics bodies with explosion force
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PhysicsShatter(PhysicsBodyData body, Vector2 position, float force);

        // Sets physics body shape transform based on radians parameter
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPhysicsBodyRotation(PhysicsBodyData body, float radians);


        // Query physics info

        // Returns a physics body of the bodies pool at a specific index
        // IntPtr refers to a PhysicsBodyData *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetPhysicsBody(int index);

        // Returns the current amount of created physics bodies
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPhysicsBodiesCount();

        // Returns the physics body shape type (PHYSICS_CIRCLE or PHYSICS_POLYGON)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPhysicsShapeType(int index);

        // Returns the amount of vertices of a physics body shape
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPhysicsShapeVerticesCount(int index);

        // Returns transformed position of a body shape (body position + vertex transformed position)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetPhysicsShapeVertex(PhysicsBodyData body, int vertex);
    }
}
