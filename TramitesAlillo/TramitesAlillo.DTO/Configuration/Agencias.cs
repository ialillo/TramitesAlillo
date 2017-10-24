using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TramitesAlillo.DTO.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    class Agencias
    {
        /// <summary>
        /// 
        /// </summary>
        public Agencias() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="razonSocial"></param>
        /// <param name="alias"></param>
        /// <param name="rfc"></param>
        /// <param name="calle"></param>
        /// <param name="numExt"></param>
        /// <param name="numInt"></param>
        /// <param name="colonia"></param>
        /// <param name="municipio"></param>
        /// <param name="localidad"></param>
        /// <param name="estado"></param>
        /// <param name="codigoPostal"></param>
        /// <param name="email"></param>
        /// <param name="telefono"></param>
        /// <param name="ctaContable"></param>
        /// <param name="ctaDeposito"></param>
        /// <param name="activo"></param>
        public Agencias(int id, string razonSocial, string alias, string rfc, string calle, string numExt, string numInt, string colonia, string municipio, 
            string localidad, string estado,string codigoPostal, string email, string telefono, string ctaContable, string ctaDeposito, bool activo)
        {
            this.Id = id;
            this.RazonSocial = razonSocial;
            this.Alias = alias;
            this.Rfc = rfc;
            this.Calle = calle;
            this.NumExt = numExt;
            this.NumInt = numInt;
            this.Colonia = colonia;
            this.Municipio = municipio;
            this.Localidad = localidad;
            this.Estado = estado;
            this.CodigoPostal = codigoPostal;
            this.Email = email;
            this.Telefono = telefono;
            this.CtaContable = ctaContable;
            this.CtaDeposito = ctaDeposito;
            this.Activo = activo;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string RazonSocial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Alias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Rfc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Calle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NumExt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NumInt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Colonia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Municipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Localidad { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Estado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CodigoPostal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Telefono { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CtaContable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CtaDeposito { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Activo { get; set; }
    }
}
