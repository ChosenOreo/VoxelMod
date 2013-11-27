using OpenTK;
using SGE.Entity;

namespace SGE.Camera {
    /// <summary>
    /// An abstract camera class.
    /// </summary>
    public abstract class AbstractCamera : ICamera, IPlaceable {
        #region Properties
        #region Implements ICamera
        /// <summary>
        /// Gets the current View Matrix defined by the camera's
        /// target and position vectors.
        /// </summary>
        public Matrix4 ViewMatrix {
            get {
                return _ViewMatrix;
            }
        }
        #endregion

        #region Implements IPlaceable
        /// <summary>
        /// Gets the current position of the entity.
        /// </summary>
        public Vector3 Position {
            get {
                return _Position;
            }
        }

        /// <summary>
        /// Gets the vector representing the direction the entity is facing.
        /// </summary>
        public Vector3 Direction {
            get {
                return _Target;
            }
        }
        #endregion
        #endregion

        #region Protected Fields
        protected Matrix4 _ViewMatrix;

        protected Vector3 _Position;
        protected Vector3 _Target;
        #endregion
    }
}
