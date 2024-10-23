using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Web.UI.MobileControls;
using System.Runtime.Remoting.Messaging;


public partial class Login : System.Web.UI.Page {
    
    protected void Page_Load(object sender, EventArgs e)    {

    }

    //esta função devolve 1 se encontrou ameaças ou 0 se Não
    private int SqlInjection(string sql) {
        string a;
        a = sql.ToLower();
        if(a.IndexOf("drop") != -1)  return 1;
        if(a.IndexOf("select") != -1)  return 1;
        if(a.IndexOf("update") != -1)  return 1;
        if(a.IndexOf("truncate") != -1)  return 1;
        if(a.IndexOf("insert") != -1)  return 1;
        if(a.IndexOf("alter") != -1)  return 1;
        if(a.IndexOf("begin") != -1)  return 1;
        if(a.IndexOf("break") != -1)  return 1;
        if(a.IndexOf("checkpoint") != -1)  return 1;
        if(a.IndexOf("commit") != -1)  return 1;
        if(a.IndexOf("create") != -1)  return 1;
        if(a.IndexOf("cursor") != -1)  return 1;
        if(a.IndexOf("dbcc") != -1)  return 1;
        if(a.IndexOf("deny") != -1)  return 1;
        if(a.IndexOf("drop") != -1)  return 1;
        if(a.IndexOf("escape") != -1)  return 1;
        if(a.IndexOf("exec") != -1)  return 1;
        if(a.IndexOf("execute") != -1)  return 1;
        if(a.IndexOf("insert") != -1)  return 1;
        if(a.IndexOf(";go") != -1)  return 1;
        if(a.IndexOf("go;") != -1)  return 1;
        if(a.IndexOf("grant") != -1)  return 1;
        if(a.IndexOf("opendatasource") != -1)  return 1;
        if(a.IndexOf("openquery") != -1)  return 1;
        if(a.IndexOf("openrowset") != -1)  return 1;
        if(a.IndexOf("shutdown") != -1)  return 1;
        if(a.IndexOf("sp_") != -1)  return 1;
        if(a.IndexOf("tran") != -1)  return 1;
        if(a.IndexOf("transaction") != -1) return 1;
        if(a.IndexOf("update") != -1)  return 1;
        if(a.IndexOf("while") != -1)  return 1;
        if(a.IndexOf("xp_") != -1)  return 1;
        if(a.IndexOf(";") != -1)  return 1;
        if(a.IndexOf("--") != -1)  return 1;
        return 0;
    }
    protected void btnProsseguir_Click(object sender, EventArgs e)    {
        string login;
        string senha;

        login = txtLogin.Text;
        senha = txtSenha.Text;

        if( (login == "") || (senha == "") ){
            lblmsg.Text = "Login e/ou senha inválido";
            lblmsg.ForeColor= System.Drawing.Color.Red;
            return;
        }

        if(SqlInjection(login) == 1){
            lblmsg.Text = "Login e/ou senha inválido";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        // tudo ok - autenticando o usuário

        //definindo os dados do servidor sql
        string servidorsql;
        string bancodedados;
        string bdusuario;
        string bdsenha;

        servidorsql ="10.2.2.12";
        bancodedados = "oficina";
        bdusuario = "ige";
        bdsenha = "update@%";

        //definindo a conexão com o banco de dados e abrindo a conexão
        string strcon;
        strcon = "Server=" + servidorsql + ";Database=" + bancodedados + ";User Id=" + bdusuario + ";Password=" + bdsenha;
        SqlConnection sqlConexao = new SqlConnection(strcon);
        sqlConexao.Open();

        //executando a pesquisa
        string sql;
        sql = "select * from usuarios where login = '" + login + "' and senha = HashBytes('MD5','" + senha + "') and ativo = 'S' ";

        SqlCommand sqlComando = new SqlCommand(sql,sqlConexao);

        SqlDataAdapter da = new SqlDataAdapter(sqlComando);
        //SqlDataReader reader = sqlComando.ExecuteReader();
        DataSet ds = new DataSet();
        da.Fill(ds);
        //if (!reader.HasRows)
        if (ds.Tables[0].Rows.Count == 0)
            {
                lblmsg.Text = "Login Inválido";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else {
            lblmsg.Text = "Login com Sucesso";
            lblmsg.ForeColor = System.Drawing.Color.Green;

            string x;
            Session["perfil"] = ds.Tables[0].Rows[0][3];  //0=id, 1=Login, 2=Senha, 3=Perfil, 4=Ativo
            x = Session["perfil"].ToString();
            Response.Redirect("Default.aspx");
        }


    }
}