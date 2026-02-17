using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

    public class LGProductosRelacionesCE
    {
        public int IdProductosRelaciones { get; set; }
	    public string CodAlternoPrincipal { get; set; }
	    public string CodAlternoRelacionado { get; set; }
        public int CodAlmacen { get; set; }
        public int CodUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string MsgError { get; set; }

        public string Referencia { get; set; }

        public int CodReferencia { get; set; }

        public int CodProducto { get; set; }

        public int CodMarca { get; set; }

        public string Marca { get; set; }

        public string CodigoProducto { get; set; }

        public int IdFamilia { get; set; }

        public string Familia { get; set; }
    }
