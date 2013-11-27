using OpenTK;
using SGE.Entity;
using SGE.Event;
using System;

namespace SGE.Camera {
    /// <summary>
    /// An abstract camera class that allows movement and rotation.
    /// </summary>
    public abstract class AbstractFreeCamera : AbstractCamera, IMovable, IRotatable, IUpdateable {
        #region Constructors
        /// <summary>
        /// The default AbstractFreeCamera constructor.
        /// </summary>
        public AbstractFreeCamera()
            : this(Vector3.Zero, -Vector3.UnitZ, new Vector3(2.0F, 2.0F, 2.0F), new Vector3(20.0F, 20.0F, 20.0F)) {
        }

        /// <summary>
        /// The AbstractFreeCamera constructor.
        /// </summary>
        /// <param name="position">The initial position.</param>
        /// <param name="target">The initial target.</param>
        /// <param name="acceleration">The acceleration of the camera.</param>
        /// <param name="rotationSpeed">The rotation speed of the camera.</param>
        public AbstractFreeCamera(Vector3 position, Vector3 target, Vector3 acceleration, Vector3 rotationSpeed) {
            _Position = position;
            _Target = target;
            _Acceleration = acceleration;
            _RotationSpeed = rotationSpeed;

            _Yaw = 0.0F;
            _Pitch = 0.0F;
            _Roll = 0.0F;

            _TargetYaw = 0.0F;
            _TargetPitch = 0.0F;
            _TargetRoll = 0.0F;

            _AxisX = Vector3.UnitX;
            _AxisY = Vector3.UnitY;
            _AxisZ = Vector3.UnitZ;

            _TargetPosition = new Vector3(_Position);

            _Velocity = Vector3.Zero;
        }
        #endregion

        #region Public Methods
        #region Implements IMovable
        /// <summary>
        /// Sets the target position of the entity to a position relative to the
        /// current position based on a set of x, y, and z coordinates. The
        /// movement itself occurs in the Update method.
        /// </summary>
        /// <param name="x">Relative X coordinate.</param>
        /// <param name="y">Relative Y coordinate.</param>
        /// <param name="z">Relative Z coordinate.</param>
        void Move(float x, float y, float z) {
            _TargetPosition += _AxisX * x;
            _TargetPosition += _AxisY * y;
            _TargetPosition += _AxisZ * z;
        }
        /// <summary>
        /// Sets the target position of the entity to a position relative to the
        /// current position based on a direction vector and a vector representing
        /// the amount to move on each axis of the direction vector. The movement
        /// itself occurs in the Update method.
        /// </summary>
        /// <param name="direction">The set of axes to move on.</param>
        /// <param name="amount">The distance to move on each axis.</param>
        void Move(Vector3 direction, Vector3 amount) {
            _TargetPosition.X += direction.X * amount.X;
            _TargetPosition.Y += direction.Y * amount.Y;
            _TargetPosition.Z += direction.Z * amount.Z;
        }

        /// <summary>
        /// Sets the target position of the entity to an absolute position based on
        /// a set of x, y, and z coordinates. The movement itself occurs in the 
        /// Update method.
        /// </summary>
        /// <param name="x">Absolute X coordinate.</param>
        /// <param name="y">Absolute Y coordinate.</param>
        /// <param name="z">Absolute Z coordinate.</param>
        void MoveAbsolute(float x, float y, float z) {
            _TargetPosition.X = x;
            _TargetPosition.Y = y;
            _TargetPosition.Z = z;
        }
        /// <summary>
        /// Sets the target position of the entity to an absolute position. The 
        /// movement itself occurs in the Update method.
        /// </summary>
        /// <param name="position">A vector representing the position to move to.</param>
        void MoveAbsolute(Vector3 position) {
            _TargetPosition.X = position.X;
            _TargetPosition.Y = position.Y;
            _TargetPosition.Z = position.Z;
        }

        /// <summary>
        /// Sets the target and current positions of the entity to a position 
        /// relative to the current position based on a set of x, y, and z 
        /// coordinates. The movement itself occurs in the Update method.
        /// </summary>
        /// <param name="x">Relative X coordinate.</param>
        /// <param name="y">Relative Y coordinate.</param>
        /// <param name="z">Relative Z coordinate.</param>
        void MoveImmediate(float x, float y, float z) {
            _Position += _AxisX * x;
            _Position += _AxisY * y;
            _Position += _AxisZ * z;
            _TargetPosition.X = _Position.X;
            _TargetPosition.Y = _Position.Y;
            _TargetPosition.Z = _Position.Z;
        }
        /// <summary>
        /// Sets the target and current positions of the entity to a position 
        /// relative to the current position based on a direction vector and a 
        /// vector representing the amount to move on each axis of the direction 
        /// vector. The movement itself occurs in the Update method.
        /// </summary>
        /// <param name="direction">The set of axes to move on.</param>
        /// <param name="amount">The distance to move on each axis.</param>
        void MoveImmediate(Vector3 direction, Vector3 amount) {
            _Position.X += direction.X * amount.X;
            _Position.Y += direction.Y * amount.Y;
            _Position.Z += direction.Z * amount.Z;
            _TargetPosition.X = _Position.X;
            _TargetPosition.Y = _Position.Y;
            _TargetPosition.Z = _Position.Z;
        }

        /// <summary>
        /// Sets the target and current positions of the entity to an absolute 
        /// position based on a set of x, y, and z coordinates. The movement 
        /// itself occurs in the Update method.
        /// </summary>
        /// <param name="x">Absolute X coordinate.</param>
        /// <param name="y">Absolute Y coordinate.</param>
        /// <param name="z">Absolute Z coordinate.</param>
        void MoveAbsoluteImmediate(float x, float y, float z) {
            _Position.X = x;
            _Position.Y = y;
            _Position.Z = z;
            _TargetPosition.X = x;
            _TargetPosition.Y = y;
            _TargetPosition.Z = z;
        }
        /// <summary>
        /// Sets the target and current positions of the entity to an absolute 
        /// position. The movement itself occurs in the Update method.
        /// </summary>
        /// <param name="position">A vector representing the position to move to.</param>
        void MoveAbsoluteImmediate(Vector3 position) {
            _Position.X = position.X;
            _Position.Y = position.Y;
            _Position.Z = position.Z;
            _TargetPosition.X = _Position.X;
            _TargetPosition.Y = _Position.Y;
            _TargetPosition.Z = _Position.Z;
        }
        #endregion

        #region Implements IRotatable
        /// <summary>
        /// Offsets the target rotation point of the entity to a set of yaw, pitch, and roll
        /// values. The rotation itself occurs in the Update method. 
        /// </summary>
        /// <param name="yaw">The angle in degrees to rotate around the Y axis.</param>
        /// <param name="pitch">The angle in degrees to rotate around the X axis.</param>
        /// <param name="roll">The angle in degrees to rotate around the Z axis.</param>
        void Rotate(float yaw, float pitch, float roll) {
            _TargetYaw += yaw;
            _TargetPitch += pitch;
            _TargetRoll += roll;
        }

        /// <summary>
        /// Offsets the target and current rotation points of the entity to a set of yaw, pitch,
        /// and roll values. The rotation itself occurs in the Update method. 
        /// </summary>
        /// <param name="yaw">The angle in degrees to rotate around the Y axis.</param>
        /// <param name="pitch">The angle in degrees to rotate around the X axis.</param>
        /// <param name="roll">The angle in degrees to rotate around the Z axis.</param>
        void RotateImmediate(float yaw, float pitch, float roll) {
            _Yaw += yaw;
            _Pitch += pitch;
            _Roll += roll;
            _TargetYaw = _Yaw;
            _TargetPitch = _Pitch;
            _TargetRoll = _Roll;
        }

        /// <summary>
        /// Sets the target rotation point of the entity to a set of yaw, pitch, and roll values.
        /// The rotation itself occurs in the Update method. 
        /// </summary>
        /// <param name="yaw">The angle in degrees to rotate to around the Y axis.</param>
        /// <param name="pitch">The angle in degrees to rotate to around the X axis.</param>
        /// <param name="roll">The angle in degrees to rotate to around the Z axis.</param>
        void RotateAbsolute(float yaw, float pitch, float roll) {
            _TargetYaw = yaw;
            _TargetPitch = pitch;
            _TargetRoll = roll;
        }
        /// <summary>
        /// Sets the target rotation point of the entity to a set of yaw, pitch, and roll values
        /// extracted from a direction vector. The rotation itself occurs in the Update method.
        /// </summary>
        /// <param name="direction">A vector representing the direction to face.</param>
        /// <param name="roll">The angle in degrees to rotate to around the Z axis.</param>
        void Rotate(Vector3 direction, float roll) {
            Vector3 vec = direction.Normalized();
            float yawDot = Vector3.Dot(vec, Vector3.UnitZ);
            float pitchDot = Vector3.Dot(vec, Vector3.UnitY);
            float yaw = 1.0F / (float)System.Math.Cos(yawDot);
            float pitch = 1.0F / (float)System.Math.Cos(pitchDot);
            _TargetYaw = yaw;
            _TargetPitch = pitch;
            _TargetRoll = roll;
        }

        /// <summary>
        /// Sets the target and current rotation points of the entity to a set of yaw, pitch, and
        /// roll values. The rotation itself occurs in the Update method. 
        /// </summary>
        /// <param name="yaw">The angle in degrees to rotate to around the Y axis.</param>
        /// <param name="pitch">The angle in degrees to rotate to around the X axis.</param>
        /// <param name="roll">The angle in degrees to rotate to around the Z axis.</param>
        void RotateAbsoluteImmediate(float yaw, float pitch, float roll) {
            _Yaw = yaw;
            _Pitch = pitch;
            _Roll = roll;
            _TargetYaw = yaw;
            _TargetPitch = pitch;
            _TargetRoll = roll;
        }
        /// <summary>
        /// Sets the target and current rotation points of the entity to a set of yaw, pitch, and
        /// roll values extracted from a direction vector. The rotation itself occurs in the 
        /// Update method.
        /// </summary>
        /// <param name="direction">A vector representing the direction to face.</param>
        /// <param name="roll">The angle in degrees to rotate to around the Z axis.</param>
        void RotateImmediate(Vector3 direction, float roll) {
            Vector3 vec = direction.Normalized();
            float yawDot = Vector3.Dot(vec, Vector3.UnitZ);
            float pitchDot = Vector3.Dot(vec, Vector3.UnitY);
            float yaw = 1.0F / (float)System.Math.Cos(yawDot);
            float pitch = 1.0F / (float)System.Math.Cos(pitchDot);
            _Yaw = yaw;
            _Pitch = pitch;
            _Roll = roll;
            _TargetYaw = yaw;
            _TargetPitch = pitch;
            _TargetRoll = roll;
        }
        #endregion
        #endregion

        #region Protected Methods
        /// <summary>
        /// Updates the view matrix of the camera based on its position and
        /// facing direction.
        /// </summary>
        protected abstract void UpdateViewMatrix();
        #endregion

        #region Properties
        #region Implements IMovable
        /// <summary>
        /// Gets the target position of the entity.
        /// </summary>
        public Vector3 TargetPosition {
            get {
                return _TargetPosition;
            }
        }

        /// <summary>
        /// Gets the current velocity of the entity.
        /// </summary>
        public Vector3 Velocity {
            get {
                return _Velocity;
            }
        }

        /// <summary>
        /// Gets or sets the acceleration of the entity.
        /// </summary>
        public Vector3 Acceleration {
            get {
                return _Acceleration;
            }
            set {
                _Acceleration = value;
            }
        }

        #endregion

        #region Implements IRotatable
        /// <summary>
        /// Gets the current yaw of the entity in degrees.
        /// </summary>
        public float Yaw {
            get {
                return _Yaw;
            }
        }
        /// <summary>
        /// Gets the current pitch of the entity in degrees.
        /// </summary>
        public float Pitch {
            get {
                return _Pitch;
            }
        }
        /// <summary>
        /// Gets the current roll of the entity in degrees.
        /// </summary>
        public float Roll {
            get {
                return _Roll;
            }
        }

        /// <summary>
        /// Gets the target yaw of the entity in degrees.
        /// </summary>
        public float TargetYaw {
            get {
                return _TargetYaw;
            }
        }
        /// <summary>
        /// Gets the target pitch of the entity in degrees.
        /// </summary>
        public float TargetPitch {
            get {
                return _TargetPitch;
            }
        }
        /// <summary>
        /// Gets the target roll of the entity in degrees.
        /// </summary>
        public float TargetRoll {
            get {
                return _TargetRoll;
            }
        }

        /// <summary>
        /// Gets the vector representing the X axis of the entity.
        /// </summary>
        public Vector3 AxisX {
            get {
                return _AxisX;
            }
        }
        /// <summary>
        /// Gets the vector representing the Y axis of the entity.
        /// </summary>
        public Vector3 AxisY {
            get {
                return _AxisY;
            }
        }
        /// <summary>
        /// Gets the vector representing the Z axis of the entity.
        /// </summary>
        public Vector3 AxisZ {
            get {
                return _AxisZ;
            }
        }

        /// <summary>
        /// Gets or sets the rotation speed around the three axes.
        /// </summary>
        Vector3 RotationSpeed {
            get {
                return _RotationSpeed;
            }
            set {
                _RotationSpeed = value;
            }
        }
        #endregion
        #endregion

        #region Protected Fields
        #region Implements IMovable
        protected Vector3 _TargetPosition;

        protected Vector3 _Velocity;
        protected Vector3 _Acceleration;
        #endregion

        #region Implements IRotatable
        protected float _Yaw;
        protected float _Pitch;
        protected float _Roll;

        protected float _TargetYaw;
        protected float _TargetPitch;
        protected float _TargetRoll;

        protected Vector3 _AxisX;
        protected Vector3 _AxisY;
        protected Vector3 _AxisZ;

        protected Vector3 _RotationSpeed;
        #endregion
        #endregion
    }
}
