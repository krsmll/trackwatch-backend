using System.Collections.Generic;
using Domain.App;

namespace WebApp.ViewModels.Test
{
    /// <summary>
    /// Test view model
    /// </summary>
    public class TestViewModel
    {
        /// <summary>
        /// Characters
        /// </summary>
        public ICollection<Character> Characters { get; set; } = default!;
    }
}