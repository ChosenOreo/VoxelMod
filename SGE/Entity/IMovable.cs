using OpenTK;
using SGE.Event;

namespace SGE.Entity {
    public interface IMovable : IPlaceable, IUpdateable {
        #region Methods
        /// <summary>
        /// Sets the target position of the entity to a position relative to the
        /// current position based on a set of x, y, and z coordinates. The
        /// movement itself occurs in the Update method.
        /// </summary>
        /// <param name="x">Relative X coordinate.</param>
        /// <param name="y">Relative Y coordinate.</param>
        /// <param name="z">Relative Z coordinate.</param>
        void Move(float x, float y, float z);
        /// <summary>
        /// Sets the target position of the entity to a position relative to the
        /// current position based on a direction vector and a vector representing
        /// the amount to move on each axis of the direction vector. The movement
        /// itself occurs in the Update method.
        /// </summary>
        /// <param name="direction">The set of axes to move on.</param>
        /// <param name="amount">The distance to move on each axis.</param>
        void Move(Vector3 direction, Vector3 amount);

        /// <summary>
        /// Sets the target position of the entity to an absolute position based on
        /// a set of x, y, and z coordinates. The movement itself occurs in the 
        /// Update method.
        /// </summary>
        /// <param name="x">Absolute X coordinate.</param>
        /// <param name="y">Absolute Y coordinate.</param>
        /// <param name="z">Absolute Z coordinate.</param>
        void MoveAbsolute(float x, float y, float z);
        /// <summary>
        /// Sets the target position of the entity to an absolute position. The 
        /// movement itself occurs in the Update method.
        /// </summary>
        /// <param name="position">A vector representing the position to move to.</param>
        void MoveAbsolute(Vector3 position);

        /// <summary>
        /// Sets the target and current positions of the entity to a position 
        /// relative to the current position based on a set of x, y, and z 
        /// coordinates. The movement itself occurs in the Update method.
        /// </summary>
        /// <param name="x">Relative X coordinate.</param>
        /// <param name="y">Relative Y coordinate.</param>
        /// <param name="z">Relative Z coordinate.</param>
        void MoveImmediate(float x, float y, float z);
        /// <summary>
        /// Sets the target and current positions of the entity to a position 
        /// relative to the current position based on a direction vector and a 
        /// vector representing the amount to move on each axis of the direction 
        /// vector. The movement itself occurs in the Update method.
        /// </summary>
        /// <param name="direction">The set of axes to move on.</param>
        /// <param name="amount">The distance to move on each axis.</param>
        void MoveImmediate(Vector3 direction, Vector3 amount);

        /// <summary>
        /// Sets the target and current positions of the entity to an absolute 
        /// position based on a set of x, y, and z coordinates. The movement 
        /// itself occurs in the Update method.
        /// </summary>
        /// <param name="x">Absolute X coordinate.</param>
        /// <param name="y">Absolute Y coordinate.</param>
        /// <param name="z">Absolute Z coordinate.</param>
        void MoveAbsoluteImmediate(float x, float y, float z);
        /// <summary>
        /// Sets the target and current positions of the entity to an absolute 
        /// position. The movement itself occurs in the Update method.
        /// </summary>
        /// <param name="position">A vector representing the position to move to.</param>
        void MoveAbsoluteImmediate(Vector3 position);
        #endregion

        #region Properties
        /// <summary>
        /// Gets the target position of the entity.
        /// </summary>
        Vector3 TargetPosition { get; }

        /// <summary>
        /// Gets the current velocity of the entity.
        /// </summary>
        Vector3 Velocity { get; }

        /// <summary>
        /// Gets or sets the acceleration of the entity.
        /// </summary>
        Vector3 Acceleration { get; set; }
        #endregion
    }
}
