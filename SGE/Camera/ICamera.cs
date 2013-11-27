using OpenTK;
using SGE.Entity;
using SGE.Event;

namespace SGE.Camera {
    public interface ICamera : IPlaceable, IUpdateable {
        #region Properties
        /// <summary>
        /// Gets the current View Matrix defined by the camera's
        /// target and position vectors.
        /// </summary>
        Matrix4 ViewMatrix { get; }
        #endregion
    }
}
