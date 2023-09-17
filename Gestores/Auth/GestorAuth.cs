using back_prueba.functions;
using back_prueba.Models.Auth;
using back_prueba.Models.Libro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_prueba.Gestores.Auth
{
    public class GestorAuth
    {
        public string conexion = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();
        public bool Add_Usuario(Usuario usuario)
        {
            Hash hash = new Hash();

            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();

                if (existe(usuario.Username))
                {
                    return false;
                }

                string query = "insert into Usuarios (username, password, estado, creacion) values(@username, @password, @estado, @creacion)";
                string passwordHashada = hash.add_hash(usuario.Password);


                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@username", usuario.Username);
                    sqlCommand.Parameters.AddWithValue("@password", passwordHashada);
                    sqlCommand.Parameters.AddWithValue("@estado", usuario.Estado);
                    sqlCommand.Parameters.AddWithValue("@creacion", usuario.Creacion);

                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        public bool login(Usuario usuario)
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            Hash hash = new Hash();
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();

                string query = "select * from Usuarios where username = @username";


                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@username", usuario.Username);

                    try
                    {
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            int idUsuario = sqlDataReader.GetInt32(0);
                            string username = sqlDataReader.GetString(1);
                            string password = sqlDataReader.GetString(2);
                            string estado = sqlDataReader.GetString(3);
                            DateTime creacion = sqlDataReader.GetDateTime(4);

                            Usuario newUsuario = new Usuario(username, password);
                            listaUsuario.Add(newUsuario);
                        }

                        sqlDataReader.Close();
                        connection.Close();


                        String newUsername = listaUsuario[0].Username;
                        String newPassword = listaUsuario[0].Password;

                        string passwordHashada = hash.add_hash(usuario.Password);

                        if (passwordHashada != newPassword) return false;

                        return true;

                    }
                    catch (Exception ex )
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool existe(string username)
        {

            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                string query = "select * from Usuarios where username = @username";


                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    var result = sqlCommand.ExecuteScalar();

                    // Verifica si el resultado no es nulo y es mayor que cero
                    if (result != null && Convert.ToInt32(result) > 0)
                    {
                        return true; // El usuario existe
                    }
                }
            }
            return false;
        }
    
        public bool Add_Libro(Libro libro)
        {
            string usernameData = libro.username;
            string nombreData =  libro.nombre;

            return false;
        }

        public Usuario Loginv2(Usuario usuario)
        {
            Usuario usuario1 = new Usuario(usuario.Username, usuario.Password);

            return usuario1;
        }
    
    }



}