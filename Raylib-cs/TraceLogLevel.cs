namespace Raylib_cs
{
    /// <summary>Trace log level
    /// NOTE: Organized by priority level</summary>
    public enum TraceLogLevel
    {
        /// <summary>
        /// Display all logs
        /// </summary>
        LOG_ALL = 0,

        /// <summary>
        /// Trace logging, intended for internal use only
        /// </summary>
        LOG_TRACE,

        /// <summary>
        /// Debug logging, used for internal debugging, it should be disabled on release builds
        /// </summary>
        LOG_DEBUG,

        /// <summary>
        /// Info logging, used for program execution info
        /// </summary>
        LOG_INFO,

        /// <summary>
        /// Warning logging, used on recoverable failures
        /// </summary>
        LOG_WARNING,

        /// <summary>
        /// Error logging, used on unrecoverable failures
        /// </summary>
        LOG_ERROR,

        /// <summary>
        /// Fatal logging, used to abort program: exit(EXIT_FAILURE)
        /// </summary>
        LOG_FATAL,

        /// <summary>
        /// Disable logging
        /// </summary>
        LOG_NONE
    }
}