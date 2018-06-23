using System;
using TramitesAlillo.DAL;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TramitesAlillo.DTO.General.Catalogs
{
    public class SelectCatalogosDAL : DBAcceso<SelectCatalogs>
    {
        public SelectCatalogosDAL() { }

        /// <summary>
        /// Regresamos el catalogo de entidades tramite a las que tenga permiso el usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public SelectCatalogs GetEntidadesTramite(int idUsuario)
        {
            return GetObject("Catalogos.EntidadTramiteManagement", 3, idUsuario);
        }

        /// <summary>
        /// Obtiene el catalogo de requerimientos de tramite
        /// </summary>
        /// <returns></returns>
        public SelectCatalogs GetRequerimientoTramite()
        {
            return GetObject("Catalogos.RequerimientoTramiteManagement", 5);
        }

        /// <summary>
        /// Regresamos el catalogo de tipos de entrega de requerimientos
        /// </summary>
        /// <returns></returns>
        public SelectCatalogs GetRequerimientoTramiteTipoEntrega()
        {
            return GetObject("Catalogos.RequerimientoTramiteTipoEntregaManagement", 5);
        }

        /// <summary>
        /// Regresamos el catalogo de tipos de tramite
        /// </summary>
        /// <returns></returns>
        public SelectCatalogs GetTipoTramite()
        {
            return GetObject("Catalogos.TipoTramiteManagement", 5);
        }
    }
}
