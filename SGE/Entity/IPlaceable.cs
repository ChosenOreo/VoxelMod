using OpenTK;

namespace SGE.Entity {
    public interface IPlaceable {
        #region Properties
        /// <summary>
        /// Gets the current position of the entity.
        /// </summary>
        Vector3 Position { get; }

        /// <summary>
        /// Gets the vector representing the direction the entity is facing.
        /// </summary>
        Vector3 Direction { get; }
        #endregion
    }
}
