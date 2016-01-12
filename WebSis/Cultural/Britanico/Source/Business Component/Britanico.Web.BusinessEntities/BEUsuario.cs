using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEUsuario
    {
        public BEUsuario()
        {
        }
        
        public BEUsuario(System.Int32 rol_codi, System.String usua_amat, System.String usua_apat, System.Int32 usua_codi, System.Int32 usua_esta, System.String usua_login, System.String usua_mail, System.String usua_nomb, System.String usua_pass)
        {
            this.rol_codiField = rol_codi;
            this.usua_amatField = usua_amat;
            this.usua_apatField = usua_apat;
            this.usua_codiField = usua_codi;
            this.usua_estaField = usua_esta;
            this.usua_loginField = usua_login;
            this.usua_mailField = usua_mail;
            this.usua_nombField = usua_nomb;
            this.usua_passField = usua_pass;
        }
		
		private System.Int32 rol_codiField;		
		
	    public System.Int32 rol_codi
	    {
	        get { return this.rol_codiField; }
	        set { this.rol_codiField = value; }
	    }

		private System.String usua_amatField;		
		
	    public System.String usua_amat
	    {
	        get { return this.usua_amatField; }
	        set { this.usua_amatField = value; }
	    }

		private System.String usua_apatField;		
		
	    public System.String usua_apat
	    {
	        get { return this.usua_apatField; }
	        set { this.usua_apatField = value; }
	    }

		private System.Int32 usua_codiField;		
		
	    public System.Int32 usua_codi
	    {
	        get { return this.usua_codiField; }
	        set { this.usua_codiField = value; }
	    }

		private System.Int32 usua_estaField;		
		
	    public System.Int32 usua_esta
	    {
	        get { return this.usua_estaField; }
	        set { this.usua_estaField = value; }
	    }

		private System.String usua_loginField;		
		
	    public System.String usua_login
	    {
	        get { return this.usua_loginField; }
	        set { this.usua_loginField = value; }
	    }

		private System.String usua_mailField;		
		
	    public System.String usua_mail
	    {
	        get { return this.usua_mailField; }
	        set { this.usua_mailField = value; }
	    }

		private System.String usua_nombField;		
		
	    public System.String usua_nomb
	    {
	        get { return this.usua_nombField; }
	        set { this.usua_nombField = value; }
	    }

		private System.String usua_passField;		
		
	    public System.String usua_pass
	    {
	        get { return this.usua_passField; }
	        set { this.usua_passField = value; }
	    }

    }
}

