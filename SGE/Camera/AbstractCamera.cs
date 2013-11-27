using OpenTK;

namespace SGE.Camera {
    public abstract class AbstractCamera : ICamera {
        #region Properties
        /// <summary>
        /// Gets the current View Matrix defined by the camera's
        /// target and position vectors.
        /// </summary>
        Matrix4 ViewMatrix {
            get {
                return _ViewMatrix;
            }
        }
        #endregion

        #region Private Fields
        private Matrix4 _ViewMatrix;
        #endregion
    }
}
