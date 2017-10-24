﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TramitesAlillo.DTO.Navegation
{
    /// <summary>
    /// Representa el menú asignado al usuario que se presenta del lado izquierdo de la pantalla del sitio.
    /// </summary>
    public class Menu : IDisposable
    {
        bool _disposed;

        /// <summary>
        /// Constructor necesario para la serialización.
        /// </summary>
        public Menu() { }

        [XmlElement(ElementName = "Modulo")]
        public Modulo[] Modulos { get; set; }

        /// <summary>
        /// Regresa el menú de un usuario
        /// </summary>
        /// <param name="idUsuario">El id del usuario en la base de datos</param>
        /// <returns></returns>
        public Menu ObtenerMenu(int idUsuario)
        {
            using (DAL.DBAcceso<Menu> menu = new DAL.DBAcceso<Menu>())
            {
                return menu.GetObject("Navegacion.ObtenMenu", idUsuario);
            }
        }

        /// <summary>
        /// Destruya las instancias creadas asincronamente
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destruye las instancias internas condicionalmente
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}
