using RTATS.Application.Interfaces;
using RTATS.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RTATS.Infrastructure.Repositories;

public class RealtimeAirlineTrafficSystemRepository : IRealtimeAirlineTrafficSystemRepository
{
    public async Task<long> AddRealTimeAirlineTrafficSystem(CancellationToken token, Pagination pagination)
    {
        string str = "data source=DESKTOP-ANDJAU9;initial catalog=RTATS;Persist Security Info=False;User ID=sa;Password=guddu";
        var recordsAffected = 0;
        SqlConnection conn = new SqlConnection(str);

        SqlCommand sqlCommand = new SqlCommand("AddRealTimeAirlineTrafficSystem", conn);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlCommand.Parameters.AddWithValue("@Limit", pagination.limit).Direction = ParameterDirection.Input;
        sqlCommand.Parameters.AddWithValue("@Offset", pagination.offset).Direction = ParameterDirection.Input;
        sqlCommand.Parameters.AddWithValue("@Count", pagination.count).Direction = ParameterDirection.Input;
        sqlCommand.Parameters.AddWithValue("@Total", pagination.total).Direction = ParameterDirection.Input;

        // sqlCommand.Parameters.AddWithValue("@flight_date", airlineTrafficSystemViewModel.data[0].flight_date);
        // sqlCommand.Parameters.AddWithValue("@airport", airlineTrafficSystemViewModel.data[0].arrival.airport);

        try
        {
            conn.Open();
            recordsAffected  = sqlCommand.ExecuteNonQuery();



        }
        catch (SqlException)
        {
            // error here
        }
        finally
        {
            conn.Close();
        }

        return recordsAffected;
    }



    
    


}

