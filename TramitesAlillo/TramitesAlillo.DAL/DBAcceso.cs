using System;
using System.Xml;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;


namespace TramitesAlillo.DAL
{
    public class DBAcceso<T> : SqlDatabase, IDisposable
    {
        private bool _disposed;
        private CadenaDeConexion.CadenaConexion stringCon;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringCon"></param>
        public DBAcceso(CadenaDeConexion.CadenaConexion stringCon)
            :base(getStringConnection(stringCon))
        {
            this.stringCon = stringCon;
        }

        /// <summary>
        /// 
        /// </summary>
        public CadenaDeConexion.CadenaConexion StringConnection
        {
            get{ return StringConnection; }
            set{ this.StringConnection = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringConnection"></param>
        /// <returns></returns>
        private static string getStringConnection(CadenaDeConexion.CadenaConexion stringConnection)
        {
            return ConfigurationManager.ConnectionStrings[stringConnection.ToString()].ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        public DBAcceso()
            : this(CadenaDeConexion.CadenaConexion.TramAlillo){ }

        /// <summary>
        /// Obtiene la instancia de una clase desde la base de datos a través de la ejecucón de una consulta
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns></returns>
        public T GetObject(string query)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(this.ExecuteXmlReader(this.GetSqlStringCommand(query)));
        }

        /// <summary>
        /// Obtiene la instancia de una clase desde la base de datos a través de la ejecución de un stored procedure
        /// </summary>
        /// <param name="spName">Nombre del Stored Procedure</param>
        /// <param name="spParams">Parámetros del Stored Procedure</param>
        /// <returns></returns>
        public T GetObject(string spName, params object[] spParams)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(this.ExecuteXmlReader(this.GetStoredProcCommand(spName, spParams)));
        }

        /// <summary>
        /// Obtiene un dataset desde la base de datos a través de la ejecución de un stored procedure
        /// </summary>
        /// <param name="spName">Nombre del Stored Procedure</param>
        /// <param name="spParams">Parámetros del Stored Procedure</param>
        /// <returns></returns>
        public DataSet GetDataSet(string spName, params object[] spParams)
        {
            return this.ExecuteDataSet(spName, spParams);
        }

        /// <summary>
        /// Obtiene un booleano desde la base de datos a través de la ejecución de un stored procedure
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="spParams"></param>
        /// <returns></returns>
        public bool GetBoolean(string spName, params object[] spParams)
        {
            return (bool)this.ExecuteScalar(spName, spParams);
        }

        /// <summary>
        /// Utiliza el Garbage Collector para eliminar instancias propias
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destruye las instancias creadas asincronamente
        /// </summary>
        ~DBAcceso()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destruye las instancias internas condicionalmente
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}
