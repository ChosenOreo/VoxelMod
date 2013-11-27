using OpenTK;
using SGE.Event;

namespace SGE.Entity {
    public interface IRotatable : IPlaceable, IUpdateable {
        #region Methods
        /// <summary>
        /// Offsets the target rotation point of the entity to a set of yaw, pitch, and roll
        /// values. The rotation itself occurs in the Update method. 
        /// </summary>
        /// <param name="yaw">The angle in degrees to rotate around the Y axis.</param>
        /// <param name="pitch">The angle in degrees to rotate around the X axis.</param>
        /// <param name="roll">The angle in degrees to rotate around the Z axis.</param>
        void Rotate(float yaw, float pitch, float roll);

        /// <summary>
        /// Offsets the target and current rotation points of the entity to a set of yaw, pitch,
        /// and roll values. The rotation itself occurs in the Update method. 
        /// </summary>
        /// <param name="yaw">The angle in degrees to rotate around the Y axis.</param>
        /// <param name="pitch">The angle in degrees to rotate around the X axis.</param>
        /// <param name="roll">The angle in degrees to rotate around the Z axis.</param>
        void RotateImmediate(float yaw, float pitch, float roll);

        /// <summary>
        /// Sets the target rotation point of the entity to a set of yaw, pitch, and roll values.
        /// The rotation itself occurs in the Update method. 
        /// </summary>
        /// <param name="yaw">The angle in degrees to rotate to around the Y axis.</param>
        /// <param name="pitch">The angle in degrees to rotate to around the X axis.</param>
        /// <param name="roll">The angle in degrees to rotate to around the Z axis.</param>
        void RotateAbsolute(float yaw, float pitch, float roll);
        /// <summary>
        /// Sets the target rotation point of the entity to a set of yaw, pitch, and roll values
        /// extracted from a direction vector. The rotation itself occurs in the Update method.
        /// </summary>
        /// <param name="direction">A vector representing the direction to face.</param>
        void Rotate(Vector3 direction, float roll);

        /// <summary>
        /// Sets the target and current rotation points of the entity to a set of yaw, pitch, and
        /// roll values. The rotation itself occurs in the Update method. 
        /// </summary>
        /// <param name="yaw">The angle in degrees to rotate to around the Y axis.</param>
        /// <param name="pitch">The angle in degrees to rotate to around the X axis.</param>
        /// <param name="roll">The angle in degrees to rotate to around the Z axis.</param>
        void RotateAbsoluteImmediate(float yaw, float pitch, float roll);
        /// <summary>
        /// Sets the target and current rotation points of the entity to a set of yaw, pitch, and
        /// roll values extracted from a direction vector. The rotation itself occurs in the 
        /// Update method.
        /// </summary>
        /// <param name="direction">A vector representing the direction to face.</param>
        void RotateImmediate(Vector3 direction, float roll);
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current yaw of the entity in degrees.
        /// </summary>
        float Yaw { get; }
        /// <summary>
        /// Gets the current pitch of the entity in degrees.
        /// </summary>
        float Pitch { get; }
        /// <summary>
        /// Gets the current roll of the entity in degrees.
        /// </summary>
        float Roll { get; }

        /// <summary>
        /// Gets the target yaw of the entity in degrees.
        /// </summary>
        float TargetYaw { get; }
        /// <summary>
        /// Gets the target pitch of the entity in degrees.
        /// </summary>
        float TargetPitch { get; }
        /// <summary>
        /// Gets the target roll of the entity in degrees.
        /// </summary>
        float TargetRoll { get; }

        /// <summary>
        /// Gets the vector representing the X axis of the entity.
        /// </summary>
        Vector3 AxisX { get; }
        /// <summary>
        /// Gets the vector representing the Y axis of the entity.
        /// </summary>
        Vector3 AxisY { get; }
        /// <summary>
        /// Gets the vector representing the Z axis of the entity.
        /// </summary>
        Vector3 AxisZ { get; }

        /// <summary>
        /// Gets or sets the rotation speed around the three axes.
        /// </summary>
        Vector3 RotationSpeed { get; set; }
        #endregion
    }
}
