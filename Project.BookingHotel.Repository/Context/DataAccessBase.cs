using Microsoft.Data.SqlClient;
using System.Data;

namespace Project.BookingHotel.Repository.Context
{
    public class DataAccessBase : IDisposable
    {
        SqlConnection connection = null;

        SqlConnection Connection { get { return this.connection; } set { this.connection = value; } }

        public DataAccessBase(string constring)
        {
            this.connection = new SqlConnection(constring);
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(string spName, Action<SqlParameterCollection> spparameter)
        {
            return await this.ProcessCommandAsync(spName, spparameter).ExecuteReaderAsync();
        }

        private SqlCommand ProcessCommandAsync(string sp, Action<SqlParameterCollection> applyspparameter)
        {
            SqlCommand command = new SqlCommand(sp);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command.Connection = this.connection;
            if (applyspparameter != null)
            {
                applyspparameter(command.Parameters);
            }
            return command;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool dis)
        {
            if (dis)
            {
                if (this.connection != null)
                {
                    this.connection.Close();
                    this.connection.Dispose();
                }
            }
        }
    }
}
