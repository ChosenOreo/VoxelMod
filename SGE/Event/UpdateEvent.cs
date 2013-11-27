using System;

namespace SGE.Event {
    /// <summary>
    /// The method signature for all event handlers that can handle update events.
    /// </summary>
    /// <param name="sender">The object that requested the update.</param>
    /// <param name="eventArgs">The event arguments for the update.</param>
    public delegate void UpdateEventHandler(object sender, UpdateEventArgs eventArgs);
    public class UpdateEventArgs : EventArgs {
        #region Constructors
        /// <summary>
        /// Creates a new UpdateEventArgs with the specified delta value.
        /// </summary>
        /// <param name="deltaTime">The delta time since the last update.</param>
        public UpdateEventArgs(float deltaTime) {
            _DeltaTime = deltaTime;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current delta time for the update.
        /// </summary>
        public float Delta {
            get {
                return _DeltaTime;
            }
        }
        #endregion

        #region Private Fields
        private float _DeltaTime;
        #endregion
    }

    public interface IUpdateable {
        #region Methods
        /// <summary>
        /// An event handler which is called when something must be updated.
        /// </summary>
        /// <param name="sender">The object that requested the update.</param>
        /// <param name="eventArgs">The event arguments for the update.</param>
        void Update(object sender, UpdateEventArgs eventArgs);
        #endregion
    }

    public class UpdateEventCaller {
        #region Public Methods
        /// <summary>
        /// Causes all event handlers that have been added to the event queue
        /// to be called for an update.
        /// </summary>
        /// <param name="sender">The object that requested the update.</param>
        /// <param name="time">The time to pass through the event arguments.</param>
        public void Fire(object sender, float time) {
            if (EventHandlers != null) {
                EventHandlers(sender, new UpdateEventArgs(time));
            }
        }
        #endregion

        #region Public Events
        /// <summary>
        /// An set of update event handlers.
        /// </summary>
        public event UpdateEventHandler EventHandlers;
        #endregion
    }
}
