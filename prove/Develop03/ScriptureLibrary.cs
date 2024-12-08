using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
   /// <summary>
/// Manages a collection of Scripture objects and provides methods
/// for adding and getting a random scripture.
/// </summary
    class ScriptureLibrary
    {
        private List<Scripture> _scriptures;
        private Random _random;

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>();
            _random = new Random();
        }

        /// <summary>
        /// Adds a script to the library.
        /// </summary>
        public void AddScripture(Scripture scripture)
        {
            _scriptures.Add(scripture);
        }

        /// <summary>
        /// Returns a random write from the library.
        /// Assumes there is at least one write in the list.
        /// </summary>
        public Scripture GetRandomScripture()
        {
            if (_scriptures.Count == 0)
            {
                throw new InvalidOperationException("No scriptures available in the library.");
            }

            int index = _random.Next(_scriptures.Count);
            return _scriptures[index];
        }
    }
}