using OpenTK;
using SGE.Entity;
using SGE.Event;
using SGE.Math;

namespace SGE.Camera {
    public class QuaternionCamera : AbstractFreeCamera {
        #region Constructors
        /// <summary>
        /// The default QuaternionCamera constructor.
        /// </summary>
        public QuaternionCamera() : base() {
            _Orientation = Quaternion.Identity;
        }

        /// <summary>
        /// The QuaternionCamera constructor.
        /// </summary>
        /// <param name="position">The initial position.</param>
        /// <param name="target">The initial target.</param>
        /// <param name="acceleration">The acceleration of the camera.</param>
        /// <param name="rotationSpeed">The rotation speed of the camera.</param>
        public QuaternionCamera(Vector3 position, Vector3 target, Vector3 acceleration, Vector3 rotationSpeed) 
            : base(position, target, acceleration, rotationSpeed) {
                _Orientation = Quaternion.Identity;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// An event handler which is called when the camera must be updated.
        /// </summary>
        /// <param name="sender">The object that requested the update.</param>
        /// <param name="eventArgs">The event arguments for the update.</param>
        public void Update(object sender, UpdateEventArgs eventArgs) {
            UpdatePosition(eventArgs.Delta);
            UpdateRotation(eventArgs.Delta);

            UpdateViewMatrix();
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Updates the current position of the camera.
        /// </summary>
        /// <param name="delta">The delta time since the last update.</param>
        protected void UpdatePosition(float delta) {
            // TODO: Add code to update position based on newton's second law here.
        }

        /// <summary>
        /// Updates the current rotation of the camera.
        /// </summary>
        /// <param name="delta">The delta time since the last update.</param>
        protected void UpdateRotation(float delta) {
            float yawChange = delta * _RotationSpeed.Y;
            float pitchChange = delta * _RotationSpeed.X;
            float rollChange = delta * _RotationSpeed.Z;

            if (_Yaw < _TargetYaw) {
                _Yaw += yawChange * delta;
                if (_Yaw > _TargetYaw) {
                    _Yaw = _TargetYaw;
                }
            } else if (_Yaw > _TargetYaw) {
                _Yaw -= yawChange * delta;
                if (_Yaw < _TargetYaw) {
                    _Yaw = _TargetYaw;
                }
            }

            if (_Pitch < _TargetPitch) {
                _Pitch += pitchChange * delta;
                if (_Pitch > _TargetPitch) {
                    _Pitch = _TargetPitch;
                }
            } else if (_Pitch > _TargetPitch) {
                _Pitch -= pitchChange * delta;
                if (_Pitch < _TargetPitch) {
                    _Pitch = _TargetPitch;
                }
            }

            if (_Roll < _TargetRoll) {
                _Roll += rollChange * delta;
                if (_Roll > _TargetRoll) {
                    _Roll = _TargetRoll;
                }
            } else if (_Roll > _TargetRoll) {
                _Roll -= rollChange * delta;
                if (_Roll < _TargetRoll) {
                    _Roll = _TargetRoll;
                }
            }

            _Orientation = Quaternion.Identity;
            _Orientation *= Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(_Yaw));
            _Orientation *= Quaternion.FromAxisAngle(-Vector3.UnitX, MathHelper.DegreesToRadians(_Pitch));
            _Orientation *= Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(_Roll));
        }

        #region Extends AbstractFreeCamera
        /// <summary>
        /// Updates the view matrix of the camera based on its position and
        /// facing direction.
        /// </summary>
        protected override void UpdateViewMatrix() {
            _ViewMatrix = QuaternionHelper.CreateRotationMatrix(_Orientation);

            _AxisX.X = _ViewMatrix[0, 0];
            _AxisX.Y = _ViewMatrix[1, 0];
            _AxisX.Z = _ViewMatrix[2, 0];

            _AxisY.X = _ViewMatrix[0, 1];
            _AxisY.Y = _ViewMatrix[1, 1];
            _AxisY.Y = _ViewMatrix[2, 1];

            _AxisZ.X = _ViewMatrix[0, 2];
            _AxisZ.Y = _ViewMatrix[1, 2];
            _AxisZ.Z = _ViewMatrix[2, 2];

            _Target = -_AxisZ;

            _ViewMatrix[3, 0] = -Vector3.Dot(_AxisX, _Position);
            _ViewMatrix[3, 1] = -Vector3.Dot(_AxisY, _Position);
            _ViewMatrix[3, 2] = -Vector3.Dot(_AxisZ, _Position);
        }
        #endregion
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current orientation of the camera.
        /// </summary>
        public Quaternion Orientation {
            get {
                return _Orientation;
            }
        }
        #endregion

        #region Protected Fields
        protected Quaternion _Orientation;
        #endregion
    }
}
