using System;

namespace WebApp.Models
{
    /// <summary>
    /// Error view model
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request ID
        /// </summary>
        public string RequestId { get; set; } = default!;

        /// <summary>
        /// Show request ID bool
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}