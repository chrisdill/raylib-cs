/**********************************************************************************************
 * 
 * Physac
 * Original -https://github.com/raysan5/raylib/blob/master/src/physac.h
 * 
**********************************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace Raylib
{
    #region Raylib-cs Enums

    public enum PhysicsShapeType
    {
        PHYSICS_CIRCLE,
        PHYSICS_POLYGON
    }

    #endregion

    #region Raylib-cs Types

    // Mat2 type (used for polygon shape rotation matrix)
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Mat2
    {
        public float m00;
        public float m01;
        public float m10;
        public float m11;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PolygonData
    {
        public uint vertexCount;                           // Current used vertex and normals count

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = Raylib.PHYSAC_MAX_VERTICES)]
        public Vector2[] positions;     // Polygon vertex positions vectors
	    
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = Raylib.PHYSAC_MAX_VERTICES)]
        public Vector2[] normals;       // Polygon vertex normals vectors
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PhysicsShape
    {
        public PhysicsShapeType type;                      // Physics shape type (circle or polygon)
        public IntPtr body;                       // Shape physics body reference
        public float radius;                               // Circle shape radius (used for circle shapes)
        public Mat2 transform;                             // Vertices transform matrix 2x2
        public PolygonData vertexData;                     // Polygon shape vertices position and normals data (just used for polygon shapes)
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PhysicsBodyData
    {
        public uint id;                                    // Reference unique identifier
        public bool enabled;                               // Enabled dynamics state (collisions are calculated anyway)
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
        public bool useGravity;                            // Apply gravity force to dynamics
        public bool isGrounded;                            // Physics grounded on other body state
        public bool freezeOrient;                          // Physics rotation constraint
        public PhysicsShape shape;                         // Physics body shape information (type, radius, vertices, normals)
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PhysicsManifoldData
    {
        public uint id;                            // Reference unique identifier
        public PhysicsBodyData bodyA;                          // Manifold first physics body reference
        public PhysicsBodyData bodyB;                          // Manifold second physics body reference
        public float penetration;                          // Depth of penetration from collision
        public Vector2 normal;                             // Normal direction vector from 'a' to 'b'
	    
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 2)]
        public Vector2[] contacts;                        // Points of contact during collision
       
        public uint contactsCount;                 // Current collision number of contacts
        public float restitution;                          // Mixed restitution during collision
        public float dynamicFriction;                      // Mixed dynamic friction during collision
        public float staticFriction;                       // Mixed static friction during collision
    }

    #endregion

    public static partial class Raylib
    {
        #region Raylib-cs Variables

        // Used by DllImport to load the native library.
        // private const string nativeLibName = "raylib.dll";
        public const int PHYSAC_MAX_BODIES = 64;
        public const int PHYSAC_MAX_MANIFOLDS = 4096;
        public const int PHYSAC_MAX_VERTICES = 24;
        public const int PHYSAC_CIRCLE_VERTICES = 24;

        public const float PHYSAC_DESIRED_DELTATIME = 1.0f / 60.0f;
        public const float PHYSAC_MAX_TIMESTEP = 0.02f;
        public const int PHYSAC_COLLISION_ITERATIONS = 100;
        public const float PHYSAC_PENETRATION_ALLOWANCE = 0.05f;
        public const float PHYSAC_PENETRATION_CORRECTION = 0.4f;

        public const float PHYSAC_PI = 3.14159265358979323846f;
        public const float PHYSAC_DEG2RAD = (PHYSAC_PI / 180.0f);

        #endregion

        #region Raylib-cs Functions 

        // Initializes physics values, pointers and creates physics loop thread
        [DllImport(nativeLibName)]
        public static extern void InitPhysics();                                                                          

        // Returns true if physics thread is currently enabled
        [DllImport(nativeLibName)]
        public static extern bool IsPhysicsEnabled();                                                                      

        // Sets physics global gravity force
        [DllImport(nativeLibName)]
        public static extern void SetPhysicsGravity(float x, float y);                                                         

        // Creates a new circle physics body with generic parameters
        [DllImport(nativeLibName)]
        public static extern PhysicsBodyData CreatePhysicsBodyCircle(Vector2 pos, float radius, float density);                    

        // Creates a new rectangle physics body with generic parameters
        [DllImport(nativeLibName)]
        public static extern PhysicsBodyData CreatePhysicsBodyRectangle(Vector2 pos, float width, float height, float density);    

        // Creates a new polygon physics body with generic parameters
        [DllImport(nativeLibName)]
        public static extern PhysicsBodyData CreatePhysicsBodyPolygon(Vector2 pos, float radius, int sides, float density);        

        // Adds a force to a physics body
        [DllImport(nativeLibName)]
        public static extern void PhysicsAddForce(PhysicsBodyData body, Vector2 force);                                            

        // Adds an angular force to a physics body
        [DllImport(nativeLibName)]
        public static extern void PhysicsAddTorque(PhysicsBodyData body, float amount);                                            
        
        // Shatters a polygon shape physics body to little physics bodies with explosion force
        [DllImport(nativeLibName)]
        public static extern void PhysicsShatter(PhysicsBodyData body, Vector2 position, float force);                             

        // Returns the current amount of created physics bodies
        [DllImport(nativeLibName)]
        public static extern int GetPhysicsBodiesCount();                                                                  

        // Returns a physics body of the bodies pool at a specific index
        [DllImport(nativeLibName)]
        public static extern IntPtr GetPhysicsBody(int index);                                                            
	    
        // Returns the physics body shape type (PHYSICS_CIRCLE or PHYSICS_POLYGON)
        [DllImport(nativeLibName)]
        public static extern int GetPhysicsShapeType(int index);                                                             

        // Returns the amount of vertices of a physics body shape
        [DllImport(nativeLibName)]
        public static extern int GetPhysicsShapeVerticesCount(int index);                                                      

        // Returns transformed position of a body shape (body position + vertex transformed position)
        [DllImport(nativeLibName)]
        public static extern Vector2 GetPhysicsShapeVertex(PhysicsBodyData body, int vertex);                                      

        // Sets physics body shape transform based on radians parameter
        [DllImport(nativeLibName)]
        public static extern void SetPhysicsBodyRotation(PhysicsBodyData body, float radians);                                     

        // Unitializes and destroy a physics body
        [DllImport(nativeLibName)]
        public static extern void DestroyPhysicsBody(PhysicsBodyData body);                                                        

        // Destroys created physics bodies and manifolds and resets global values
        [DllImport(nativeLibName)]
        public static extern void ResetPhysics();                                                                        

        // Unitializes physics pointers and closes physics loop thread
        [DllImport(nativeLibName)]
        public static extern void ClosePhysics();                                                                      

        #endregion

    }
}
