using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Maneja una colección de objetos Scripture y provee métodos
    /// para agregar y obtener una escritura al azar.
    /// </summary>
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
        /// Agrega una escritura a la biblioteca.
        /// </summary>
        public void AddScripture(Scripture scripture)
        {
            _scriptures.Add(scripture);
        }

        /// <summary>
        /// Retorna una escritura al azar de la biblioteca.
        /// Asume que hay al menos una escritura en la lista.
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